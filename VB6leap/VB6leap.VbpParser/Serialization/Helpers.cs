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
using VB6leap.Vbp.Project;
using VB6leap.Vbp.Project.ObjectModel;

namespace VB6leap.VbpParser.Serialization
{
    static class Helpers
    {
        internal static ProjectType ToProjectType(string projectType)
        {
            switch (projectType.ToLowerInvariant())
            {
                case "exe":
                    return ProjectType.StandardExe;
                case "oleexe":
                    return ProjectType.ActiveXExe;
                case "oledll":
                    return ProjectType.ActiveXDll;
                case "control":
                    return ProjectType.ActiveXControl;
                default:
                    throw new NotSupportedException(string.Format("Project type '{0}' not supported yet!", projectType));
            }
        }
    	
        internal static string ToSerializableString(ProjectType type)
        {
            switch (type)
            {
                case ProjectType.StandardExe:
                    return "Exe";
                case ProjectType.ActiveXExe:
                    return "OleExe";
                case ProjectType.ActiveXDll:
                    return "OleDll";
                case ProjectType.ActiveXControl:
                    return "Control";
                default:
                    throw new ArgumentException("type");
            }
        }
        
        internal static IEnumerable<ElementBase> GetAllElements(this IVbProject project)
        {
            List<ElementBase> elements = new List<ElementBase>();
            elements.AddRange(project.References);
            elements.AddRange(project.Modules);
            elements.AddRange(project.Objects);
            elements.AddRange(project.Classes);
            elements.AddRange(project.Forms);
            elements.AddRange(project.UserControls);
            return elements;
        }
    }
}
