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
using ICSharpCode.NRefactory.TypeSystem;

namespace VB6leap.SDAddin.Parser.Members
{
    class VB6TypeDefinition : VB6Member<IUnresolvedTypeDefinition>, ITypeDefinition
    {
        #region Fields

        private IType _underlyingType;

        #endregion

        #region Constructors

        public VB6TypeDefinition(IUnresolvedTypeDefinition underlyingEntity)
            : base(underlyingEntity)
        {
            _underlyingType = GetVbpProject().SymbolCache.GetTypeByName(this.UnderlyingEntity.Name);
        }

        #endregion

        #region ITypeDefinition Members

        public IType EnumUnderlyingType
        {
            get { return _underlyingType; }
        }

        public IEnumerable<IEvent> Events
        {
            get { return _underlyingType.GetEvents(); }
        }

        public IEnumerable<IField> Fields
        {
            get { return _underlyingType.GetFields(); }
        }

        public FullTypeName FullTypeName
        {
            get { return this.UnderlyingEntity.FullTypeName; }
        }

        public IList<IMember> GetInterfaceImplementation(IList<IMember> interfaceMembers)
        {
            return null;
        }

        public IMember GetInterfaceImplementation(IMember interfaceMember)
        {
            return null;
        }

        public bool HasExtensionMethods
        {
            get { return this.UnderlyingEntity.HasExtensionMethods.Value; }
        }

        public bool IsPartial
        {
            get { return this.UnderlyingEntity.IsPartial; }
        }

        public KnownTypeCode KnownTypeCode
        {
            get { return ICSharpCode.NRefactory.TypeSystem.KnownTypeCode.None; }
        }

        public IList<IMember> Members
        {
            get { return _underlyingType.GetMembers().ToList(); }
        }

        public IEnumerable<IMethod> Methods
        {
            get { return _underlyingType.GetMethods(); }
        }

        public IList<ITypeDefinition> NestedTypes
        {
            get { throw new NotImplementedException(); }
        }

        public IList<IUnresolvedTypeDefinition> Parts
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<IProperty> Properties
        {
            get { return _underlyingType.GetProperties(); }
        }

        public IList<ITypeParameter> TypeParameters
        {
            get { throw new NotImplementedException(); }
        }

        #endregion

        #region IType Members

        public IType AcceptVisitor(TypeVisitor visitor)
        {
            return _underlyingType.AcceptVisitor(visitor);
        }

        public IEnumerable<IType> DirectBaseTypes
        {
            get { return _underlyingType.DirectBaseTypes; }
        }

        public IEnumerable<IMethod> GetAccessors(Predicate<IUnresolvedMethod> filter = null, GetMemberOptions options = GetMemberOptions.None)
        {
            return _underlyingType.GetAccessors(filter, options);
        }

        public IEnumerable<IMethod> GetConstructors(Predicate<IUnresolvedMethod> filter = null, GetMemberOptions options = GetMemberOptions.IgnoreInheritedMembers)
        {
            return _underlyingType.GetConstructors(filter, options);
        }

        public ITypeDefinition GetDefinition()
        {
            return _underlyingType.GetDefinition();
        }

        public IEnumerable<IEvent> GetEvents(Predicate<IUnresolvedEvent> filter = null, GetMemberOptions options = GetMemberOptions.None)
        {
            return _underlyingType.GetEvents(filter, options);
        }

        public IEnumerable<IField> GetFields(Predicate<IUnresolvedField> filter = null, GetMemberOptions options = GetMemberOptions.None)
        {
            return _underlyingType.GetFields(filter, options);
        }

        public IEnumerable<IMember> GetMembers(Predicate<IUnresolvedMember> filter = null, GetMemberOptions options = GetMemberOptions.None)
        {
            return _underlyingType.GetMembers(filter, options);
        }

        public IEnumerable<IMethod> GetMethods(IList<IType> typeArguments, Predicate<IUnresolvedMethod> filter = null, GetMemberOptions options = GetMemberOptions.None)
        {
            return _underlyingType.GetMethods(typeArguments, filter, options);
        }

        public IEnumerable<IMethod> GetMethods(Predicate<IUnresolvedMethod> filter = null, GetMemberOptions options = GetMemberOptions.None)
        {
            return _underlyingType.GetMethods(filter, options);
        }

        public IEnumerable<IType> GetNestedTypes(IList<IType> typeArguments, Predicate<ITypeDefinition> filter = null, GetMemberOptions options = GetMemberOptions.None)
        {
            return _underlyingType.GetNestedTypes(typeArguments, filter, options);
        }

        public IEnumerable<IType> GetNestedTypes(Predicate<ITypeDefinition> filter = null, GetMemberOptions options = GetMemberOptions.None)
        {
            return _underlyingType.GetNestedTypes(filter, options);
        }

        public IEnumerable<IProperty> GetProperties(Predicate<IUnresolvedProperty> filter = null, GetMemberOptions options = GetMemberOptions.None)
        {
            return _underlyingType.GetProperties(filter, options);
        }

        public TypeParameterSubstitution GetSubstitution(IList<IType> methodTypeArguments)
        {
            return _underlyingType.GetSubstitution(methodTypeArguments);
        }

        public TypeParameterSubstitution GetSubstitution()
        {
            return _underlyingType.GetSubstitution();
        }

        public bool IsParameterized
        {
            get { return false; }
        }

        public bool? IsReferenceType
        {
            get { return true; }
        }

        public TypeKind Kind
        {
            get { return this.UnderlyingEntity.Kind; }
        }

        public ITypeReference ToTypeReference()
        {
            return _underlyingType.ToTypeReference();
        }

        public IList<IType> TypeArguments
        {
            get { return _underlyingType.TypeArguments; }
        }

        public int TypeParameterCount
        {
            get { return _underlyingType.TypeParameterCount; }
        }

        public IType VisitChildren(TypeVisitor visitor)
        {
            return _underlyingType.VisitChildren(visitor);
        }

        #endregion

        #region IEquatable<IType> Members

        public bool Equals(IType other)
        {
            return _underlyingType.Equals(other);
        }

        #endregion

        #region IEntity Members


        public EntityType EntityType
        {
            get { return ICSharpCode.NRefactory.TypeSystem.EntityType.TypeDefinition; }
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
