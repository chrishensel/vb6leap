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
    /// Represents a reference to some object that is used.
    /// </summary>
    public class ObjectElement : ElementBase
    {
        /// <summary>
        /// Gets/sets the Guid of the object (COM).
        /// </summary>
        public Guid Guid { get; set; }
        /// <summary>
        /// Gets/sets the version string.
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// Gets/sets the part before the file name (0; ). Rename this prop if clear what it is.
        /// </summary>
        public string Reserved { get; set; }
    }
}
