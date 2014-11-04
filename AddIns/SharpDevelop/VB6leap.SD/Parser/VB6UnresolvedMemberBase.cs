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
using VB6leap.Vbp.Project;
using VB6leap.Vbp.Reflection.Members;
using VB6leap.Vbp.Reflection.Modules;
using VB6leap.Vbp.Reflection.Source;

namespace VB6leap.SD.Parser
{
    abstract class VB6UnresolvedMemberBase : VB6UnresolvedEntityBase, IUnresolvedMember
    {
        #region Properties

        protected IVbMember Member { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="VB6UnresolvedMemberBase"/> class.
        /// </summary>
        /// <param name="member">The instance of <see cref="IVbMember"/> that is the source of this entity.</param>
        /// <param name="file">The file that is the source of this entity.</param>
        /// <param name="typeReference">The <see cref="IUnresolvedTypeReference"/> that this member is a child of. May be null.</param>
        /// <param name="typeDefinition">The <see cref="IUnresolvedTypeDefinition"/> that this entity is a child of. May be null.</param>
        protected VB6UnresolvedMemberBase(IVbMember member, IUnresolvedFile file, ITypeReference typeReference, IUnresolvedTypeDefinition typeDefinition)
            : base(file, typeDefinition)
        {
            if (member == null)
            {
                throw new ArgumentNullException("member");
            }

            this.Member = member;

            this.Name = member.Name;
            this.Accessibility = member.ToAccessibility();

            this.DeclaringTypeReference = typeReference;
        }

        #endregion

        #region Methods
        
        protected virtual DomRegion GetRegion()
        {
            return this.Member.Location.ToDomRegion();
        }

        public override DomRegion BodyRegion
        {
            get { return GetRegion(); }
        }

        public override DomRegion Region
        {
            get { return GetRegion(); }
        }

        #endregion

        #region IUnresolvedMember Members

        public IMember CreateResolved(ITypeResolveContext context)
        {
            return null;
        }

        public IList<IMemberReference> ExplicitInterfaceImplementations
        {
            get { return new List<IMemberReference>(); }
        }

        public bool IsExplicitInterfaceImplementation
        {
            get { return false; }
        }

        /// <summary>
        /// Always false. There is no overriding in VB6.
        /// </summary>
        public bool IsOverridable
        {
            get { return false; }
        }

        /// <summary>
        /// Always false. There is no overriding in VB6.
        /// </summary>
        public bool IsOverride
        {
            get { return false; }
        }

        /// <summary>
        /// Always false. There is no overriding in VB6.
        /// </summary>
        public bool IsVirtual
        {
            get { return false; }
        }

        public IMember Resolve(ITypeResolveContext context)
        {
            return null;
        }

        public ITypeReference ReturnType
        {
            get { return KnownTypeReference.Object; }
        }

        #endregion

        #region IMemberReference Members

        public ITypeReference DeclaringTypeReference { get; protected set; }

        #endregion

        #region ISymbolReference Members

        ISymbol ISymbolReference.Resolve(ITypeResolveContext context)
        {
            return null;
        }

        #endregion
    }
}
