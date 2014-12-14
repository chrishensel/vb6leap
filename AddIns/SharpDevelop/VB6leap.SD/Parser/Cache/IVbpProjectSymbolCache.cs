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

using ICSharpCode.Core;
using ICSharpCode.NRefactory.Editor;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.SharpDevelop.Parser;

namespace VB6leap.SDAddin.Parser.Cache
{
    /// <summary>
    /// Defines members for a type that represents an entire VBP project, to appear as an assembly.
    /// </summary>
    interface IVbpProjectSymbolCache : ICompilationProvider
    {
        IAssembly Assembly { get; }
        INamespace Namespace { get; }

        ITypeResolveContext CreateResolveContext(ITypeResolveContext parentContext);
        IType GetTypeByName(string name);
        ParseInformation GetAndReparse(FileName fileName, ITextSource fileContent);
    }
}
