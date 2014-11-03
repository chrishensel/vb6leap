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
using VB6leap.Core.Collections;
using VB6leap.Vbp.Project;
using VB6leap.Vbp.Project.Properties;

namespace VB6leap.VbpParser.Project
{
    class VbpProjectProperties : PropertyBag, IVbpProjectProperties
    {
        #region Properties

        public string Title
        {
            get { return GetValue(this.Get("Title", "")); }
            set { this.Set("Title", GetAsQuotedString(value)); }
        }

        public string Name
        {
            get { return GetValue(this.Get("Name", "")); }
            set { this.Set("Name", GetAsQuotedString(value)); }
        }

        public Version Version
        {
            get
            {
                int majorVer = int.Parse(GetValue(this.Get("MajorVer", 1)));
                int minorVer = int.Parse(GetValue(this.Get("MinorVer", 0)));
                int revisionVer = int.Parse(GetValue(this.Get("RevisionVer", 0)));

                return new Version(majorVer, minorVer, 0, revisionVer);
            }
            set
            {
                this.Set("MajorVer", value.Major);
                this.Set("MinorVer", value.Minor);
                this.Set("RevisionVer", value.Revision);
            }
        }

        public string Startup
        {
            get { return GetValue(this.Get("Startup", "(None)")); }
            set { this.Set("Startup", GetAsQuotedString(value)); }
        }

        public string HelpFile
        {
            get { return GetValue(this.Get("HelpFile", "")); }
            set { this.Set("HelpFile", GetAsQuotedString(value)); }
        }

        public string HelpContextID
        {
            get { return GetValue(this.Get("HelpContextID", "")); }
            set { this.Set("HelpContextID", GetAsQuotedString(value)); }
        }

        public string ExeName32
        {
            get { return GetValue(this.Get("ExeName32", "")); }
            set { this.Set("ExeName32", GetAsQuotedString(value)); }
        }

        public string Command32
        {
            get { return GetValue(this.Get("Command32", "")); }
            set { this.Set("Command32", GetAsQuotedString(value)); }
        }

        public CompatibleModeKind CompatibleMode
        {
            get { return (CompatibleModeKind)int.Parse(GetValue(this.Get("CompatibleMode", "0"))); }
            set { this.Set("CompatibleMode", GetAsQuotedString(value)); }
        }

        public string CompatibleEXE32
        {
            get { return GetValue(this.Get("CompatibleEXE32", "")); }
            set { this.Set("CompatibleEXE32", GetAsQuotedString(value)); }
        }

        #endregion

        #region Methods

        private string GetValue(object value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            string v = value.ToString();
            if (v.StartsWith("\"") && v.EndsWith("\""))
            {
                return v.Substring(1, v.Length - 2);
            }

            return v;
        }

        private string GetAsQuotedString(object value)
        {

            string ret = "\"";

            if (value != null)
            {
                ret += value.ToString();
            }

            ret += "\"";

            return ret;
        }

        #endregion
    }
}
