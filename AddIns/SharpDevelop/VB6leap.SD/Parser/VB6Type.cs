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
using ICSharpCode.NRefactory.TypeSystem.Implementation;
using VB6leap.SDAddin.Parser.Members;

namespace VB6leap.SDAddin.Parser
{
    class VB6Type : AbstractType
    {
        #region Fields

        private string _name;
        private IUnresolvedTypeDefinition _unresolvedTypeDefinition;
        private List<IMember> _members;

        #endregion

        #region Properties

        public static VB6Type Variant
        {
            get { return new VB6Type("Variant"); }
        }

        #endregion

        #region Constructors

        private VB6Type(string name)
        {
            _name = name;
            _members = new List<IMember>();
        }

        private VB6Type(IUnresolvedTypeDefinition unresolvedTypeDefinition)
            : this(unresolvedTypeDefinition.Name)
        {
            _unresolvedTypeDefinition = unresolvedTypeDefinition;
        }

        #endregion

        #region Methods

        public static VB6Type GetResolved(IUnresolvedTypeDefinition typeDefinition)
        {
            VB6Type ret = new VB6Type(typeDefinition);

            /* Create resolved members.
             */
            foreach (var item in typeDefinition.Members)
            {
                IMember member = ConvertToMember(item);
                if (member != null)
                {
                    ret._members.Add(member);
                }
            }

            return ret;
        }

        private static IMember ConvertToMember(IUnresolvedMember input)
        {
            IUnresolvedField field = input as IUnresolvedField;
            if (field != null)
            {
                return new VB6Field(field);
            }

            IUnresolvedMethod method = input as IUnresolvedMethod;
            if (method != null)
            {
                return new VB6Method(method);
            }

            IUnresolvedProperty property = input as IUnresolvedProperty;
            if (property != null)
            {
                return new VB6Property(property);
            }

            return null;
        }

        public override IEnumerable<IMember> GetMembers(Predicate<IUnresolvedMember> filter = null, GetMemberOptions options = GetMemberOptions.None)
        {
            return _members;
        }

        public override IEnumerable<IField> GetFields(Predicate<IUnresolvedField> filter = null, GetMemberOptions options = GetMemberOptions.None)
        {
            return _members.OfType<VB6Field>();
        }

        public override IEnumerable<IMethod> GetMethods(Predicate<IUnresolvedMethod> filter = null, GetMemberOptions options = GetMemberOptions.None)
        {
            return _members.OfType<VB6Method>();
        }

        public override IEnumerable<IProperty> GetProperties(Predicate<IUnresolvedProperty> filter = null, GetMemberOptions options = GetMemberOptions.None)
        {
            return _members.OfType<VB6Property>();
        }

        public override IType DeclaringType
        {
            get { return this; }
        }

        public override bool Equals(IType other)
        {
            return other.Name == this.Name;
        }

        public override bool? IsReferenceType
        {
            get { return true; }
        }

        public override TypeKind Kind
        {
            get { return TypeKind.Class; }
        }

        public override string Name
        {
            get { return _name; }
        }

        public override string FullName
        {
            get { return _name; }
        }

        public override ITypeReference ToTypeReference()
        {
            return new VB6TypeReference();
        }

        public override ITypeDefinition GetDefinition()
        {
            if (_unresolvedTypeDefinition != null)
            {
                return new VB6TypeDefinition(_unresolvedTypeDefinition);
            }

            return null;
        }

        #endregion

    }
}
