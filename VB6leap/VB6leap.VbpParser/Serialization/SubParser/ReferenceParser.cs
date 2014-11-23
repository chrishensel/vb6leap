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
using System.Linq;
using VB6leap.Vbp.Project.ObjectModel;

namespace VB6leap.VbpParser.Serialization.SubParser
{
    class ReferenceParser : IReferenceParser
    {
        #region Constants

        private const string GuidToken = @"*\G";
        private const char PartSplitChar = '#';

        #endregion

        #region IReferenceParser Members

        ReferenceElement IReferenceParser.Parse(string raw)
        {
            if (!raw.StartsWith(GuidToken, StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException();
            }

            ReferenceElement reference = new ReferenceElement();

            //   *\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\Windows\system32\stdole2.tlb#OLE Automation

            raw = raw.Substring(3);

            string[] parts = raw.Split(PartSplitChar);
            if (parts.Length == 5)
            {
                reference.Guid = Guid.Parse(parts[0]);
                reference.Version = parts[1];
                reference.Reserved = parts[2];
                reference.FileName = parts[3];

                // The file name sometimes features a backslash, which we remove and store in a separate property.
                if (char.IsNumber(reference.FileName.Last()))
                {
                    int iSlash = reference.FileName.LastIndexOf('\\');

                    reference.FileNameTrailer = reference.FileName;
                    reference.FileName = reference.FileName.Substring(0, iSlash);
                    reference.FileNameTrailer = reference.FileNameTrailer.Remove(0, iSlash);
                }

                reference.Name = parts[4];
            }

            return reference;
        }
        
        string IReferenceParser.Parse(ReferenceElement reference)
        {
            return reference.ToString();
        }

        #endregion

    }
}
