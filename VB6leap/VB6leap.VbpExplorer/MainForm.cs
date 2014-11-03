// This file is part of vb6leap.
// 
// vb6leap is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// vb6leap is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with vb6leap.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using VB6leap.Vbp.Project;
using VB6leap.Vbp.Project.ObjectModel;
using VB6leap.Vbp.Reflection;
using VB6leap.Vbp.Reflection.Members;
using VB6leap.Vbp.Reflection.Modules;
using VB6leap.Vbp.Serialization;
using VB6leap.VbpParser.Reflection.Source;
using VB6leap.VbpParser.Serialization;

namespace VB6leap.VbpExplorer
{
    public partial class MainForm : Form
    {
        #region Fields

        private IVbProject _project;
        private IVbFileReader _fileReader;

        #endregion

        #region Constructors

        public MainForm()
        {
            InitializeComponent();

            _fileReader = new Vb6FileReader();

            ModuleReflector.Tokenizer = new Tokenizer();
        }

        #endregion

        #region Methods

        private void btnOpenProject_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "VB6 project files (*.vbp)|*.vbp";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo fileToParse = new FileInfo(ofd.FileName);

                IVbProjectReader parser = new Vb6ProjectReader();
                using (Stream stream = fileToParse.OpenRead())
                {
                    _project = parser.Read(fileToParse, stream);
                }

                Dictionary<string, IEnumerable<ElementBase>> map = new Dictionary<string, IEnumerable<ElementBase>>();
                map["REFERENCES"] = _project.References;
                map["MODULES"] = _project.Modules;
                map["CLASSES"] = _project.Classes;
                map["FORMS"] = _project.Forms;
                map["OBJECTS"] = _project.Objects;

                foreach (var mapItem in map)
                {
                    TreeNode node = trvProject.Nodes[0].Nodes[mapItem.Key];
                    node.Nodes.Clear();

                    foreach (var item in mapItem.Value.OrderBy(_ => _.Name))
                    {
                        TreeNode itemNode = new TreeNode();
                        if (!string.IsNullOrWhiteSpace(item.Name))
                        {
                            itemNode.Text = item.Name;
                        }
                        else
                        {
                            itemNode.Text = item.FileName;
                        }

                        itemNode.Tag = item;
                        ExtendNode(item, itemNode);
                        node.Nodes.Add(itemNode);
                    }
                }

                trvProject.Nodes[0].Nodes["MODULES"].Expand();
                trvProject.Nodes[0].Nodes["CLASSES"].Expand();
                trvProject.Nodes[0].Nodes["FORMS"].Expand();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            trvProject.ExpandAll();

            btnOpenProject_Click(sender, e);
            this.Activate();
        }

        private void trvProject_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (_project == null)
            {
                return;
            }

            this.lsvProperties.Items.Clear();

            if (e.Node.Name == "PROPERTIES")
            {
                DisplayProjectProperties();
            }
            else
            {
                DisplayElementProperties(e.Node.Tag);
            }
        }

        private void DisplayProjectProperties()
        {
            foreach (var item in _project.Properties)
            {
                ListViewItem lvi = new ListViewItem(item);
                lvi.SubItems.Add(_project.Properties.Get(item, null).ToString());
                this.lsvProperties.Items.Add(lvi);
            }
        }

        private void DisplayElementProperties(object tag)
        {
            if (tag == null)
            {
                return;
            }

            if (tag is ClassElement || tag is ModuleElement || tag is FormElement)
            {
                try
                {
                    ElementBase element = (ElementBase)tag;

                    using (Stream stream = _fileReader.Read(element, _project))
                    {
                        VbPartitionedFile content = _fileReader.ReadPartitionedFile(element, stream);
                        txtEdit.Text = content.Source;
                    }
                }
                catch (Exception)
                {
                }
            }
            else
            {
                IVbMember member = tag as IVbMember;
                if (member != null)
                {
                    AddPropertyListViewItem("(Declaration)", member.ToVbDeclaration());
                    AddPropertyListViewItem("(Member type)", member.GetType().Name);

                    AddPropertyListViewItem("Name", member.Name);
                    AddPropertyListViewItem("Line", member.Location.Line);
                    AddPropertyListViewItem("Column", member.Location.Column);
                    AddPropertyListViewItem("Visibility", member.Visibility);

                    IVbMethod method = member as IVbMethod;
                    if (method != null)
                    {
                        AddPropertyListViewItem("Kind", method.MethodKind);
                        AddPropertyListViewItem("Return type", method.ReturnType.TypeName);

                        AddPropertyListViewItem("(Parameter count)", method.Parameters.Count);
                        for (int i = 0; i < method.Parameters.Count; i++)
                        {
                            IVbParameter parameter = method.Parameters[i];

                            AddPropertyListViewItem(string.Format("Param {0} (Declaration)", i), parameter.ToVbDeclaration());
                            AddPropertyListViewItem(string.Format("Param {0}: Access", i), parameter.Access);
                            AddPropertyListViewItem(string.Format("Param {0}: Name", i), parameter.Name);
                            AddPropertyListViewItem(string.Format("Param {0}: Line", i), parameter.Location.Line);
                            AddPropertyListViewItem(string.Format("Param {0}: Column", i), parameter.Location.Column);
                            AddPropertyListViewItem(string.Format("Param {0}: Type", i), parameter.Type.TypeName);

                            if (parameter.IsOptional)
                            {
                                AddPropertyListViewItem(string.Format("Param {0}: Is optional", i), true);
                                AddPropertyListViewItem(string.Format("Param {0}: Default value", i), parameter.OptionalDefaultValue);
                            }
                        }
                    }

                    IVbAttribute attribute = member as IVbAttribute;
                    if (attribute != null)
                    {
                        AddPropertyListViewItem("Value", attribute.Value);
                    }
                }
                else
                {
                    txtEdit.Clear();
                }
            }
        }

        private void AddPropertyListViewItem(string name, object value)
        {
            ListViewItem item = new ListViewItem(name);
            item.SubItems.Add(value.ToString());
            lsvProperties.Items.Add(item);
        }

        private IVbModule AnalyzeElement(ElementBase element)
        {
            try
            {
                using (Stream stream = _fileReader.Read(element, _project))
                {
                    VbPartitionedFile content = _fileReader.ReadPartitionedFile(element, stream);

                    return ModuleReflector.GetReflectedModule(content);
                }
            }
            catch (Exception)
            {

            }

            return null;
        }

        private void ExtendNode(ElementBase item, TreeNode itemNode)
        {
            if (item is ClassElement || item is ModuleElement || item is FormElement)
            {
                IVbModule reflectedModule = AnalyzeElement(item);
                if (reflectedModule == null)
                {
                    return;
                }

                foreach (IVbMember member in reflectedModule.Members)
                {
                    TreeNode node = new TreeNode();
                    node.Tag = member;

                    if (member is IVbAttribute)
                    {
                        node.Text = string.Format("(A) {0}", ((IVbAttribute)member).Name);
                    }
                    else if (member is IVbProperty)
                    {
                        IVbProperty property = (IVbProperty)member;
                        node.Text = string.Format("(P) {0} {1}", property.Accessor, property.Name);
                    }
                    else if (member is IVbMethod)
                    {
                        node.Text = string.Format("(M) {0}", ((IVbMethod)member).Name);
                    }

                    itemNode.Nodes.Add(node);
                }
            }
        }

        #endregion

    }
}
