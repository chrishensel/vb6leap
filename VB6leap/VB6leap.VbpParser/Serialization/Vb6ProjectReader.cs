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
using System.IO;
using System.Linq;
using VB6leap.Vbp.Project;
using VB6leap.Vbp.Project.ObjectModel;
using VB6leap.Vbp.Serialization;

namespace VB6leap.VbpParser.Serialization
{
    public class Vb6ProjectReader : IVbProjectReader
    {
        #region Constants

        private static readonly string[] NoPropertyKeys = new[] { "Reference", "Form", "Class", "Module", "UserControl", "Object" };

        #endregion

        #region Fields

        private IReadOnlyList<Tuple<string, string>> _bag;
        private Vb6Project _project;

        private readonly IVbElementSerializer _serializer;

        #endregion
        
        #region Constructors
        
        public Vb6ProjectReader()
        {
            _serializer = new VbElementSerializer();
        }
        
        #endregion

        #region IVbProjectReader Members

        IVbProject IVbProjectReader.Read(FileInfo source, Stream stream)
        {
            try
            {
                return ReadCore(source, stream);
            }
            catch (Exception ex)
            {
                throw new ProjectParseException(ex.Message, ex);
            }
        }

        #endregion

        #region Methods

        private IVbProject ReadCore(FileInfo source, Stream stream)
        {
            _project = new Vb6Project(source);

            _bag = ReadLinesIntoPairs(stream).ToList();

            ParseProjectType();
            FillProperties();

            foreach (var item in _bag.Where(_ => NoPropertyKeys.Contains(_.Item1)))
            {
                string line = string.Format("{0}={1}", item.Item1, item.Item2);
                
                ElementBase element = _serializer.Deserialize(line, _project);
                if (element is ReferenceElement)
                {
                    _project.References.Add((ReferenceElement)element);
                }
                else if (element is ObjectElement)
                {
                    _project.Objects.Add((ObjectElement)element);
                }
                else if (element is ModuleElement)
                {
                    _project.Modules.Add((ModuleElement)element);
                }
                else if (element is ClassElement)
                {
                    _project.Classes.Add((ClassElement)element);
                }
                else if (element is FormElement)
                {
                    _project.Forms.Add((FormElement)element);
                }
                else if (element is UserControlElement)
                {
                    _project.UserControls.Add((UserControlElement)element);
                }
            }

            return _project;
        }

        private void ParseProjectType()
        {
            string projType = null;
            if (!GetSingleValue(_bag, "Type", out projType))
            {
                throw new InvalidOperationException();
            }

            _project.Type = Helpers.ToProjectType(projType);
        }

        private void FillProperties()
        {
            foreach (var tuple in _bag.Where(_ => !NoPropertyKeys.Contains(_.Item1)))
            {
                _project.Properties.Set(tuple.Item1, tuple.Item2);
            }
        }

        #endregion

        #region Methods (Helpers)

        private static IEnumerable<Tuple<string, string>> ReadLinesIntoPairs(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                string line = null;
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (line.Length == 0 ||
                        line.StartsWith("//"))
                    {
                        continue;
                    }

                    /* Certain tools and add-ins write ini-styled stuff into the project file.
                     * Upon encountering such data, we stop processing (for now).
                     */
                    if (line.StartsWith("["))
                    {
                        break;
                    }

                    string[] parts = line.Split('=');
                    if (parts.Length == 2)
                    {
                        yield return Tuple.Create(parts[0], parts[1]);
                    }
                }
            }
        }

        private static bool GetSingleValue(IEnumerable<Tuple<string, string>> bag, string key, out string value)
        {
            var found = bag.FirstOrDefault(_ => _.Item1 == key);
            if (found != null)
            {
                value = found.Item2;
                return true;
            }

            value = null;
            return false;
        }

        private static IEnumerable<string> GetAllValues(IEnumerable<Tuple<string, string>> bag, string key)
        {
            foreach (var item in bag)
            {
                if (item.Item1 == key)
                {
                    yield return item.Item2;
                }
            }
        }

        #endregion
    }
}
