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
using VB6leap.Vbp.Project;

namespace VB6leap.SDAddin.Parser
{
    abstract class VB6UnresolvedEntityBase : IUnresolvedEntity
    {
        #region Properties

        internal IVbpProject VbpProject { get; private set; }
        internal IVbProject Project
        {
            get { return VbpProject.GetOwnedProject(); }
        }

        #endregion

        #region Constructors

        private VB6UnresolvedEntityBase()
        {
            this.Attributes = new List<IUnresolvedAttribute>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VB6UnresolvedEntityBase"/> class.
        /// </summary>
        /// <param name="file">The file that is the source of this entity.</param>
        /// <param name="typeDefinition">The <see cref="IUnresolvedTypeDefinition"/> that this entity is a child of. May be null.</param>
        protected VB6UnresolvedEntityBase(IUnresolvedFile file, IUnresolvedTypeDefinition typeDefinition)
            : this()
        {
            this.UnresolvedFile = file;

            VB6UnresolvedFile vb6File = (VB6UnresolvedFile)file;
            this.VbpProject = vb6File.Project;


            this.DeclaringTypeDefinition = typeDefinition;
        }

        #endregion

        #region IUnresolvedEntity Members

        public IList<IUnresolvedAttribute> Attributes { get; private set; }

        public abstract DomRegion BodyRegion { get; }

        public IUnresolvedTypeDefinition DeclaringTypeDefinition { get; protected set; }

        public bool IsAbstract
        {
            get { return false; }
        }

        /// <summary>
        /// Always returns false. There is no sealing in VB6.
        /// </summary>
        public bool IsSealed
        {
            get { return false; }
        }

        /// <summary>
        /// Always returns false. There is no shadowing in VB6.
        /// </summary>
        public bool IsShadowing
        {
            get { return false; }
        }

        public virtual bool IsStatic
        {
            get { return false; }
        }

        public bool IsSynthetic
        {
            get { return false; }
        }

        public abstract DomRegion Region { get; }

        public abstract SymbolKind SymbolKind { get; }

        public IUnresolvedFile UnresolvedFile { get; private set; }

        #endregion

        #region INamedElement Members

        public string FullName { get; protected set; }

        public string Name { get; protected set; }

        public string Namespace { get; protected set; }

        public string ReflectionName { get; protected set; }

        #endregion

        #region IHasAccessibility Members

        public Accessibility Accessibility { get; protected set; }

        public bool IsInternal
        {
            get { return Accessibility == Accessibility.Internal; }
        }

        public bool IsPrivate
        {
            get { return Accessibility == Accessibility.Private; }
        }

        public bool IsProtected
        {
            get { return Accessibility == Accessibility.Protected; }
        }

        public bool IsProtectedAndInternal
        {
            get { return Accessibility == Accessibility.ProtectedAndInternal; }
        }

        public bool IsProtectedOrInternal
        {
            get { return Accessibility == Accessibility.ProtectedOrInternal; }
        }

        public bool IsPublic
        {
            get { return Accessibility == Accessibility.Public; }
        }

        #endregion
    }
}
