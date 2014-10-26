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
using System.Collections.Generic;
using System.Threading;
using ICSharpCode.Core;
using ICSharpCode.NRefactory;
using ICSharpCode.NRefactory.Editor;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.SharpDevelop.Editor.Search;
using ICSharpCode.SharpDevelop.Parser;
using ICSharpCode.SharpDevelop.Project;

namespace VB6leap.SD.Parser
{
    class VB6Parser : IParser
    {
        #region IParser Members

        bool IParser.CanParse(string fileName)
        {
            return true;
        }

        ICompilation IParser.CreateCompilationForSingleFile(FileName fileName, IUnresolvedFile unresolvedFile)
        {
            throw new NotImplementedException();
        }

        void IParser.FindLocalReferences(ParseInformation parseInfo, ITextSource fileContent, IVariable variable, ICompilation compilation, Action<SearchResultMatch> callback, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        ITextSource IParser.GetFileContent(FileName fileName)
        {
            return ICSharpCode.SharpDevelop.SD.FileService.GetFileContent(fileName);
        }

        ParseInformation IParser.Parse(FileName fileName, ITextSource fileContent, bool fullParseInformationRequested, IProject parentProject, CancellationToken cancellationToken)
        {
            IVbpProject project = (IVbpProject)parentProject;
            IUnresolvedFile file = new VB6UnresolvedFile(fileName, project);

            return new ParseInformation(file, fileContent.Version, fullParseInformationRequested);
        }

        ResolveResult IParser.Resolve(ParseInformation parseInfo, TextLocation location, ICompilation compilation, CancellationToken cancellationToken)
        {
            return null;
        }

        ICodeContext IParser.ResolveContext(ParseInformation parseInfo, ICSharpCode.NRefactory.TextLocation location, ICompilation compilation, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        ResolveResult IParser.ResolveSnippet(ParseInformation parseInfo, TextLocation location, string codeSnippet, ICompilation compilation, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        IReadOnlyList<string> IParser.TaskListTokens { get; set; }

        #endregion
    }
}
