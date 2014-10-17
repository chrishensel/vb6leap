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
using VB6leap.Vbp.Serialization;
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
                        node.Nodes.Add(itemNode);
                    }
                }


                trvProject.ExpandAll();
            }
        }

        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            trvProject.ExpandAll();
        }

        private async void trvProject_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (_project == null)
            {
                return;
            }

            this.lsvProperties.Items.Clear();

            if (e.Node.Name == "PROPERTIES")
            {
                foreach (var item in _project.Properties)
                {
                    ListViewItem lvi = new ListViewItem(item);
                    lvi.SubItems.Add(_project.Properties.Get<object>(item, null).ToString());
                    this.lsvProperties.Items.Add(lvi);
                }
            }
            else
            {
                txtEdit.Clear();
                txtEdit.ClearUndo();

                ElementBase tag = e.Node.Tag as ElementBase;
                if (tag != null)
                {
                    if (tag is ClassElement || tag is FormElement || tag is ModuleElement)
                    {
                        using (Stream stream = _fileReader.Read(tag, _project))
                        {
                            VbPartitionedFile content = _fileReader.ReadPartitionedFile(tag, stream);
                            txtEdit.Text = content.Source;
                        }
                    }
                }
            }
        }
    }
}
