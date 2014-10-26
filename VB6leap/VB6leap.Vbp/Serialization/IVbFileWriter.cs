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

using System.IO;
using VB6leap.Vbp.Project;
using VB6leap.Vbp.Project.ObjectModel;

namespace VB6leap.Vbp.Serialization
{
    /// <summary>
    /// Defines members for writing a project element to a stream.
    /// </summary>
    public interface IVbFileWriter
    {
        /// <summary>
        /// Writes the given project element to a stream.
        /// </summary>
        /// <param name="element">The element to write.</param>
        /// <param name="parentProject">The project the element belongs to.</param>
        /// <param name="stream">The stream to write to.</param>
        void Write(ElementBase element, IVbProject parentProject, Stream stream);
    }
}
