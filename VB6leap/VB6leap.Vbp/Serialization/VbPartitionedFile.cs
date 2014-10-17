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

using System.Text;

namespace VB6leap.Vbp.Serialization
{
    /// <summary>
    /// Represents a generic VB-style file that is split into non-user and user-code.
    /// </summary>
    public class VbPartitionedFile
    {
        #region Properties

        /// <summary>
        /// Gets/sets the preamble text. This is everything that is not editable by the user.
        /// </summary>
        public string Preamble { get; set; }
        /// <summary>
        /// Gets/sets the actual source contents.
        /// </summary>
        public string Source { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Returns the concatenated text consisting of the <see cref="Preamble"/> and the <see cref="Source"/>, merged with a newline between them.
        /// </summary>
        /// <returns></returns>
        public string GetMergedContent()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(Preamble);
            sb.AppendLine();
            sb.AppendLine(Source);

            return sb.ToString();
        }

        #endregion
    }
}
