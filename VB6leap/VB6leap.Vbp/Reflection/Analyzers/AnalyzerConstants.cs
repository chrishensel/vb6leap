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


namespace VB6leap.Vbp.Reflection.Analyzers
{
    /// <summary>
    /// Defines constants that are useful for analyzing VB6 files.
    /// </summary>
    public static class AnalyzerConstants
    {
        /// <summary>
        /// Specifies the value of the "Attribute" token.
        /// </summary>
        public const string Attribute_TokenName = "Attribute";
        /// <summary>
        /// Specifies the value of the "VB_Name" attribute token, representing the actual name of a VB6 module.
        /// </summary>
        public const string AttributeName_Name = "VB_Name";

        /// <summary>
        /// Specifies the value of the "Private" token.
        /// </summary>
        public const string Visibility_Private = "Private";
        /// <summary>
        /// Specifies the value of the "Public" token.
        /// </summary>
        public const string Visibility_Public = "Public";

        /// <summary>
        /// Specifies the value of the "Sub" token.
        /// </summary>
        public const string Method_Sub = "Sub";
        /// <summary>
        /// Specifies the value of the "Function" token.
        /// </summary>
        public const string Method_Function = "Function";
        /// <summary>
        /// Specifies the value of the "Property" token.
        /// </summary>
        public const string Method_Property = "Property";

        /// <summary>
        /// Specifies the value of the "End" token.
        /// </summary>
        public const string End = "End";

        /// <summary>
        /// Specifies the value of the "ByVal" token.
        /// </summary>
        public const string Parameter_ByVal = "ByVal";
        /// <summary>
        /// Specifies the value of the "ByRef" token.
        /// </summary>
        public const string Parameter_ByRef = "ByRef";
        /// <summary>
        /// Specifies the value of the "Optional" token.
        /// </summary>
        public const string Parameter_Optional = "Optional";

    }
}
