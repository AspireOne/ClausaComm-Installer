using System;
using System.IO;
using System.Windows.Forms;
using ClausaComm_Installer.Utils;
using Microsoft.Win32;

namespace ClausaComm_Installer
{
    public static class InstallationDir
    {
        // Program Files (x86) may not (or always does not, doesn't matter :D) exist on 32-bit machines, so we're checking for it's existence
        // and if it doesn't exist, we're using Program Files instead - which exists always.
        public static readonly string DefaultInstallationDir = Directory.Exists(GlobalPaths.ProgramFilesx86)
            ? GlobalPaths.ProgramFilesx86
            : GlobalPaths.ProgramFiles;
        
        private static readonly FolderBrowserDialog Dialog = new FolderBrowserDialog
        {
            Description = LocalizedStrings.SelectClausaCommInstallFolder,
            RootFolder = Environment.SpecialFolder.ProgramFiles,
            ShowNewFolderButton = false
        };
        public const string DirName = Program.ClausaCommName;

        public static string ConcatPathToProgramDir(string path)
        {
            return Path.Combine(path, DirName);
        }

        public static string GetCurrentInstallDirOrNull()
        {
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(ClausaCommManipulation.ClausaCommManipulation.ClausaCommSubkeyPath))
                return key == null ? null : key.GetValue("InstallLocation").ToString().Replace("\"", "");
        }

        public static void OpenSelectDirDialogAsync(Action<string> callback)
        {
            ThreadUtils.RunThread(() =>
            {
                Dialog.ShowDialog();
                callback.Invoke(Dialog.SelectedPath);
            }, true);
        }
    }
}
