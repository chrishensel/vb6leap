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
using System.IO;
using System.Linq;
using VB6leap.Vbp.Project;
using VB6leap.Vbp.Project.ObjectModel;
using VB6leap.Vbp.Serialization;

namespace VB6leap.VbpParser.Serialization
{
    public class Vb6ProjectWriter : IVbProjectWriter
    {
        #region Fields
        
        private readonly IVbElementSerializer _serializer;
        
        #endregion
        
        #region Constructors
        
        public Vb6ProjectWriter()
        {
            _serializer = new VbElementSerializer();
        }
        
        #endregion
        
        #region IVbProjectWriter Members

        void IVbProjectWriter.Write(IVbProject project, Stream stream)
        {
            StreamWriter writer = new StreamWriter(stream);
            
            foreach (ElementBase element in project.GetAllElements())
            {
                writer.WriteLine(_serializer.Serialize(element));
            }

            foreach (string key in project.Properties)
            {
                writer.WriteLine("{0}={1}", key, project.Properties.Get(key, ""));
            }

            writer.Flush();
        }

        #endregion
    }
}
