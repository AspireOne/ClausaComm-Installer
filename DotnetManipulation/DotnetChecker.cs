using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using ClausaComm_Installer.Utils;

namespace ClausaComm_Installer.DotnetManipulation
{
    public static class DotnetChecker
    {
        // Let's just hardcore it, hopefully I won't change it and forget about it...
        public const string DemandedVersion = "5.0.0";

        private static readonly int[] DemandedVersionNumbers =
            DemandedVersion.Split('.').Select(str => int.Parse(str)).ToArray();

        private static readonly string DotnetPath = Path.Combine(Paths.ProgramFiles, "dotnet");
        private static readonly string Dotnetx86Path = Path.Combine(Paths.ProgramFilesx86, "dotnet");

        private static readonly string[] RuntimeTypes = {"Microsoft.NETCore.App", "Microsoft.WindowsDesktop.App"};
        private const string RuntimesRetrievalCommand = "dotnet --list-runtimes";

        private static readonly ProcessStartInfo ListRuntimesStartInfo =
            ConsoleUtils.GetProcessStartInfo(RuntimesRetrievalCommand, false, false);


        public static bool IsDotnetInstalled()
        {
            return GetInstalledRuntimes().Select(runtime => runtime.Split(' ')[1]).Any(IsVersionSupported);
        }

        private static IEnumerable<string> GetInstalledRuntimes()
        {
            string output = "";
            int method = 0;
            while (true)
            {
                var p = new Process {StartInfo = ListRuntimesStartInfo};
                switch (method)
                {
                    case 0:
                        break;
                    case 1:
                        p.StartInfo.Arguments = "/C cd " + '"' + DotnetPath + '"' + " & " + RuntimesRetrievalCommand;
                        break;
                    case 2:
                        p.StartInfo.Arguments = "/C cd " + '"' + Dotnetx86Path + '"' + " & " + RuntimesRetrievalCommand;
                        break;
                }

                try
                {
                    p.Start();
                    output += "\n" + p.StandardOutput.ReadToEnd().Trim();
                    p.WaitForExit();
                }
                catch (Exception e)
                {
                    ConsoleUtils.LogAsync(e);
                    // Ignored.
                }

                if (method != 2)
                    ++method;
                else
                    break;
            }

            return output == string.Empty
                ? new string[] { }
                : output.Split('\n').Where(line => RuntimeTypes.Any(line.StartsWith)).ToArray();
        }

        private static bool IsVersionSupported(string version)
        {
            byte[] numbers = version.Split('.').Select(str => byte.Parse(str)).ToArray();

            return numbers[0] > DemandedVersionNumbers[0]
                   || numbers[0] == DemandedVersionNumbers[0] && numbers[1] > DemandedVersionNumbers[1]
                   || numbers[0] == DemandedVersionNumbers[0] && numbers[1] == DemandedVersionNumbers[1] && numbers[2] >= DemandedVersionNumbers[2];
        }
    }
}