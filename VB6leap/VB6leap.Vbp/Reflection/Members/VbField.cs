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

using System.Text;
using VB6leap.Vbp.Reflection.Source;
using VB6leap.Vbp.Reflection.Types;

namespace VB6leap.Vbp.Reflection.Members
{
	class VbField : IVbField
	{
		#region IVbMember implementation
		
		public string ToVbDeclaration()
		{
            // TODO: This is partially copy-pasted from VbMethod.ToVbDeclaration(). Maybe generalize.

            StringBuilder sb = new StringBuilder();

            if (this.Visibility != MemberVisibility.Default)
            {
                sb.Append(this.Visibility.ToString());
                sb.Append(" ");
            }

            if (this.IsConstant)
            {
                sb.Append("Const ");
            }

            if (this.IsStatic)
            {
                sb.Append("Shared ");
            }

            sb.Append(this.Name);
            sb.Append(" ");

            if (this.Type != null && !(this.Type is IVbVoidType))
            {
                sb.Append(" As ");
                sb.Append(this.Type.TypeName);
            }

            return sb.ToString();
		}
		
		public string Name { get; set; }
		
		public ISourceLocation Location{ get; set; }
		
		public MemberVisibility Visibility { get; set; }
		
		#endregion
		
		#region IVbField implementation
		
		public bool IsConstant { get; set; }
		
		public bool IsStatic { get; set; }
		
		public IVbType Type { get; set; }
		
		#endregion
		
	}
}
