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

using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.SharpDevelop;
using ICSharpCode.SharpDevelop.Dom;
using ICSharpCode.SharpDevelop.Project;
using VB6leap.Vbp.Project;
using VB6leap.Vbp.Project.ObjectModel;
using VB6leap.Vbp.Serialization;
using VB6leap.VbpParser.Serialization;

namespace VB6leap.SD
{
    public class VbpProject : AbstractProject, IVbpProject
    {
        #region Fields

        private VbpProjectItemsCollection _items = new VbpProjectItemsCollection();
        private IVbProject _vbProject;

        #endregion

        #region Properties

        public override string Language
        {
            get
            {
                return VbpProjectBinding.LanguageName;
            }
        }

        public override IMutableModelCollection<ProjectItem> Items
        {
            get { return _items; }
        }

        #endregion

        #region Constructors

        public VbpProject(ProjectLoadInformation info)
            : base(info)
        {
            IVbProjectReader vbpParser = new Vb6ProjectReader();

            FileInfo file = new FileInfo(info.FileName);
            using (Stream stream = file.OpenRead())
            {
                _vbProject = vbpParser.Read(file, stream);
            }

            AddGenericItems();
            AddReferences();
        }

        #endregion

        #region Methods

        private void AddReferences()
        {
            foreach (var rf in _vbProject.References)
            {
                ReferenceProjectItem item = new ReferenceProjectItem(this, rf.FileName);
                _items.Add(item);
            }
        }

        private void AddGenericItems()
        {
            List<ElementBase> itemsToAdd = new List<ElementBase>();
            itemsToAdd.AddRange(_vbProject.Modules);
            itemsToAdd.AddRange(_vbProject.Classes);
            itemsToAdd.AddRange(_vbProject.Forms);

            foreach (ElementBase item in itemsToAdd)
            {
                _items.Add(new FileProjectItem(this, ItemType.None, item.FileName));
            }
        }

        public override ItemType GetDefaultItemType(string fileName)
        {
            return ItemType.None;
        }

        public override void Start(bool withDebugging)
        {
            // TODO: Start VB6.EXE either with /run or just the EXE.

            base.Start(withDebugging);
        }

        public override Task<bool> BuildAsync(ProjectBuildOptions options, IBuildFeedbackSink feedbackSink, IProgressMonitor progressMonitor)
        {
            feedbackSink.ReportMessage(new RichText("TODO: Build the project using VB6.EXE..."));

            Thread.Sleep(1000);

            feedbackSink.ReportMessage(new RichText("Building with VB6.EXE has concluded!"));

            return Task.FromResult(true);
        }

        #endregion

        #region IVbpProject Members

        IVbProject IVbpProject.GetOwnedProject()
        {
            return _vbProject;
        }

        #endregion
    }

    class VbpProjectItemsCollection : SimpleModelCollection<ProjectItem>
    {

    }
}
