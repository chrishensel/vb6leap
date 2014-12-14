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

namespace VB6leap.SDAddin.Parser.Members
{
    class VB6Field : VB6Member<IUnresolvedField>, IField
    {
        #region Constructors

        public VB6Field(IUnresolvedField underlyingEntity)
            : base(underlyingEntity)
        {
        }

        #endregion

        #region IField Members

        public bool IsFixed
        {
            get { return this.UnderlyingEntity.IsFixed; }
        }

        public bool IsReadOnly
        {
            get { return this.UnderlyingEntity.IsReadOnly; }
        }

        public bool IsVolatile
        {
            get { return this.UnderlyingEntity.IsVolatile; }
        }

        #endregion

        #region IEntity Members

        public EntityType EntityType
        {
            get { return EntityType.Field; }
        }

        #endregion

        #region ISymbol Members

        public new ISymbolReference ToReference()
        {
            return null;
        }

        #endregion

        #region IVariable Members

        public object ConstantValue
        {
            get { return this.UnderlyingEntity.ConstantValue; }
        }

        public bool IsConst
        {
            get { return this.UnderlyingEntity.IsConst; }
        }

        public IType Type
        {
            get { return null; }
        }

        #endregion
    }
}
