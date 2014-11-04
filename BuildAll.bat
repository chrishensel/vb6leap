SET msbuild = C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe

msbuild "VB6leap\VB6leap.sln" /p:Configuration=Debug /verbosity:minimal

msbuild "Addins\SharpDevelop\VB6leap.SD.sln" /p:Configuration=Debug /verbosity:minimal

pause