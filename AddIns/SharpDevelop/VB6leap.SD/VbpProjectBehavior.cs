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

using ICSharpCode.SharpDevelop.Project;
using VB6leap.SDAddin.Utils;
using VB6leap.Vbp.Project;

namespace VB6leap.SDAddin
{
    class VbpProjectBehavior : ProjectBehavior
    {
        #region Fields

        private IVbpProject _project;

        #endregion

        #region Properties

        public override bool IsStartable
        {
            get { return _project.GetOwnedProject().Type == ProjectType.StandardExe; }
        }

        #endregion

        #region Constructors

        internal VbpProjectBehavior(IVbpProject project)
        {
            _project = project;
        }

        public VbpProjectBehavior()
        {
            // TODO: Complete member initialization
        }

        #endregion

        #region Methods

        public override ItemType GetDefaultItemType(string fileName)
        {
            return ItemType.None;
        }

        public override void Start(bool withDebugging)
        {
            if (!VB6Helper.GetIsVB6Available())
            {
                ICSharpCode.SharpDevelop.SD.MessageService.ShowError("Cannot locate VB6.EXE. Please make sure that you have entered the correct path to the VB6-directory under 'Tools -> VB6'.");
            }
            else
            {
                if (withDebugging)
                {
                    VB6Helper.RunProject(_project.GetOwnedProject());
                }
                else
                {
                    // TODO: Just run the EXE!
                }
            }
        }

        #endregion
    }
}
