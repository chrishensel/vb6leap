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
using ICSharpCode.NRefactory.Documentation;
using ICSharpCode.NRefactory.TypeSystem;

namespace VB6leap.SDAddin.Parser.Members
{
    /// <summary>
    /// Represents the base class for any member that doesn't have a specific implementation.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class VB6Member<T> : IMember where T : IUnresolvedEntity
    {
        #region Properties

        protected T UnderlyingEntity { get; private set; }

        #endregion

        #region Constructors

        public VB6Member(T underlyingEntity)
        {
            this.UnderlyingEntity = underlyingEntity;
        }

        #endregion

        #region IMember Members

        public IList<IMember> ImplementedInterfaceMembers
        {
            get { return new List<IMember>(); }
        }

        public bool IsExplicitInterfaceImplementation
        {
            get { return false; }
        }

        public bool IsOverridable
        {
            get { return false; }
        }

        public bool IsOverride
        {
            get { return false; }
        }

        public bool IsVirtual
        {
            get { return false; }
        }

        public IMember MemberDefinition
        {
            get { return null; }
        }

        public IType ReturnType
        {
            get { return new VB6Type("Variant"); }
        }

        public IMember Specialize(TypeParameterSubstitution substitution)
        {
            return null;
        }

        public TypeParameterSubstitution Substitution
        {
            get { return null; }
        }

        public IMemberReference ToMemberReference()
        {
            return null;
        }

        public IMemberReference ToReference()
        {
            return null;
        }

        public IUnresolvedMember UnresolvedMember
        {
            get { return (IUnresolvedMember)this.UnderlyingEntity; }
        }

        #endregion

        #region IEntity Members

        public IList<IAttribute> Attributes
        {
            get { return new List<IAttribute>(); }
        }

        public DomRegion BodyRegion
        {
            get { return this.UnresolvedMember.BodyRegion; }
        }

        public IType DeclaringType
        {
            get { return new VB6Type(this.UnresolvedMember.DeclaringTypeDefinition.Name); }
        }

        public ITypeDefinition DeclaringTypeDefinition
        {
            get { return null; }
        }

        public DocumentationComment Documentation
        {
            get { return new DocumentationComment(GetXmlDocumentation(), new SimpleTypeResolveContext(this)); }
        }

        protected virtual string GetXmlDocumentation()
        {
            /* Try to access the member directly and output its VB declaration.
             */
            VB6UnresolvedMemberBase source = this.UnderlyingEntity as VB6UnresolvedMemberBase;
            if (source != null)
            {
                string doc = "<summary>{0}</summary>";
                doc = string.Format(doc, source.Member.ToVbDeclaration());

                return doc;
            }

            return string.Format("<summary>{0}</summary>", this.UnresolvedMember.Name);
        }

        EntityType IEntity.EntityType
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsAbstract
        {
            get { return this.UnresolvedMember.IsAbstract; }
        }

        public bool IsSealed
        {
            get { return this.UnresolvedMember.IsSealed; }
        }

        public bool IsShadowing
        {
            get { return this.UnresolvedMember.IsShadowing; }
        }

        public bool IsStatic
        {
            get { return this.UnresolvedMember.IsStatic; }
        }

        public bool IsSynthetic
        {
            get { return this.UnresolvedMember.IsSynthetic; }
        }

        public string Name
        {
            get { return this.UnresolvedMember.Name; }
        }

        public IAssembly ParentAssembly
        {
            get { return null; }
        }

        public DomRegion Region
        {
            get { return this.UnresolvedMember.Region; }
        }

        #endregion

        #region ISymbol Members

        public SymbolKind SymbolKind
        {
            get { return this.UnresolvedMember.SymbolKind; }
        }

        ISymbolReference ISymbol.ToReference()
        {
            return null;
        }

        #endregion

        #region ICompilationProvider Members

        public ICompilation Compilation
        {
            get { return null; }
        }

        #endregion

        #region INamedElement Members

        public string FullName
        {
            get { return this.UnresolvedMember.FullName; }
        }

        public string Namespace
        {
            get { return this.UnresolvedMember.Namespace; }
        }

        public string ReflectionName
        {
            get { return this.UnresolvedMember.ReflectionName; }
        }

        #endregion

        #region IHasAccessibility Members

        public Accessibility Accessibility
        {
            get { return this.UnresolvedMember.Accessibility; }
        }

        public bool IsInternal
        {
            get { return this.UnresolvedMember.IsInternal; }
        }

        public bool IsPrivate
        {
            get { return this.UnresolvedMember.IsPrivate; }
        }

        public bool IsProtected
        {
            get { return this.UnresolvedMember.IsProtected; }
        }

        public bool IsProtectedAndInternal
        {
            get { return this.UnresolvedMember.IsProtectedAndInternal; }
        }

        public bool IsProtectedOrInternal
        {
            get { return this.UnresolvedMember.IsProtectedOrInternal; }
        }

        public bool IsPublic
        {
            get { return this.UnresolvedMember.IsPublic; }
        }

        #endregion
    }
}
