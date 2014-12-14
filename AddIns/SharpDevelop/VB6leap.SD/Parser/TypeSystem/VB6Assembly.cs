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

namespace VB6leap.SDAddin.Parser.TypeSystem
{
    class VB6Assembly : IAssembly
    {
        #region IAssembly Members

        public IList<IAttribute> AssemblyAttributes
        {
            get { return new List<IAttribute>(); }
        }

        public string AssemblyName { get; set; }

        public string FullAssemblyName { get; set; }

        public ITypeDefinition GetTypeDefinition(TopLevelTypeName topLevelTypeName)
        {
            throw new NotImplementedException();
        }

        public bool InternalsVisibleTo(IAssembly assembly)
        {
            return false;
        }

        public bool IsMainAssembly
        {
            get { return true; }
        }

        public IList<IAttribute> ModuleAttributes
        {
            get { return new List<IAttribute>(); }
        }

        public INamespace RootNamespace { get; set; }

        public IEnumerable<ITypeDefinition> TopLevelTypeDefinitions
        {
            get { throw new NotImplementedException(); }
        }

        public IUnresolvedAssembly UnresolvedAssembly
        {
            get { throw new NotImplementedException(); }
        }

        #endregion

        #region ICompilationProvider Members

        public ICompilation Compilation { get; set; }

        #endregion
    }
}
