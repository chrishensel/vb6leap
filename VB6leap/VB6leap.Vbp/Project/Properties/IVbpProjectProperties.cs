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
using VB6leap.Core.Collections;

namespace VB6leap.Vbp.Project.Properties
{
    /// <summary>
    /// Defines members for a type that exposes the VBP project properties.
    /// </summary>
    public interface IVbpProjectProperties : IPropertyBag
    {
        /// <summary>
        /// Gets/sets the title of the project.
        /// </summary>
        string Title { get; set; }
        /// <summary>
        /// Gets/sets the name of the project.
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Gets/sets the version of the application.
        /// </summary>
        Version Version { get; set; }
        /// <summary>
        /// Gets/sets the name of the object to use for startup.
        /// </summary>
        string Startup { get; set; }
        /// <summary>
        /// Gets/sets the help file name.
        /// </summary>
        string HelpFile { get; set; }
        /// <summary>
        /// Gets/sets the Help Context ID.
        /// </summary>
        string HelpContextID { get; set; }
        /// <summary>
        /// Gets/sets the target file name.
        /// </summary>
        string ExeName32 { get; set; }
        /// <summary>
        /// Gets/sets TODO
        /// </summary>
        string Command32 { get; set; }
        /// <summary>
        /// Gets/sets the compatibility mode to use for this project.
        /// </summary>
        CompatibleModeKind CompatibleMode { get; set; }
        /// <summary>
        /// Gets/sets the file name of the compatibility DLL or EXE.
        /// </summary>
        string CompatibleEXE32 { get; set; }
    }
}
