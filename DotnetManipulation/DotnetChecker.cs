using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ClausaComm_Installer.Utils;

namespace ClausaComm_Installer.DotnetManipulation
{
    public static class DotnetChecker
    {
        // Let's just hardcore it, hopefully I won't change it and forget about it...
        private const string DemandedVersion = "5.0.0";
        private const string VersionPattern = @"[0-9]\.[0-9]\.[0-9]+";

        private static readonly int[] DemandedVersionNumbers = DemandedVersion.Split('.').Select(str => int.Parse(str)).ToArray();

        public static bool IsDotnetInstalled()
        {
            return GetInstalledRuntimesVersions().Any(IsVersionSupported);
        }

        private static IEnumerable<string> GetInstalledRuntimesVersions()
        {
            var p = new Process { StartInfo = ConsoleUtils.GetProcessStartInfo("dotnet --info", false, false) };
            p.Start();
            p.WaitForExit();
            while (p.StandardOutput.Peek() != -1)
            {
                string line = p.StandardOutput.ReadLine();
                Match versionMatch = Regex.Match(line, VersionPattern);
                if (!line.Contains("Microsoft.AspNetCore.App") && !line.Contains("OS Version") && versionMatch.Success)
                    yield return versionMatch.Value;
            }
            p.Close();
        }

        private static bool IsVersionSupported(string version)
        {
            byte[] numbers = version.Split('.').Select(str => byte.Parse(str.Substring(0, 1))).ToArray();

            return numbers[0] > DemandedVersionNumbers[0] 
                   || numbers[0] == DemandedVersionNumbers[0] && numbers[1] >= DemandedVersionNumbers[1];
            // Not checking the patch version because it's backwards-compatible.
            
            /*return numbers[0] > DemandedVersionNumbers[0]
                   || numbers[0] == DemandedVersionNumbers[0] && numbers[1] > DemandedVersionNumbers[1]
                   || numbers[0] == DemandedVersionNumbers[0] && numbers[1] == DemandedVersionNumbers[1] && numbers[2] >= DemandedVersionNumbers[2];*/
        }
    }
}