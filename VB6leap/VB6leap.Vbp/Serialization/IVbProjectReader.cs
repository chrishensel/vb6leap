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

namespace VB6leap.Vbp.Serialization
{
    /// <summary>
    /// Defines members for a type that can read a file into an an instance of <see cref="IVbProject"/>.
    /// </summary>
    public interface IVbProjectReader
    {
        /// <summary>
        /// Reads the contents of a given stream (implementation-specific format) and returns an instance of <see cref="IVbProject"/> representing it.
        /// </summary>
        /// <param name="source">The file from which the project was loaded.</param>
        /// <param name="stream">The stream that contains the project file to read.</param>
        /// <returns>An instance of <see cref="IVbProject"/> representing the read project.</returns>
        IVbProject Read(FileInfo source, Stream stream);
    }
}
