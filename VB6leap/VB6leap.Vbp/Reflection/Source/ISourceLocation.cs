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

namespace VB6leap.Vbp.Reflection.Source
{
	/// <summary>
	/// Specifies the location of an element in a source file.
	/// </summary>
	public interface ISourceLocation
	{
		/// <summary>
		/// Gets the line number.
		/// </summary>
		int Line { get; }
		/// <summary>
		/// Gets the column position at which this element starts.
		/// </summary>
		int Column { get; }
	}
}
