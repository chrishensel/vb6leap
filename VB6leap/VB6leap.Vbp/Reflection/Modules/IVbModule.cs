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
using VB6leap.Vbp.Reflection.Members;

namespace VB6leap.Vbp.Reflection.Modules
{
	/// <summary>
	/// Defines a module, that is the VB Classic definition of either a class, a global module, a control or such.
	/// </summary>
	public interface IVbModule
	{
		/// <summary>
		/// Gets the name of the module.
		/// </summary>
		string Name { get; }
		/// <summary>
		/// Gets the member's visibility.
		/// </summary>
		MemberVisibility Visibility { get; }
		/// <summary>
		/// Gets a read-only list of all members of this module.
		/// </summary>
		IReadOnlyList<IVbMember> Members { get; }
	}
}
