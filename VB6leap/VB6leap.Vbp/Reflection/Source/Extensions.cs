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
using System.Text;

namespace VB6leap.Vbp.Reflection.Source
{
    /// <summary>
    /// Provides convenience functions for working with types in the Source-namespace.
    /// </summary>
    public static class Extensions
    {
        #region Constants

        private const int StringBuilderInitialCapacity = 100;

        #endregion

        #region Methods

        /// <summary>
        /// Takes the <see cref="IToken.Content"/> value from each item in the tokens list and concatenates them into one string.
        /// </summary>
        /// <param name="tokens">An enumerable containing the <see cref="IToken"/> instances to </param>
        /// <returns>A string consisting of the concatenated <see cref="IToken.Content"/> values.</returns>
        public static string GetString(this IEnumerable<IToken> tokens)
        {
            if (tokens == null)
            {
                return "";
            }

            StringBuilder sb = new StringBuilder(StringBuilderInitialCapacity);

            foreach (IToken token in tokens)
            {
                sb.Append(token.Content);
            }

            return sb.ToString();
        }

        #endregion
    }
}
