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
using System.IO;
using System.Linq;
using ICSharpCode.Core;
using ICSharpCode.NRefactory.Editor;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.SharpDevelop.Parser;
using VB6leap.SDAddin.Parser.TypeSystem;
using VB6leap.Vbp.Project.ObjectModel;

namespace VB6leap.SDAddin.Parser.Cache
{
    class VbpProjectSymbolCache : IVbpProjectSymbolCache
    {
        #region Fields

        private readonly IVbpProject _project;

        private Dictionary<string, ParseInformation> _cache;

        private readonly VB6Compilation _compilation;
        private readonly VB6Assembly _assembly;
        private readonly VB6Namespace _namespace;

        #endregion

        #region Constructors

        private VbpProjectSymbolCache()
        {
            _cache = new Dictionary<string, ParseInformation>();
        }

        private VbpProjectSymbolCache(IVbpProject project)
            : this()
        {
            _project = project;

            _namespace = new VB6Namespace(project.GetOwnedProject());

            _assembly = new VB6Assembly();

            _assembly.RootNamespace = _namespace;
            _assembly.Compilation = _compilation;
            _namespace.Compilation = _compilation;

            _compilation = new VB6Compilation(this);
        }

        #endregion

        #region Methods

        internal static IVbpProjectSymbolCache FromProject(IVbpProject project)
        {
            VbpProjectSymbolCache impl = new VbpProjectSymbolCache(project);

            /* Initially iterate over each module, create its parse information, and cache it!
             */
            List<ElementBase> files = new List<ElementBase>();
            files.AddRange(project.GetOwnedProject().Modules);
            files.AddRange(project.GetOwnedProject().Classes);
            files.AddRange(project.GetOwnedProject().Forms);
            files.AddRange(project.GetOwnedProject().UserControls);

            foreach (ElementBase file in files)
            {
                string fn = file.GetAbsoluteFileName(project.GetOwnedProject());

                ITextSource ts = new StringTextSource(File.ReadAllText(fn));
                impl._cache[fn] = CreateParseInformation(fn, ts, project);
            }

            return impl;
        }

        private static ParseInformation CreateParseInformation(string fileName, ITextSource ts, IVbpProject project)
        {
            IUnresolvedFile file = new VB6UnresolvedFile(fileName, ts.Text, project);
            return new VB6ParseInformation(file, ts.Version, true);
        }

        #endregion

        #region IVbpProjectSymbolCache Members

        IAssembly IVbpProjectSymbolCache.Assembly
        {
            get { return _assembly; }
        }

        INamespace IVbpProjectSymbolCache.Namespace
        {
            get { return _namespace; }
        }

        ITypeResolveContext IVbpProjectSymbolCache.CreateResolveContext(ITypeResolveContext parentContext)
        {
            TypeResolveContextImpl ctx = new TypeResolveContextImpl();
            ctx.ParentContext = parentContext;
            ctx.CurrentAssembly = this._assembly;
            ctx.Compilation = this._compilation;

            return ctx;
        }

        IType IVbpProjectSymbolCache.GetTypeByName(string name)
        {
            foreach (var item in _cache.Values.SelectMany(_ => _.UnresolvedFile.GetAllTypeDefinitions()))
            {
                if (item.Name == name || item.FullName == name)
                {
                    VB6UnresolvedTypeDefinition typeDef = item as VB6UnresolvedTypeDefinition;
                    if (typeDef != null)
                    {
                        return typeDef.ResolvedType;
                    }
                }
            }

            return null;
        }

        ParseInformation IVbpProjectSymbolCache.GetAndReparse(FileName fileName, ITextSource fileContent)
        {
            string fn = fileName.ToString();

            _cache[fn] = CreateParseInformation(fn, fileContent, _project);
            return _cache[fn];
        }

        #endregion

        #region ICompilationProvider Members

        ICompilation ICompilationProvider.Compilation
        {
            get { return _compilation; }
        }

        #endregion

        #region Nested types

        class TypeResolveContextImpl : ITypeResolveContext
        {
            #region Properties

            public ITypeResolveContext ParentContext { get; set; }

            #endregion

            #region ITypeResolveContext Members

            public IAssembly CurrentAssembly { get; set; }

            public IMember CurrentMember { get; set; }

            public ITypeDefinition CurrentTypeDefinition { get; set; }

            public ITypeResolveContext WithCurrentMember(IMember member)
            {
                this.CurrentMember = member;

                return this;
            }

            public ITypeResolveContext WithCurrentTypeDefinition(ITypeDefinition typeDefinition)
            {
                this.CurrentTypeDefinition = typeDefinition;

                return this;
            }

            #endregion

            #region ICompilationProvider Members

            public ICompilation Compilation { get; set; }

            #endregion
        }

        #endregion
    }
}
