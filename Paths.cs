using System;
using System.Diagnostics;
using System.IO;
using ClausaComm_Installer.ClausaCommManipulation;
using ClausaComm_Installer.Utils;

namespace ClausaComm_Installer
{
    public static class Paths
    {
        // Environment.SpecialFolder.ProgramFiles returns x86 folder if the targeted system is x86, so we're working around that.
        private const string ProgramFilesx86Addition = " (x86)";

        public static readonly string ProgramFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles).Replace(ProgramFilesx86Addition, "");
        public static readonly string ProgramFilesx86 = InitProgramFilesx86Path();
        public static readonly string Temp = Path.GetTempPath();
        public static readonly string ThisProgram = InitProgramPath();
        public static readonly string Desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        public static readonly string System32 = Environment.SystemDirectory;
        public static readonly string StartMenuDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.StartMenu), "Programs");


        private static string InitProgramPath()
        {
            string filename = TryAndCatchNullReference(() => Process.GetCurrentProcess().MainModule.FileName);

            if (filename != null)
                return Path.Combine(Directory.GetCurrentDirectory(), filename);

            string path = TryAndCatchNullReference(() => System.Reflection.Assembly.GetEntryAssembly().Location);

            if (path != null)
                return path;

            string installerGuessedPath1 = Path.Combine(Directory.GetCurrentDirectory(), "ClausaComm Installer.exe");
            string installerGuessedPath2 = Path.Combine(Directory.GetCurrentDirectory(), "ClausaComm.Installer.exe");
            string uninstallerGuessedPath = Path.Combine(Directory.GetCurrentDirectory(), ClausaCommUninstallation.UninstallerExeName);

            if (File.Exists(installerGuessedPath1))
                return installerGuessedPath1;

            if (File.Exists(installerGuessedPath2))
                return installerGuessedPath2;

            if (File.Exists(uninstallerGuessedPath))
                return uninstallerGuessedPath;

            return null;
        }

        private static string TryAndCatchNullReference(Func<string> function)
        {
            try
            {
                return function.Invoke();
            }
            catch (NullReferenceException e)
            {
                ConsoleUtils.LogAsync(e);
                return null;
            }
        }

        private static string InitProgramFilesx86Path()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            return path.EndsWith(ProgramFilesx86Addition) ? path : path + ProgramFilesx86Addition;
        }
    }
}
