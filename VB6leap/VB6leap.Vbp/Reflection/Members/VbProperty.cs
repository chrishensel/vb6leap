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
using VB6leap.Vbp.Reflection.Types;
namespace VB6leap.Vbp.Reflection.Members
{
    [DebuggerDisplay("{ToVbDeclaration()}")]
    class VbProperty : VbMethod, IVbProperty
    {
        #region IVbProperty Members

        public VbPropertyAccessor Accessor { get; set; }

        #endregion

        #region Methods

        public override string ToVbDeclaration()
        {
            // TODO: This is copy-pasted from VbMethod.ToVbDeclaration(). Maybe generalize.

            StringBuilder sb = new StringBuilder();

            if (this.Visibility != MemberVisibility.Default)
            {
                sb.Append(this.Visibility.ToString());
                sb.Append(" ");
            }

            sb.Append(this.MethodKind.ToString());
            sb.Append(" ");

            sb.Append(this.Accessor.ToString());
            sb.Append(" ");

            sb.Append(this.Name);
            sb.Append(" ");

            sb.Append("(");

            foreach (IVbParameter parameter in Parameters)
            {
                sb.Append(parameter.ToVbDeclaration());

                sb.Append(", ");
            }

            /* Removes the trailing comma.
             */
            if (sb.ToString().EndsWith(", "))
            {
                sb.Remove(sb.Length - 2, 2);
            }

            sb.Append(")");

            if (this.ReturnType != null && !(this.ReturnType is IVbVoidType))
            {
                sb.Append(" As ");
                sb.Append(this.ReturnType.TypeName);
            }

            return sb.ToString();
        }


        #endregion
    }
}
