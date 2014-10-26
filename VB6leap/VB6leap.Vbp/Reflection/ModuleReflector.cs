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
using System.Collections.Generic;
using System.Linq;
using VB6leap.Vbp.Reflection.Analyzers;
using VB6leap.Vbp.Reflection.Modules;
using VB6leap.Vbp.Reflection.Source;
using VB6leap.Vbp.Serialization;

namespace VB6leap.Vbp.Reflection
{
	/// <summary>
	/// Provides access to functionality that reflects a text file into a VB module.
	/// </summary>
	public static class ModuleReflector
	{
		#region	Constructors
		
		static ModuleReflector()
		{
			
		}
		
		#endregion
		
		#region Methods
				
		/// <summary>
		/// Reads and reflects the given VB Classic text file into a usable form.
		/// </summary>
		/// <param name="partitionedFile">An instance of <see cref="VbPartitionedFile"/> representing the VB Classic module to reflect.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException"><paramref name="partitionedFile"/> was null.</exception>
		public static IVbModule GetReflectedModule(VbPartitionedFile partitionedFile)
		{
			if (partitionedFile == null)
			{
				throw new ArgumentNullException("partitionedFile");
			}

            // TODO: Feature-Envy? Property should be in this class?
            if (AnalyzerFactory.Tokenizer == null)
            {
                throw new InvalidOperationException("No tokenizer defined for analyzing the file!");
            }

            IReadOnlyList<IToken> tokens = AnalyzerFactory.Tokenizer.GetTokens(partitionedFile.GetMergedContent());

            IReadOnlyList<IToken> cleanedTokens = tokens.SkipComments().ToList();
            TokenStreamReader reader = new TokenStreamReader(cleanedTokens);
			
			IAnalyzer analyzer = null;
			if (!AnalyzerFactory.TryGetAnalyzerForFile(reader, out analyzer))
			{
				// TODO: Dedicated exception for this.
				throw new InvalidOperationException("Could not analyze the given file!");
			}

            reader.Rewind();

			return analyzer.Analyze(reader);
		}
		
		#endregion
	}
}
