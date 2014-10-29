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
using System.IO;
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

            sb.Append(Preamble);
            sb.Append(Source);

            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="content"/> is null.</exception>
        public static VbPartitionedFile GetPartitionedFile(string content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            VbPartitionedFile file = new VbPartitionedFile();

            /* VB6-files are slightly odd. They don't really have a common file format (only a somewhat consistent layout).
             */
            StringBuilder sb = new StringBuilder();

            // Keep the stream open for users to close.

            string lineBefore = null;
            string line = null;

            using (StringReader reader = new StringReader(content))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    /* If the last line was an Attribute and the current line represents user code, flush the current contents into the Preamble.
                     * This is really basic here and should be refined if some files are different.
                     */
                    if (lineBefore != null && lineBefore.StartsWith("Attribute", StringComparison.OrdinalIgnoreCase))
                    {
                        if ((string.IsNullOrWhiteSpace(line) || !line.StartsWith("Attribute", StringComparison.OrdinalIgnoreCase))
                            && file.Preamble == null)
                        {
                            file.Preamble = sb.ToString();
                            sb.Clear();
                        }
                    }

                    sb.AppendLine(line);

                    lineBefore = line;
                }
            }

            file.Source = sb.ToString();

            return file;
        }

        #endregion
    }
}
