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
using System.Linq;
using ICSharpCode.NRefactory.TypeSystem;
using VB6leap.Vbp.Project;
using VB6leap.Vbp.Reflection.Members;
using VB6leap.Vbp.Reflection.Modules;

namespace VB6leap.SDAddin.Parser
{
    class VB6UnresolvedTypeDefinition : VB6UnresolvedEntityBase, IUnresolvedTypeDefinition
    {
        #region Fields

        private readonly TypeKind _typeKind = TypeKind.Unknown;

        private List<IUnresolvedEvent> _events;
        private List<IUnresolvedField> _fields;
        private List<IUnresolvedProperty> _properties;
        private List<IUnresolvedMethod> _methods;
        private List<IUnresolvedMember> _members;

        #endregion

        #region Properties

        protected IVbModule Module { get; private set; }
        protected IVbProject Project { get; private set; }

        #endregion

        #region Constructors

        internal VB6UnresolvedTypeDefinition(IUnresolvedFile file, IVbModule module, IVbpProject project)
            : base(file, null)
        {
            this.Module = module;
            if (project != null)
            {
                this.Project = project.GetOwnedProject();
            }

            _typeKind = this.Module.ToTypeKind();

            this.Accessibility = (_typeKind != TypeKind.Module) ? Accessibility.Public : Accessibility.Private;

            _events = new List<IUnresolvedEvent>();
            _fields = new List<IUnresolvedField>();
            _properties = new List<IUnresolvedProperty>();
            _methods = new List<IUnresolvedMethod>();
            _members = new List<IUnresolvedMember>();

            this.DeclaringTypeDefinition = this;
            this.FullName = GetName(true);
            this.Name = GetName(false);
            this.Namespace = "(implicit)";
            this.ReflectionName = GetName(true);

            ProcessModule();
        }

        #endregion

        #region Methods

        private void ProcessModule()
        {
            foreach (IVbMethod method in this.Module.Members.OfType<IVbMethod>())
            {
                if (method is IVbProperty)
                {
                    _properties.Add(new VB6UnresolvedProperty((IVbProperty)method, this.UnresolvedFile, this, this.DeclaringTypeDefinition));
                }
                else
                {
                    _methods.Add(new VB6UnresolvedMethod(method, this.UnresolvedFile, this, this.DeclaringTypeDefinition));
                }
            }

            foreach (IVbField field in this.Module.Members.OfType<IVbField>())
            {
                _fields.Add(new VB6UnresolvedField(field, this.UnresolvedFile, this, this.DeclaringTypeDefinition));
            }

            _members.AddRange(_events);
            _members.AddRange(_fields);
            _members.AddRange(_properties);
            _members.AddRange(_methods);
        }

        private string GetName(bool fullName)
        {
            if (fullName)
            {
                return "(Implicit project scope)" + "." + this.Module.Name;
            }

            return this.Module.Name;
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
            get { return new FullTypeName(this.FullName); }
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
            get { return _typeKind; }
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
            return new VB6Type(this.Name);
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

        public override SymbolKind SymbolKind
        {
            get { return ICSharpCode.NRefactory.TypeSystem.SymbolKind.TypeDefinition; }
        }

        public override DomRegion BodyRegion
        {
            get { return new DomRegion(1, 1); }
        }

        public override DomRegion Region
        {
            get { return new DomRegion(1, 1); }
        }

        #endregion
    }
}
