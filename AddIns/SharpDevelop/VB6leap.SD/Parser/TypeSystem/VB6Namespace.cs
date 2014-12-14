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
using ICSharpCode.NRefactory.TypeSystem;
using VB6leap.Vbp.Project;

namespace VB6leap.SDAddin.Parser.TypeSystem
{
    class VB6Namespace : INamespace
    {
        #region Fields

        private readonly string _name;

        #endregion

        #region Constructors

        public VB6Namespace(IVbProject parent)
        {
            _name = parent.Properties.Name;
        }

        #endregion

        #region INamespace Members

        public IEnumerable<INamespace> ChildNamespaces
        {
            get { return null; }
        }

        public IEnumerable<IAssembly> ContributingAssemblies
        {
            get { return null; }
        }

        public string ExternAlias
        {
            get { return "global"; }
        }

        public string FullName
        {
            get { return _name; }
        }

        public INamespace GetChildNamespace(string name)
        {
            return null;
        }

        public ITypeDefinition GetTypeDefinition(string name, int typeParameterCount)
        {
            throw new NotImplementedException();
        }

        public string Name
        {
            get { return _name; }
        }

        public INamespace ParentNamespace
        {
            get { return null; }
        }

        public IEnumerable<ITypeDefinition> Types
        {
            get { return new List<ITypeDefinition>(); }
        }

        #endregion

        #region ISymbol Members

        public SymbolKind SymbolKind
        {
            get { return ICSharpCode.NRefactory.TypeSystem.SymbolKind.Namespace; }
        }

        public ISymbolReference ToReference()
        {
            return null;
        }

        #endregion

        #region ICompilationProvider Members

        public ICompilation Compilation { get; set; }

        #endregion
    }
}
