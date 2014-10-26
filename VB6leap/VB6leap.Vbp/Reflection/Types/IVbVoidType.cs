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


namespace VB6leap.Vbp.Reflection.Types
{
    /// <summary>
    /// Represents the implicit type a Sub or Let/Set method "returns".
    /// See documentation for further information.
    /// </summary>
    /// <remarks>Please never use this type intentionally. This interface and its derivatives are only there for the VB6leap type system.
    /// The void type never actually gets used except to mark a sub or a property setter as having no return type.
    /// This allows us to be more flexible and maximize type re-use.</remarks>
    interface IVbVoidType
    {
    }
}
