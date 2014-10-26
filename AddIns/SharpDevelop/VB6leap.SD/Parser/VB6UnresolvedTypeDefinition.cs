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
using VB6leap.Vbp.Reflection.Modules;

namespace VB6leap.SD.Parser
{
    class VB6UnresolvedTypeDefinition : IUnresolvedTypeDefinition
    {
        #region Fields

        private readonly IUnresolvedFile _parentFile;

        private readonly IVbModule _module;
        private readonly IVbProject _project;

        private List<IUnresolvedAttribute> _attributes;
        private List<IUnresolvedEvent> _events;
        private List<IUnresolvedField> _fields;
        private List<IUnresolvedProperty> _properties;
        private List<IUnresolvedMethod> _methods;
        private List<IUnresolvedMember> _members;

        #endregion

        #region Constructors

        internal VB6UnresolvedTypeDefinition(IUnresolvedFile parent, IVbModule module, IVbpProject project)
        {
            _parentFile = parent;
            _module = module;
            if (project != null)
            {
                _project = project.GetOwnedProject();
            }

            _attributes = new List<IUnresolvedAttribute>();
            _events = new List<IUnresolvedEvent>();
            _fields = new List<IUnresolvedField>();
            _properties = new List<IUnresolvedProperty>();
            _methods = new List<IUnresolvedMethod>();
            _members = new List<IUnresolvedMember>();
        }

        #endregion

        #region Methods

        private string GetName(bool fullName)
        {
            if (fullName)
            {
                return "(Implicit project scope)" + "." + _module.Name;
            }
            else
            {
                return _module.Name;
            }
        }

        #endregion

        #region IUnresolvedTypeDefinition Members

        bool IUnresolvedTypeDefinition.AddDefaultConstructorIfRequired
        {
            get { return false; }
        }

        IList<ITypeReference> IUnresolvedTypeDefinition.BaseTypes
        {
            get { return new List<ITypeReference>(); }
        }

        ITypeResolveContext IUnresolvedTypeDefinition.CreateResolveContext(ITypeResolveContext parentContext)
        {
            return parentContext;
        }

        IEnumerable<IUnresolvedEvent> IUnresolvedTypeDefinition.Events
        {
            get { return _events; }
        }

        IEnumerable<IUnresolvedField> IUnresolvedTypeDefinition.Fields
        {
            get { return _fields; }
        }

        FullTypeName IUnresolvedTypeDefinition.FullTypeName
        {
            get { return new FullTypeName(GetName(true)); }
        }

        bool? IUnresolvedTypeDefinition.HasExtensionMethods
        {
            get { return false; }
        }

        bool IUnresolvedTypeDefinition.IsPartial
        {
            get { return false; }
        }

        TypeKind IUnresolvedTypeDefinition.Kind
        {
            get { return TypeKind.Class; }
        }

        IList<IUnresolvedMember> IUnresolvedTypeDefinition.Members
        {
            get { return _members; }
        }

        IEnumerable<IUnresolvedMethod> IUnresolvedTypeDefinition.Methods
        {
            get { return _methods; }
        }

        IList<IUnresolvedTypeDefinition> IUnresolvedTypeDefinition.NestedTypes
        {
            get { return new List<IUnresolvedTypeDefinition>(); }
        }

        IEnumerable<IUnresolvedProperty> IUnresolvedTypeDefinition.Properties
        {
            get { return _properties; }
        }

        IType IUnresolvedTypeDefinition.Resolve(ITypeResolveContext context)
        {
            return null;
        }

        IList<IUnresolvedTypeParameter> IUnresolvedTypeDefinition.TypeParameters
        {
            get { return new List<IUnresolvedTypeParameter>(); }
        }

        #endregion

        #region ITypeReference Members

        IType ITypeReference.Resolve(ITypeResolveContext context)
        {
            return null;
        }

        #endregion

        #region IUnresolvedEntity Members

        IList<IUnresolvedAttribute> IUnresolvedEntity.Attributes
        {
            get { return _attributes; }
        }

        DomRegion IUnresolvedEntity.BodyRegion
        {
            get { return DomRegion.Empty; }
        }

        IUnresolvedTypeDefinition IUnresolvedEntity.DeclaringTypeDefinition
        {
            get { return this; }
        }

        bool IUnresolvedEntity.IsAbstract
        {
            get { return false; }
        }

        bool IUnresolvedEntity.IsSealed
        {
            get { return true; }
        }

        bool IUnresolvedEntity.IsShadowing
        {
            get { return false; }
        }

        bool IUnresolvedEntity.IsStatic
        {
            get { return false; }
        }

        bool IUnresolvedEntity.IsSynthetic
        {
            get { return false; }
        }

        DomRegion IUnresolvedEntity.Region
        {
            get { return DomRegion.Empty; }
        }

        SymbolKind IUnresolvedEntity.SymbolKind
        {
            get { return SymbolKind.TypeDefinition; }
        }

        IUnresolvedFile IUnresolvedEntity.UnresolvedFile
        {
            get { return _parentFile; }
        }

        #endregion

        #region INamedElement Members

        string INamedElement.FullName
        {
            get { return GetName(true); }
        }

        string INamedElement.Name
        {
            get { return GetName(false); }
        }

        string INamedElement.Namespace
        {
            get { return ""; }
        }

        string INamedElement.ReflectionName
        {
            get { return _module.Name; }
        }

        #endregion

        #region IHasAccessibility Members

        Accessibility IHasAccessibility.Accessibility
        {
            get { return Accessibility.Public; }
        }

        bool IHasAccessibility.IsInternal
        {
            get { return false; }
        }

        bool IHasAccessibility.IsPrivate
        {
            get { return false; }
        }

        bool IHasAccessibility.IsProtected
        {
            get { return false; }
        }

        bool IHasAccessibility.IsProtectedAndInternal
        {
            get { return false; }
        }

        bool IHasAccessibility.IsProtectedOrInternal
        {
            get { return false; }
        }

        bool IHasAccessibility.IsPublic
        {
            get { return true; }
        }

        #endregion
    }
}
