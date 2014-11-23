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
using VB6leap.Vbp.Project.ObjectModel;
using VB6leap.Vbp.Project.Properties;

namespace VB6leap.Vbp.Project
{
    /// <summary>
    /// Defines members that represent a single VB6 project (VBP).
    /// </summary>
    public interface IVbProject
    {
        /// <summary>
        /// Gets the <see cref="FileInfo"/> object that specifies the file from which this project has been loaded.
        /// </summary>
        FileInfo Source { get; }
        /// <summary>
        /// Gets an instance of <see cref="IVbpProjectProperties"/> holding all options that were found in the project.
        /// </summary>
        IVbpProjectProperties Properties { get; }

        /// <summary>
        /// Gets the VB6-project type.
        /// </summary>
        ProjectType Type { get; }
        /// <summary>
        /// Gets a list of all references.
        /// </summary>
        IList<ReferenceElement> References { get; }
        /// <summary>
        /// Gets a list of all module files.
        /// </summary>
        IList<ModuleElement> Modules { get; }
        /// <summary>
        /// Gets a list of all class files.
        /// </summary>
        IList<ClassElement> Classes { get; }
        /// <summary>
        /// Gets a list of all form files.
        /// </summary>
        IList<FormElement> Forms { get; }
        /// <summary>
        /// Gets a list of all user control files.
        /// </summary>
        IList<UserControlElement> UserControls { get; }
        /// <summary>
        /// Gets a list of all objects.
        /// </summary>
        IList<ObjectElement> Objects { get; }
    }
}
