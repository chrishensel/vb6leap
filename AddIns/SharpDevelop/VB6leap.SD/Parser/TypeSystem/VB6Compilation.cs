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
using ICSharpCode.NRefactory.Utils;
using VB6leap.SDAddin.Parser.Cache;

namespace VB6leap.SDAddin.Parser.TypeSystem
{
    class VB6Compilation : ICompilation
    {
        #region Fields

        private readonly IVbpProjectSymbolCache _parent;

        #endregion

        #region Constructors

        internal VB6Compilation(IVbpProjectSymbolCache parent)
        {
            _parent = parent;

            CacheManager = new CacheManager();
        }

        #endregion

        #region ICompilation Members

        public IList<IAssembly> Assemblies
        {
            get { return new List<IAssembly>() { MainAssembly }; }
        }

        public CacheManager CacheManager { get; private set; }

        public IType FindType(KnownTypeCode typeCode)
        {
            return null;
        }

        public INamespace GetNamespaceForExternAlias(string alias)
        {
            return this.RootNamespace;
        }

        public IAssembly MainAssembly
        {
            get { return _parent.Assembly; }
        }

        public StringComparer NameComparer
        {
            get { return StringComparer.OrdinalIgnoreCase; }
        }

        public IList<IAssembly> ReferencedAssemblies
        {
            get { return new List<IAssembly>(); }
        }

        public INamespace RootNamespace
        {
            get { return _parent.Namespace; }
        }

        public ISolutionSnapshot SolutionSnapshot
        {
            get { return null; }
        }

        public ITypeResolveContext TypeResolveContext
        {
            get { return _parent.CreateResolveContext(null); }
        }

        #endregion
    }
}
