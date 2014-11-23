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
using ICSharpCode.AvalonEdit.Folding;
using ICSharpCode.NRefactory.Editor;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.SharpDevelop.Parser;

namespace VB6leap.SDAddin.Parser
{
    class VB6ParseInformation : ParseInformation
    {
        #region Properties

        public override bool SupportsFolding
        {
            get { return true; }
        }

        #endregion

        #region Constructors

        internal VB6ParseInformation(IUnresolvedFile unresolvedFile, ITextSourceVersion parsedVersion, bool isFullParseInformation)
            : base(unresolvedFile, parsedVersion, isFullParseInformation)
        {

        }

        #endregion

        #region Methods

        public override IEnumerable<NewFolding> GetFoldings(IDocument document, out int firstErrorOffset)
        {
            firstErrorOffset = 0;

            VB6UnresolvedFile file = (VB6UnresolvedFile)this.UnresolvedFile;

            List<NewFolding> foldings = new List<NewFolding>();

            /* Definitely fold the headers, since they annoy the most.
             */
            foldings.Add(new NewFolding(0, file.PartitionedFile.Preamble.Length - 2) { DefaultClosed = true, IsDefinition = true, Name = "Header" });

            /* Not sure if this is needed. We keep it in, but may be removed in future.
             */
            foldings.AddRange(base.GetFoldings(document, out firstErrorOffset));

            return foldings;
        }

        #endregion
    }
}
