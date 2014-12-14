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
using ICSharpCode.SharpDevelop;
using ICSharpCode.SharpDevelop.Editor.Search;
using ICSharpCode.SharpDevelop.Parser;
using ICSharpCode.SharpDevelop.Project;
using VB6leap.SDAddin.Parser.Members;

namespace VB6leap.SDAddin.Parser
{
    class VB6Parser : IParser
    {
        #region IParser Members

        bool IParser.CanParse(string fileName)
        {
            /* TODO: It seems that this parser gets called even on non-VB6 files, which seems wrong.
             * This is annoying, since it can occur when you just try to open an XML file and then spams error dialogs!
             */
            return true;
        }

        ICompilation IParser.CreateCompilationForSingleFile(FileName fileName, IUnresolvedFile unresolvedFile)
        {
            throw new NotImplementedException();
        }

        void IParser.FindLocalReferences(ParseInformation parseInfo, ITextSource fileContent, IVariable variable, ICompilation compilation, Action<SearchResultMatch> callback, CancellationToken cancellationToken)
        {
        }

        ITextSource IParser.GetFileContent(FileName fileName)
        {
            return SD.FileService.GetFileContent(fileName);
        }

        ParseInformation IParser.Parse(FileName fileName, ITextSource fileContent, bool fullParseInformationRequested, IProject parentProject, CancellationToken cancellationToken)
        {
            IVbpProject project = SD.ProjectService.FindProjectContainingFile(fileName) as IVbpProject;
            return project.SymbolCache.GetAndReparse(fileName, fileContent);
        }

        ResolveResult IParser.Resolve(ParseInformation parseInfo, TextLocation location, ICompilation compilation, CancellationToken cancellationToken)
        {
            VB6ParseInformation vpi = (VB6ParseInformation)parseInfo;
            IUnresolvedMember umember = vpi.UnresolvedFile.GetMember(location);
            if (umember != null)
            {
                IMember member = ConvertToMember(umember);
                if (member != null)
                {
                    return new MemberResolveResult(null, member);
                }
            }

            return null;
        }

        private IMember ConvertToMember(IUnresolvedMember input)
        {
            IUnresolvedField field = input as IUnresolvedField;
            if (field != null)
            {
                return new VB6Field(field);
            }

            return new VB6Member<IUnresolvedMember>(input);
        }

        ICodeContext IParser.ResolveContext(ParseInformation parseInfo, TextLocation location, ICompilation compilation, CancellationToken cancellationToken)
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
