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

using VB6leap.Vbp.Reflection.Types;

namespace VB6leap.Vbp.Reflection.Members
{
    /// <summary>
    /// Defines members that represent a VB Classic parameter.
    /// </summary>
    public interface IVbParameter : IVbMember
    {
        /// <summary>
        /// Gets the access type of this parameter.
        /// </summary>
        VbParameterAccess Access { get; }
        /// <summary>
        /// Gets the type of this parameter.
        /// </summary>
        IVbType Type { get; }
        /// <summary>
        /// Gets whether or not this parameter is marked as being optional.
        /// </summary>
        bool IsOptional { get; }
        /// <summary>
        /// Gets the default value, if this parameter is optional.
        /// </summary>
        string OptionalDefaultValue { get; }
    }
}
