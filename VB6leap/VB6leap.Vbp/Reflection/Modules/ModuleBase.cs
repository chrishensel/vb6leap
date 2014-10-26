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
using VB6leap.Vbp.Reflection.Members;

namespace VB6leap.Vbp.Reflection.Modules
{
    /// <summary>
    /// Abstract module class.
    /// </summary>
    public abstract class ModuleBase : IVbModule
    {
        #region Fields

        private readonly List<IVbMember> _membersInternal;

        #endregion

        #region Properties

        /// <summary>
        /// Gets all attributes of this module.
        /// </summary>
        public IEnumerable<IVbAttribute> Attributes
        {
            get { return _membersInternal.OfType<IVbAttribute>(); }
        }

        /// <summary>
        /// Gets all methods of this module (including properties).
        /// </summary>
        public IEnumerable<IVbMethod> Methods
        {
            get { return _membersInternal.OfType<IVbMethod>(); }
        }

        /// <summary>
        /// Gets all properties of this module.
        /// </summary>
        public IEnumerable<IVbProperty> Properties
        {
            get { return _membersInternal.OfType<IVbProperty>(); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Protected instance constructor.
        /// </summary>
        protected ModuleBase()
        {
            _membersInternal = new List<IVbMember>();
        }

        #endregion

        #region IVbModule implementation

        /// <summary>
        /// Gets the name of the module.
        /// </summary>
        public string Name { get; protected internal set; }

        /// <summary>
        /// Gets the member's visibility.
        /// </summary>
        public MemberVisibility Visibility { get; protected internal set; }

        /// <summary>
        /// Gets a read-only list of all members of this module.
        /// </summary>
        public IReadOnlyList<IVbMember> Members
        {
            get { return _membersInternal; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds the given member to the list of members.
        /// </summary>
        /// <param name="member">The member to add. The member is only added if it does not yet exist in the collection.</param>
        protected internal void AddMember(IVbMember member)
        {
            if (member == null)
            {
                throw new ArgumentNullException("member");
            }

            if (!_membersInternal.Contains(member))
            {
                _membersInternal.Add(member);
            }
        }

        #endregion

    }
}
