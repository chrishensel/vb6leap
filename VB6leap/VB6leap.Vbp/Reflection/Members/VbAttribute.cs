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

using System.Diagnostics;
using VB6leap.Vbp.Reflection.Source;

namespace VB6leap.Vbp.Reflection.Members
{
    [DebuggerDisplay("{ToVbDeclaration()}")]
    class VbAttribute : IVbAttribute
    {
        #region IVbAttributeMember Members

        public string Value { get; set; }

        #endregion

        #region IVbMember Members

        public string Name { get; set; }

        public ISourceLocation Location { get; set; }

        public MemberVisibility Visibility
        {
            get { return MemberVisibility.Public; }
        }

        public string ToVbDeclaration()
        {
            return string.Format("Attribute {0} = \"{1}\"", this.Name, this.Value);
        }

        #endregion
    }
}
