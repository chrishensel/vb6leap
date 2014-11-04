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
using System.CodeDom.Compiler;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.SharpDevelop;
using ICSharpCode.SharpDevelop.Editor;
using ICSharpCode.SharpDevelop.Editor.CodeCompletion;

namespace VB6leap.SDAddin
{
    public class VbpLanguageBinding : ILanguageBinding
    {
        #region Fields

        private IBracketSearcher _bracketSearcher;
        private IFormattingStrategy _formattingStrategy;

        #endregion

        #region Constructors

        public VbpLanguageBinding()
        {
            _bracketSearcher = new DefaultBracketSearcher();
            _formattingStrategy = new VbpFormattingStrategy();
        }

        #endregion

        #region ILanguageBinding implementation

        ICodeCompletionBinding ILanguageBinding.CreateCompletionBinding(string expressionToComplete, ICodeContext context)
        {
            return null;
        }

        IFormattingStrategy ILanguageBinding.FormattingStrategy
        {
            get
            {
                return _formattingStrategy;
            }
        }

        IBracketSearcher ILanguageBinding.BracketSearcher
        {
            get
            {
                return _bracketSearcher;
            }
        }

        ICSharpCode.SharpDevelop.Refactoring.CodeGenerator ILanguageBinding.CodeGenerator
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        CodeDomProvider ILanguageBinding.CodeDomProvider
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region IServiceProvider implementation

        object IServiceProvider.GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
