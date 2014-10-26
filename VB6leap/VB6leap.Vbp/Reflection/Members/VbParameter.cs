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
using System.Text;
using VB6leap.Vbp.Reflection.Source;
using VB6leap.Vbp.Reflection.Types;

namespace VB6leap.Vbp.Reflection.Members
{
    [DebuggerDisplay("{Name} As {Type.TypeName}")]
    class VbParameter : IVbParameter
    {
        #region IVbParameter Members

        public VbParameterAccess Access { get; set; }

        public IVbType Type { get; set; }

        public bool IsOptional { get; set; }

        public string OptionalDefaultValue { get; set; }

        #endregion

        #region IVbMember Members

        public string Name { get; set; }

        public ISourceLocation Location { get; set; }

        public MemberVisibility Visibility { get; set; }

        public string ToVbDeclaration()
        {
            StringBuilder sb = new StringBuilder();

            if (IsOptional)
            {
                sb.Append("Optional");
                sb.Append(" ");
            }

            if (Visibility != MemberVisibility.Default)
            {
                sb.Append(Visibility.ToString());
                sb.Append(" ");
            }

            sb.Append(Name);
            sb.Append(" As ");

            sb.Append(Type.TypeName);

            if (IsOptional)
            {
                sb.Append(" = ");
                sb.Append(OptionalDefaultValue);
            }

            return sb.ToString();
        }

        #endregion
    }
}
