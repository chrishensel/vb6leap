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

namespace VB6leap.SDAddin.Parser.Members
{
    class VB6Property : VB6Member<IUnresolvedProperty>, IProperty
    {
        #region Constructors

        public VB6Property(IUnresolvedProperty underlyingEntity)
            : base(underlyingEntity)
        {
        }

        #endregion

        #region IProperty Members

        public bool CanGet
        {
            get { return this.UnderlyingEntity.CanGet; }
        }

        public bool CanSet
        {
            get { return this.UnderlyingEntity.CanSet; }
        }

        public IMethod Getter
        {
            get { return null; }
        }

        public bool IsIndexer
        {
            get { return this.UnderlyingEntity.IsIndexer; }
        }

        public IMethod Setter
        {
            get { return null; }
        }

        #endregion

        #region IParameterizedMember Members

        public IList<IParameter> Parameters
        {
            get { return null; }
        }

        #endregion

        #region IEntity Members


        public EntityType EntityType
        {
            get { throw new NotImplementedException(); }
        }

        #endregion

        #region ISymbol Members


        public new ISymbolReference ToReference()
        {
            return null;
        }

        #endregion
    }
}
