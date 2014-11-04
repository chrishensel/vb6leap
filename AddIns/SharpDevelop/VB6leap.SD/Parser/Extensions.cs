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
using ICSharpCode.NRefactory.TypeSystem;
using VB6leap.Vbp.Reflection.Members;
using VB6leap.Vbp.Reflection.Modules;
using VB6leap.Vbp.Reflection.Source;

namespace VB6leap.SDAddin.Parser
{
    static class Extensions
    {
        internal static TypeKind ToTypeKind(this IVbModule module)
        {
            if (module is GlobalModule)
            {
                return TypeKind.Module;
            }

            return TypeKind.Class;
        }

        internal static DomRegion ToDomRegion(this ISourceLocation location)
        {
            return new DomRegion(location.Line, location.Column);
        }

        internal static Accessibility ToAccessibility(this IVbMember member)
        {
            if (member.Visibility == MemberVisibility.Public)
            {
                return Accessibility.Public;
            }

            return Accessibility.Private;
        }

        internal static IEnumerable<IUnresolvedMember> ToMembers(this IVbModule module)
        {
            yield break;
        }
    }
}
