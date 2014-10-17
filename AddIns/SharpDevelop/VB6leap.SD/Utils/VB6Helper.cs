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
using System.Diagnostics;
using System.IO;
using System.Linq;
using VB6leap.SD.Options;
using VB6leap.Vbp.Project;

namespace VB6leap.SD.Utils
{
    static class VB6Helper
    {
        internal static string GetVB6Path()
        {
            return Path.Combine(AddInOptions.Vb6IdePath, "VB6.EXE");
        }

        internal static bool GetIsVB6Available()
        {
            return File.Exists(GetVB6Path());
        }

        internal static MakeResult MakeProject(IVbProject project)
        {
            MakeResult result = new MakeResult();

            try
            {
                result.Results = MakeProjectCore(project).ToArray();

                // HACK: This is not too good. Should be refactored.
                if (result.Results.Length == 1 && result.Results[0].ToLowerInvariant().Contains("succeeded"))
                {
                    result.Results = new string[0];
                }
            }
            catch (Exception ex)
            {
                result.Results = new string[] { ex.Message };
            }

            return result;
        }

        private static IEnumerable<string> MakeProjectCore(IVbProject project)
        {
            string outFilePath = Path.GetTempFileName();
            string arguments = string.Format("/make \"{0}\" /out \"{1}\"", project.Source.FullName, outFilePath);

            using (Process process = new Process())
            {
                process.StartInfo.FileName = GetVB6Path();
                process.StartInfo.Arguments = arguments;

                process.Start();
                process.WaitForExit();
            }

            return File.ReadAllLines(outFilePath).Where(_ => !string.IsNullOrWhiteSpace(_));
        }

        internal static void RunProject(IVbProject project)
        {
            string arguments = string.Format("/run \"{0}\"", project.Source.FullName);

            using (Process process = new Process())
            {
                process.StartInfo.FileName = GetVB6Path();
                process.StartInfo.Arguments = arguments;

                process.Start();
                process.WaitForExit();
            }
        }

        internal class MakeResult
        {
            public string[] Results { get; set; }
        }

    }
}
