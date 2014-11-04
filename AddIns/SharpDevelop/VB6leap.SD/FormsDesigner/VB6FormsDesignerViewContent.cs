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

using ICSharpCode.SharpDevelop.Workbench;

namespace VB6leap.SDAddin.FormsDesigner
{
    class VB6FormsDesignerViewContent : AbstractViewContent
    {
        #region Properties

        public override object Control
        {
            get { return new VB6FormsDesignerControl(); }
        }

        #endregion

        #region Constructors

        public VB6FormsDesignerViewContent(OpenedFile file)
            : base(file)
        {
            this.TabPageText = "Designer";
        }

        #endregion
    }
}
