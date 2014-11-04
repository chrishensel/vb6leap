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

using ICSharpCode.NRefactory.TypeSystem;
using VB6leap.Vbp.Reflection.Members;

namespace VB6leap.SDAddin.Parser
{
    class VB6UnresolvedField : VB6UnresolvedMemberBase, IUnresolvedField
    {
        #region Properties

        public override SymbolKind SymbolKind
        {
            get { return ICSharpCode.NRefactory.TypeSystem.SymbolKind.Field; }
        }

        #endregion

        #region Constructors

        internal VB6UnresolvedField(IVbField field, IUnresolvedFile file, ITypeReference typeReference, IUnresolvedTypeDefinition typeDefinition)
            : base(field, file, typeReference, typeDefinition)
        {
            this.IsConst = field.IsConstant;
        }

        #endregion

        #region IUnresolvedField Members

        public IConstantValue ConstantValue
        {
            get { return null; }
        }

        public bool IsConst { get; private set; }

        public bool IsFixed
        {
            get { return false; }
        }

        public bool IsReadOnly
        {
            get { return this.IsConst; }
        }

        public bool IsVolatile
        {
            get { return false; }
        }

        public new IField Resolve(ITypeResolveContext context)
        {
            return null;
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
