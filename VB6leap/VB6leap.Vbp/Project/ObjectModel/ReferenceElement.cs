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

namespace VB6leap.Vbp.Project.ObjectModel
{
    /// <summary>
    /// Represents a reference to some other library.
    /// </summary>
    public class ReferenceElement : ElementBase
    {
        /// <summary>
        /// Gets/sets the Guid of the reference (COM).
        /// </summary>
        public Guid Guid { get; set; }
        /// <summary>
        /// Gets/sets the version string.
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// Gets/sets the part at index #3. Rename this prop if clear what it is.
        /// 
        /// 1: *\G{00020430-0000-0000-C000-000000000046}
        /// 2: 2.0
        /// 3: 0
        /// 4: C:\Windows\system32\stdole2.tlb
        /// 5: OLE Automation
        /// </summary>
        public string Reserved { get; set; }
        /// <summary>
        /// Gets/sets an optional trailing string that is sometimes appended to the filename.
        /// </summary>
        /// <remarks>Example: "C:\MyFile.dll\3"</remarks>
        public string FileNameTrailer { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            return string.Format("*\\G{{{0}}}#{1}#{2}#{3}{4}#{5}", Guid, Version, Reserved, FileName, FileNameTrailer, Name);
        }
    }
}
