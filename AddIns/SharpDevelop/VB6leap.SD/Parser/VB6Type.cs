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
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.NRefactory.TypeSystem.Implementation;

namespace VB6leap.SD.Parser
{
    class VB6Type : AbstractType
    {
        #region Fields

        private string _name;

        #endregion

        #region Constructors

        public VB6Type(string name)
        {
            _name = name;
        }

        #endregion

        #region Methods

        public override bool? IsReferenceType
        {
            get { return true; }
        }

        public override TypeKind Kind
        {
            get { return TypeKind.Class; }
        }

        public override string Name
        {
            get { return _name; }
        }

        public override ITypeReference ToTypeReference()
        {
            return new VB6TypeReference();
        }

        #endregion

    }
}
