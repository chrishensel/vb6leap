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

namespace VB6leap.Vbp.Reflection.Types
{
    /// <summary>
    /// Contains static definitions of most VB6 types.
    /// </summary>
    public static class VbTypes
    {
        #region Properties

        /// <summary>
        /// Gets the implicit "void" type. This is only used for a Sub.
        /// </summary>
        internal static IVbType Void { get; private set; }

        /// <summary>
        /// Gets the "Variant" type.
        /// </summary>
        public static IVbType Variant { get; private set; }

        #endregion

        #region Constructors

        static VbTypes()
        {
            Void = new VbVoidType();

            Variant = new VbVariantType();
        }

        #endregion
    }
}
