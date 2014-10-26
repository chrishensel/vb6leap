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
using VB6leap.Vbp.Reflection.Source;

namespace VB6leap.Vbp.Reflection.Analyzers
{
    public static class AnalyzerFactory
    {
        #region Fields

        private static readonly IAnalyzer[] _analyzers;

        #endregion

        #region Properties

        public static ITokenizer Tokenizer { get; set; }

        #endregion

        #region Constructors

        static AnalyzerFactory()
        {
            _analyzers = new IAnalyzer[]
            {
                new GlobalModuleAnalyzer(),
                new ClassModuleAnalyzer(),
            };
        }

        #endregion

        #region Methods

        internal static bool TryGetAnalyzerForFile(TokenStreamReader reader, out IAnalyzer analyzer)
        {
            var best = _analyzers.FirstOrDefault(_ => _.CanAnalyze(reader.Rewind()));
            if (best != null)
            {
                analyzer = best;
                return true;
            }

            analyzer = null;
            return false;
        }

        #endregion
    }
}
