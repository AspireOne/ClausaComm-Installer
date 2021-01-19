using System;
using System.IO;
using ClausaComm_Installer.ClausaCommManipulation;
using ClausaComm_Installer.Utils;
using IWshRuntimeLibrary;
using File = System.IO.File;

namespace ClausaComm_Installer
{
    public static class ProgramShortcuts
    {
        public enum DeletionSuccess { Full, Partial, None }
        private const string Extension = ".lnk";
        private static readonly string ProgramStartMenuDir = Path.Combine(Paths.StartMenuDir, Program.ClausaCommName);
        private static readonly string ProgramStartMenuShortcut = Path.Combine(ProgramStartMenuDir, Program.ClausaCommName + Extension);
        private static readonly string ProgramDesktopShortcut = Path.Combine(Paths.Desktop, Program.ClausaCommName + Extension);
        private static readonly string UninstallerStartMenuShortcut = Path.Combine(ProgramStartMenuDir, "Uninstall " + Program.ClausaCommName + Extension);
        private static readonly WshShell Shell = new WshShell();

        public static void AddShortcutsToStartMenu(string programPath, string uninstallerExePath)
        {
            if (Directory.Exists(ProgramStartMenuDir))
                Directory.Delete(ProgramStartMenuDir, true);

            Directory.CreateDirectory(ProgramStartMenuDir);

            CreateShortcut(ProgramStartMenuShortcut, programPath, Program.ProgramDescription, null);
            CreateShortcut(UninstallerStartMenuShortcut, uninstallerExePath, Program.ClausaCommName + " uninstaller", ClausaCommUninstallation.UninstallArgument);
        }

        public static void RemoveShortcutsFromStartMenu()
        {
            Directory.Delete(ProgramStartMenuDir, true);
        }

        public static void RemoveProgramShortcutFromDesktop()
        {
            File.Delete(ProgramDesktopShortcut);
        }

        public static void AddProgramShortcutToDesktop(string programPath)
        {
            CreateShortcut(ProgramDesktopShortcut, programPath, Program.ProgramDescription, null);
        }

        public static DeletionSuccess RemoveAllShortcuts()
        {
            bool deletedStartMenuDir = true;

            if (Directory.Exists(ProgramStartMenuDir))
                deletedStartMenuDir = TryDelete(RemoveShortcutsFromStartMenu);

            bool deletedDesktopShortcut = TryDelete(RemoveProgramShortcutFromDesktop);

            return deletedStartMenuDir && deletedDesktopShortcut
                ? DeletionSuccess.Full
                : !deletedStartMenuDir && !deletedDesktopShortcut ? DeletionSuccess.None : DeletionSuccess.Partial;
        }

        private static bool TryDelete(Action action)
        {
            try
            {
                action.Invoke();
                return true;
            }
            catch (Exception e)
            {
                ConsoleUtils.LogAsync(e);
                return false;
            }
        }

        public static void CreateShortcut(string shortcutPath, string target, string description, string argument)
        {
            var shortcut = Shell.CreateShortcut(shortcutPath) as IWshShortcut;
            shortcut.TargetPath = target;

            if (description != null)
                shortcut.Description = description;

            if (argument != null)
                shortcut.Arguments += argument;

            shortcut.Save();
        }
    }
}
