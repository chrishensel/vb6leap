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
using VB6leap.Vbp.Project;
using VB6leap.Vbp.Project.ObjectModel;
using VB6leap.Vbp.Serialization;
using VB6leap.VbpParser.Serialization.SubParser;

namespace VB6leap.VbpParser.Serialization
{
    class VbElementSerializer : IVbElementSerializer
    {
        #region Fields
        
        private readonly IReferenceParser _referenceParser;
        
        #endregion
        
        #region Constructors
        
        internal VbElementSerializer()
        {
            _referenceParser = new ReferenceParser();
        }
        
        #endregion
        
        #region Methods

        private void ParseGeneric(ElementBase fileBase, string value)
        {
            string[] parts = value.Split(';');

            fileBase.Name = parts[0].Trim();

            if (parts.Length == 2)
            {
                fileBase.FileName = parts[1].Trim();
            }
        }

        private ModuleElement ParseModule(string item)
        {
            ModuleElement mod = new ModuleElement();
            ParseGeneric(mod, item);

            return mod;
        }

        private ClassElement ParseClass(string item)
        {
            ClassElement cls = new ClassElement();
            ParseGeneric(cls, item);

            return cls;
        }

        private FormElement ParseForm(string item)
        {
            string[] parts = item.Split(';');
            if (parts.Length == 1)
            {
                FormElement cls = new FormElement();

                cls.FileName = parts[0];
                cls.Name = Path.GetFileName(cls.FileName);

                return cls;
            }
                
            return null;
        }

        private UserControlElement ParseUserControl(string item)
        {
            string[] parts = item.Split(';');
            if (parts.Length == 1)
            {
                UserControlElement ctl = new UserControlElement();

                ctl.FileName = parts[0];
                ctl.Name = Path.GetFileName(ctl.FileName);

                return ctl;
            }
            
            return null;
        }

        private ObjectElement ParseObject(string item)
        {
            string[] parts = item.Split('#');
            if (parts.Length == 3)
            {
                ObjectElement obj = new ObjectElement();
                obj.Guid = Guid.Parse(parts[0]);
                obj.Version = parts[1];
                obj.Name = parts[2];

                int iSemicolon = obj.Name.IndexOf(';');
                if (iSemicolon > -1)
                {
                    obj.Reserved = obj.Name.Substring(0, iSemicolon + 1);
                    obj.Name = obj.Name.Remove(0, obj.Reserved.Length).Trim();
                }

                return obj;
            }
            
            return null;
        }
        
        #endregion
        
        #region IVbElementSerializer implementation
        
        string IVbElementSerializer.Serialize(ElementBase element)
        {
            throw new NotImplementedException();
        }
        
        ElementBase IVbElementSerializer.Deserialize(string content, IVbProject project)
        {
            string kind = content.Substring(0, content.IndexOf('='));
            string value = content.Remove(0, kind.Length + 1);
            
            switch (kind)
            {
                case "Reference":
                    return _referenceParser.Parse(value);
                case "Object":
                    return ParseObject(value);
                case "Module":
                    return ParseModule(value);
                case "Class":
                    return ParseClass(value);
                case "Form":
                    return ParseForm(value);
                case "Control":
                    return ParseUserControl(value);
            }
            
            throw new NotSupportedException(string.Format("Kind '{0}' is not supported!", kind));
        }
        
        #endregion
    }
}
