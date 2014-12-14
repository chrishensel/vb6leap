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
using ICSharpCode.NRefactory;
using ICSharpCode.NRefactory.TypeSystem;
using VB6leap.Vbp.Reflection;
using VB6leap.Vbp.Reflection.Modules;
using VB6leap.Vbp.Serialization;

namespace VB6leap.SDAddin.Parser
{
    class VB6UnresolvedFile : IUnresolvedFile, IVbModuleWrapper
    {
        #region Fields

        private string _fileName;
        private readonly IVbpProject _project;

        private readonly IVbModule _module;

        private List<Error> _errors;
        private List<IUnresolvedAttribute> _attributes;
        private List<IUnresolvedTypeDefinition> _topLevelTypeDefinitions;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the partitioned file that this class was created from.
        /// </summary>
        internal VbPartitionedFile PartitionedFile { get; private set; }

        #endregion

        #region Constructors

        private VB6UnresolvedFile()
        {
            _errors = new List<Error>();
            _attributes = new List<IUnresolvedAttribute>();
            _topLevelTypeDefinitions = new List<IUnresolvedTypeDefinition>();
        }

        internal VB6UnresolvedFile(string fileName, string text, IVbpProject project)
            : this()
        {
            _fileName = fileName;
            _project = project;

            this.PartitionedFile = VbPartitionedFile.GetPartitionedFile(text);

            _module = ParseModule(this.PartitionedFile);
            ParseModuleIntoMembers();
        }

        #endregion

        #region Methods

        private IVbModule ParseModule(VbPartitionedFile partFile)
        {
            return ModuleReflector.GetReflectedModule(partFile);
        }

        private void ParseModuleIntoMembers()
        {
            /* Add the one-and-only type definition.
             * Global Modules don't have a type, so lets create one.
             */
            VB6UnresolvedTypeDefinition typeDef = new VB6UnresolvedTypeDefinition(this, _module, _project);
            _topLevelTypeDefinitions.Add(typeDef);
        }

        #endregion

        #region IUnresolvedFile Members

        IList<IUnresolvedAttribute> IUnresolvedFile.AssemblyAttributes
        {
            get { return _attributes; }
        }

        IList<Error> IUnresolvedFile.Errors
        {
            get { return _errors; }
        }

        string IUnresolvedFile.FileName
        {
            get { return _fileName; }
        }

        IUnresolvedTypeDefinition IUnresolvedFile.GetInnermostTypeDefinition(TextLocation location)
        {
            /* Since VB6-modules only contain one type per file (which is good).
             * Note that this doesn't consider Enums or custom "Type" declarations - for simplicity right now.
             */
            return _topLevelTypeDefinitions.FirstOrDefault();
        }

        IUnresolvedMember IUnresolvedFile.GetMember(TextLocation location)
        {
            int iLine = location.Line - 1;
            int iCol = location.Column - 1;
            string word = null;

            if (this.PartitionedFile.TryGetWordAt(iLine, iCol, out word))
            {
                foreach (IUnresolvedMember member in _topLevelTypeDefinitions[0].Members)
                {
                    if (member.Name.Equals(word, StringComparison.OrdinalIgnoreCase))
                    {
                        return member;
                    }
                }
            }

            return null;
        }

        IUnresolvedTypeDefinition IUnresolvedFile.GetTopLevelTypeDefinition(TextLocation location)
        {
            /* Since VB6-modules only contain one type per file (which is good), we can do this.
             */
            return _topLevelTypeDefinitions.FirstOrDefault();
        }

        DateTime? IUnresolvedFile.LastWriteTime { get; set; }

        IList<IUnresolvedAttribute> IUnresolvedFile.ModuleAttributes
        {
            get { throw new NotImplementedException(); }
        }

        IList<IUnresolvedTypeDefinition> IUnresolvedFile.TopLevelTypeDefinitions
        {
            get { return _topLevelTypeDefinitions; }
        }

        #endregion

        #region IVbModuleWrapper Members

        IVbModule IVbModuleWrapper.Module
        {
            get { return _module; }
        }

        #endregion
    }
}
