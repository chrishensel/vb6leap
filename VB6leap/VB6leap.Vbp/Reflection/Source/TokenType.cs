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
    /// Specifies the types of tokens for processing.
    /// </summary>
    public enum TokenType
    {
        /// <summary>
        /// An unknown token. Should never really occur except due to parsing errors.
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// Represents a word. This is any text content that is not a programmatic string and should be the most common tokens.
        /// </summary>
        Word,
        /// <summary>
        /// Represents a number.
        /// </summary>
        Number,
        /// <summary>
        /// Represents a programmatic string (text enclosed in quotes).
        /// This is a single token, but the contents may possibly go over lines even (not in VB6 though).
        /// </summary>
        String,
        /// <summary>
        /// Represents a whitespace token (space, tab etc.).
        /// </summary>
        WhiteSpace,
        /// <summary>
        /// Represents a symbol (brackets, comma, equals etc.).
        /// </summary>
        Symbol,
        /// <summary>
        /// Represents the end of a line.
        /// </summary>
        EOL,
        /// <summary>
        /// Represents the end of the file.
        /// </summary>
        EOF
    }
}
