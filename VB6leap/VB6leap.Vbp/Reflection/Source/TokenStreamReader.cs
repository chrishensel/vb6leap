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

using System.Linq;
using System;
using System.Collections.Generic;

namespace VB6leap.Vbp.Reflection.Source
{
    class TokenStreamReader
    {
        #region Fields

        private IReadOnlyList<IToken> _tokens;
        private int _position;

        #endregion

        #region Properties

        public int Position
        {
            get { return _position; }
        }

        public int Length
        {
            get { return _tokens.Count; }
        }

        public bool IsBOF
        {
            get { return _position == 0; }
        }

        public bool IsEOF
        {
            get { return _position >= _tokens.Count; }
        }

        /// <summary>
        /// Gets/sets whether or not calls that involve reading tokens will skip over comments.
        /// </summary>
        public bool SkipOverComments { get; set; }

        #endregion

        #region Constructors

        public TokenStreamReader(IReadOnlyList<IToken> tokens)
        {
            this.SkipOverComments = true;

            _tokens = tokens;
        }

        #endregion

        #region Methods

        public IToken GetPrevious()
        {
            if (IsBOF)
            {
                throw new InvalidOperationException("At beginning of file!");
            }

            return _tokens[_position - 1];
        }

        public IToken GetNext()
        {
            if (IsEOF)
            {
                throw new InvalidOperationException("At end of file!");
            }

            return _tokens[_position + 1];
        }

        /// <summary>
        /// Reads all tokens from the current position until an EOL or EOF is encountered, and honors the VB Classic line-continuation token (_).
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IToken> GetUntilEOL()
        {
            return GetUntilEOL(false, null);
        }

        /// <summary>
        /// Reads all tokens from the current position until an EOL or EOF is encountered, and honors the VB Classic line-continuation token (_).
        /// </summary>
        /// <param name="ignoreComments">Whether or not to ignore comments (regular ones or in-line comments).</param>
        /// <param name="tokenContents">Custom token contents (text only) to read until. This is ignored if set to null.</param>
        /// <returns></returns>
        public IEnumerable<IToken> GetUntilEOL(bool ignoreComments, string[] tokenContents)
        {
            IToken previous = null;
            IToken current = null;

            while (!IsEOF)
            {
                current = Read();

                if (current.Type == TokenType.EOF)
                {
                    yield break;
                }
                else if (current.Type == TokenType.EOL)
                {
                    bool hasPrevious = (previous != null);
                    if (!hasPrevious)
                    {
                        yield break;
                    }

                    if (previous.Content != "_")
                    {
                        yield break;
                    }
                }
                else
                {
                    /* Watch out for comments. If we encounter a comment, abort looking altogether.
                     */
                    if (current.Content == "'" && ignoreComments)
                    {
                        yield break;
                    }

                    /* Check for a custom contents to look out for.
                     */
                    if (tokenContents != null)
                    {
                        if (tokenContents.Contains(current.Content))
                        {
                            yield break;
                        }
                    }

                    /* "Eat" the line continuation. It is not important for the user.
                     */
                    bool isLineContinuation = (current.Content == "_");
                    if (!isLineContinuation)
                    {
                        yield return current;
                    }

                    previous = current;
                }
            }
        }

        public IToken Read()
        {
            if (IsEOF)
            {
                throw new InvalidOperationException("At end of file!");
            }

            int offset = 0;
            IToken token = null;

            Peek(out token, out offset);

            _position += offset;

            return token;
        }

        public IToken Peek()
        {
            int offset = 0;
            IToken token = null;

            Peek(out token, out offset);

            return token;
        }

        private void Peek(out IToken token, out int offset)
        {
            if (IsEOF)
            {
                throw new InvalidOperationException("At end of file!");
            }

            int posTemp = _position;

            IToken tokenTemp = _tokens[posTemp];

            if (SkipOverComments)
            {
                bool isInComment = (tokenTemp.Content == "'");
                while (isInComment)
                {
                    if (tokenTemp.Type == TokenType.EOF ||
                        tokenTemp.Type == TokenType.EOL)
                    {
                        break;
                    }

                    posTemp++;
                    tokenTemp = _tokens[posTemp];
                }
            }

            token = tokenTemp;
            offset = 1 + (posTemp - _position);
        }

        public TokenStreamReader Rewind()
        {
            _position = 0;

            return this;
        }

        #endregion
    }
}
