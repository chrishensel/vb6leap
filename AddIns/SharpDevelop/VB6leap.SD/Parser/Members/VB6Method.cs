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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.NRefactory.TypeSystem;

namespace VB6leap.SDAddin.Parser.Members
{
    class VB6Method : VB6Member<IUnresolvedMethod>, IMethod
    {
        #region Constructors

        public VB6Method(IUnresolvedMethod underlyingEntity)
            : base(underlyingEntity)
        {
        }

        #endregion

        #region IMethod Members

        public IMember AccessorOwner
        {
            get { return null; }
        }

        public bool HasBody
        {
            get { return this.UnderlyingEntity.HasBody; }
        }

        public bool IsAccessor
        {
            get { return false; }
        }

        public bool IsAsync
        {
            get { return this.UnderlyingEntity.IsAsync; }
        }

        public bool IsConstructor
        {
            get { return this.UnderlyingEntity.IsConstructor; }
        }

        public bool IsDestructor
        {
            get { return this.UnderlyingEntity.IsDestructor; }
        }

        public bool IsExtensionMethod
        {
            get { return false; }
        }

        public bool IsOperator
        {
            get { return this.UnderlyingEntity.IsOperator; }
        }

        public bool IsParameterized
        {
            get { return false; }
        }

        public bool IsPartial
        {
            get { return this.UnderlyingEntity.IsPartial; }
        }

        public IList<IUnresolvedMethod> Parts
        {
            get { return null; }
        }

        public IMethod ReducedFrom
        {
            get { return null; }
        }

        public IList<IAttribute> ReturnTypeAttributes
        {
            get { return null; }
        }

        public new IMethod Specialize(TypeParameterSubstitution substitution)
        {
            return null;
        }

        public IList<IType> TypeArguments
        {
            get { return null; }
        }

        public IList<ITypeParameter> TypeParameters
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
