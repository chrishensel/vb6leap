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
using VB6leap.VbpParser.SubParser;

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

        private readonly IReferenceParser _referenceParser = new ReferenceParser();

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
            ParseReferences();
            ParseModules();
            ParseClasses();
            ParseForms();
            ParseObjects();

            FillProperties();

            return _project;
        }

        private void ParseProjectType()
        {
            string projType = null;
            if (!GetSingleValue(_bag, "Type", out projType))
            {
                throw new InvalidOperationException();
            }

            ProjectType type = 0;
            switch (projType)
            {
                case "Exe":
                    type = ProjectType.StandardExe;
                    break;
                case "OleDll":
                    type = ProjectType.OleDll;
                    break;
                case "Control":
                    type = ProjectType.Control;
                    break;
                default:
                    throw new InvalidOperationException();
            }

            _project.Type = type;
        }

        private void ParseReferences()
        {
            foreach (string item in GetAllValues(_bag, "Reference"))
            {
                _project.References.Add(_referenceParser.Parse(item));
            }
        }

        private void ParseGeneric(ElementBase fileBase, string value)
        {
            string[] parts = value.Split(';');

            fileBase.Name = parts[0].Trim();

            if (parts.Length == 2)
            {
                fileBase.FileName = parts[1].Trim();
            }
        }

        private void ParseModules()
        {
            foreach (string item in GetAllValues(_bag, "Module"))
            {
                ModuleElement mod = new ModuleElement();
                ParseGeneric(mod, item);

                _project.Modules.Add(mod);
            }
        }

        private void ParseClasses()
        {
            foreach (string item in GetAllValues(_bag, "Class"))
            {
                ClassElement cls = new ClassElement();
                ParseGeneric(cls, item);

                _project.Classes.Add(cls);
            }
        }

        private void ParseForms()
        {
            foreach (string item in GetAllValues(_bag, "Form"))
            {
                string[] parts = item.Split(';');
                if (parts.Length == 1)
                {
                    FormElement cls = new FormElement();

                    cls.FileName = parts[0];
                    cls.Name = Path.GetFileName(cls.FileName);

                    _project.Forms.Add(cls);
                }
            }
        }

        private void ParseObjects()
        {
            foreach (string item in GetAllValues(_bag, "Object"))
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

                    _project.Objects.Add(obj);
                }
            }
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
