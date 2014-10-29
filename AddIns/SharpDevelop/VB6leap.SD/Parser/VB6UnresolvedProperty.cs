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
using ICSharpCode.NRefactory.TypeSystem;
using VB6leap.Vbp.Reflection.Members;

namespace VB6leap.SD.Parser
{
    class VB6UnresolvedProperty : VB6UnresolvedMemberBase, IUnresolvedProperty
    {
        #region Properties

        public override SymbolKind SymbolKind
        {
            get { return ICSharpCode.NRefactory.TypeSystem.SymbolKind.Property; }
        }

        #endregion

        #region Constructors

        internal VB6UnresolvedProperty(IVbProperty property, IUnresolvedFile file, ITypeReference typeReference, IUnresolvedTypeDefinition typeDefinition)
            : base(property, file, typeReference, typeDefinition)
        {
            this.CanGet = (property.Accessor == VbPropertyAccessor.Get);
            this.CanSet = !this.CanGet;
        }

        #endregion

        #region IUnresolvedProperty Members

        public bool CanGet { get; private set; }

        public bool CanSet { get; private set; }

        public IUnresolvedMethod Getter
        {
            get { return null; }
        }

        public bool IsIndexer
        {
            get { return false; }
        }

        public new IProperty Resolve(ITypeResolveContext context)
        {
            return null;
        }

        public IUnresolvedMethod Setter
        {
            get { return null; }
        }

        #endregion

        #region IUnresolvedParameterizedMember Members

        public IList<IUnresolvedParameter> Parameters
        {
            get { return new List<IUnresolvedParameter>(); }
        }

        #endregion

        #region ISymbolReference Members

        ISymbol ISymbolReference.Resolve(ITypeResolveContext context)
        {
            return null;
        }

        #endregion
    }
}
