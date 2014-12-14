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
using VB6leap.Vbp.Reflection.Members;

namespace VB6leap.SDAddin.Parser
{
    class VB6UnresolvedMethod : VB6UnresolvedMemberBase, IUnresolvedMethod
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="VB6UnresolvedMethod"/> class.
        /// </summary>
        /// <param name="method">The instance of <see cref="IVbMethod"/> that is the source of this entity.</param>
        /// <param name="file">The file that is the source of this entity.</param>
        /// <param name="typeReference">The <see cref="IUnresolvedTypeReference"/> that this member is a child of. May be null.</param>
        /// <param name="typeDefinition">The <see cref="IUnresolvedTypeDefinition"/> that this entity is a child of. May be null.</param>
        internal VB6UnresolvedMethod(IVbMethod method, IUnresolvedFile file, ITypeReference typeReference, IUnresolvedTypeDefinition typeDefinition)
            : base(method, file, typeReference, typeDefinition)
        {
            if (method == null)
            {
                throw new ArgumentNullException("method");
            }
        }

        #endregion

        #region Methods

        protected override DomRegion GetRegion()
        {
            IVbMethod method = (IVbMethod)this.Member;

            int startLine = method.Location.Line;
            int startCol = method.Location.Column;
            int endLine = startLine;
            int endCol = startCol;

            if (method.EndStatementLocation != null)
            {
                endLine = method.EndStatementLocation.Line;
                endCol = method.EndStatementLocation.Column;
            }

            return new DomRegion(startLine, startCol, endLine, endCol);
        }

        public override SymbolKind SymbolKind
        {
            get { return ICSharpCode.NRefactory.TypeSystem.SymbolKind.Method; }
        }

        #endregion

        #region IUnresolvedMethod Members

        public IUnresolvedMember AccessorOwner
        {
            get { return this; }
        }

        public bool HasBody
        {
            get { return true; }
        }

        public bool IsAsync
        {
            get { return false; }
        }

        public bool IsConstructor
        {
            get { return false; }
        }

        public bool IsDestructor
        {
            get { return false; }
        }

        public bool IsOperator
        {
            get { return false; }
        }

        public bool IsPartial
        {
            get { return false; }
        }

        public bool IsPartialMethodDeclaration
        {
            get { return false; }
        }

        public bool IsPartialMethodImplementation
        {
            get { return false; }
        }

        public new IMethod Resolve(ITypeResolveContext context)
        {
            return null;
        }

        public IList<IUnresolvedAttribute> ReturnTypeAttributes
        {
            get { return new List<IUnresolvedAttribute>(); }
        }

        public IList<IUnresolvedTypeParameter> TypeParameters
        {
            get { return new List<IUnresolvedTypeParameter>(); }
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
