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
using VB6leap.Vbp.Project;
using VB6leap.Vbp.Project.ObjectModel;

namespace VB6leap.Vbp.Serialization
{
    /// <summary>
    /// Defines methods that (de-)serialize instances of <see cref="ElementBase" />.
    /// </summary>
    public interface IVbElementSerializer
    {
        /// <summary>
        /// Serializes the given element and returns a string representing its definition.
        /// </summary>
        /// <param name="element">The element to serialize.</param>
        /// <returns>A string that represents the provided element.</returns>
        string Serialize(ElementBase element);
        /// <summary>
        /// Deserializes a string into the appropriate <see cref="ElementBase"/> instance.
        /// </summary>
        /// <param name="content">The string to deserialize.</param>
        /// <param name="project">The parent project that is deserialized.</param>
        /// <returns>An instance of <see cref="ElementBase"/> that is appropriately representing the serialized string.</returns>
        ElementBase Deserialize(string content, IVbProject project);
    }
}
