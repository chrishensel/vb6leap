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


namespace VB6leap.Vbp.Reflection.Source
{
    /// <summary>
    /// Defines members that represent a single token from a source code file.
    /// </summary>
    public interface IToken
    {
        /// <summary>
        /// Gets the location of the token within the original source code file.
        /// </summary>
        ISourceLocation Location { get; }
        /// <summary>
        /// Gets the type of this token.
        /// </summary>
        TokenType Type { get; }
        /// <summary>
        /// Gets the text content of this token.
        /// </summary>
        string Content { get; }
    }
}
