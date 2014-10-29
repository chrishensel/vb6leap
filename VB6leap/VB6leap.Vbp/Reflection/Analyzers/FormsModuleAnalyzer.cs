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

using System.Linq;
using VB6leap.Vbp.Reflection.Members;
using VB6leap.Vbp.Reflection.Modules;
using VB6leap.Vbp.Reflection.Source;

namespace VB6leap.Vbp.Reflection.Analyzers
{
    class FormsModuleAnalyzer : IAnalyzer
    {
        #region IAnalyzer Members

        bool IAnalyzer.CanAnalyze(TokenStreamReader reader)
        {
            IToken[] firstLine = reader.GetUntilEOL().ToArray();
            if (firstLine.Length == 2)
            {
                return firstLine[0].EqualsStringInvariant("VERSION") &&
                    firstLine[1].EqualsStringInvariant("5.00");
            }

            return false;
        }

        IVbModule IAnalyzer.Analyze(TokenStreamReader reader)
        {
            var attributes = AnalyzerTools.GetAttributes(reader).ToDictionary(_ => _.Name);

            FormsModule mod = new FormsModule();
            mod.Visibility = MemberVisibility.Default;
            mod.Name = attributes[AnalyzerConstants.AttributeName_Name].Value;

            foreach (IVbAttribute attribute in attributes.Values)
            {
                mod.AddMember(attribute);
            }
            foreach (IVbMethod method in AnalyzerTools.GetMethods(reader))
            {
                mod.AddMember(method);
            }

            return mod;
        }

        #endregion
    }
}
