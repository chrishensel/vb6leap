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
using VB6leap.Vbp.Project;
using VB6leap.Vbp.Project.ObjectModel;
using VB6leap.Vbp.Project.Properties;
using VB6leap.VbpParser.Project;

namespace VB6leap.VbpParser
{
    class Vb6Project : IVbProject
    {
        #region IVbProject Members

        public FileInfo Source { get; private set; }
        public IVbpProjectProperties Properties { get; private set; }

        public ProjectType Type { get; set; }
        public IList<ReferenceElement> References { get; private set; }
        public IList<ModuleElement> Modules { get; private set; }
        public IList<ClassElement> Classes { get; private set; }
        public IList<FormElement> Forms { get; private set; }
        public IList<UserControlElement> UserControls { get; private set; }
        public IList<ObjectElement> Objects { get; private set; }

        #endregion

        #region Constructors

        public Vb6Project(FileInfo source)
        {
            this.Source = source;

            Properties = new VbpProjectProperties();

            References = new List<ReferenceElement>();
            Modules = new List<ModuleElement>();
            Classes = new List<ClassElement>();
            Forms = new List<FormElement>();
            UserControls = new List<UserControlElement>();
            Objects = new List<ObjectElement>();
        }

        #endregion

    }
}
