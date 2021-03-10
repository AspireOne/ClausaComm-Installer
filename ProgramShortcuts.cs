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
        private const string Extension = ".lnk";

        public static readonly string ProgramStartMenuDir =
            Path.Combine(GlobalPaths.StartMenuDir, Program.ClausaCommName);

        public static readonly string ProgramStartMenuShortcut =
            Path.Combine(ProgramStartMenuDir, Program.ClausaCommName + Extension);

        public static readonly string ProgramDesktopShortcut =
            Path.Combine(GlobalPaths.Desktop, Program.ClausaCommName + Extension);

        public static readonly string UninstallerStartMenuShortcut =
            Path.Combine(ProgramStartMenuDir, "Uninstall " + Program.ClausaCommName + Extension);

        private static readonly WshShell Shell = new WshShell();

        public static bool AddShortcutsToStartMenu(string programPath, string uninstallerPath)
        {
            if (Directory.Exists(ProgramStartMenuDir))
            {
                try
                {
                    Directory.Delete(ProgramStartMenuDir, true);
                }
                catch (Exception e)
                {
                    // Ignored.
                    ConsoleUtils.LogAsync("Could not delete program start menu dir. Exception: " + e);
                }
            }

            Directory.CreateDirectory(ProgramStartMenuDir);

            bool programCreated =
                CreateShortcut(ProgramStartMenuShortcut, programPath, Program.ProgramDescription, null);
            
            bool uninstallerCreated = CreateShortcut(UninstallerStartMenuShortcut, uninstallerPath,
                Program.UninstallerDescription, ClausaCommUninstallation.UninstallArgument);

            if (!(programCreated && uninstallerCreated))
                ConsoleUtils.LogAsync("Could not create program or installer start menu shortcut");

            return programCreated && uninstallerCreated;
        }

        public static void RemoveShortcutsFromStartMenu()
        {
            Directory.Delete(ProgramStartMenuDir, true);
        }

        public static void RemoveProgramShortcutFromDesktop()
        {
            File.Delete(ProgramDesktopShortcut);
        }

        public static bool AddProgramShortcutToDesktop(string programPath)
        {
            bool success = CreateShortcut(ProgramDesktopShortcut, programPath, Program.ProgramDescription, null);
            if (!success)
                ConsoleUtils.LogAsync("Could not create program shortcut on desktop.");

            return success;
        }

        public static bool RemoveAllShortcuts()
        {
            bool deletedStartMenuDir = true;

            if (Directory.Exists(ProgramStartMenuDir))
                deletedStartMenuDir = TryDelete(RemoveShortcutsFromStartMenu);

            bool deletedDesktopShortcut = TryDelete(RemoveProgramShortcutFromDesktop);

            ConsoleUtils.LogAsync("Result of shortcuts deletion:\n program start menu dir deleted: " +
                                  deletedStartMenuDir + "\nDesktop shortcut deleted: " + deletedDesktopShortcut);

            return deletedStartMenuDir && deletedDesktopShortcut;
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
                ConsoleUtils.LogAsync("Could not perform a delete action. Exception: " + e);
                return false;
            }
        }

        public static bool CreateShortcut(string shortcutPath, string target, string description, string argument)
        {
            IWshShortcut shortcut;
            try
            {
                shortcut = Shell.CreateShortcut(shortcutPath) as IWshShortcut;
                shortcut.TargetPath = target;
            }
            catch (Exception e)
            {
                ConsoleUtils.LogAsync("Could not instantiate " + typeof(IWshShortcut) + ". Exception: " + e);
                return false;
            }

            if (description != null)
                shortcut.Description = description;

            if (argument != null)
                shortcut.Arguments += argument;

            try
            {
                shortcut.Save();
            }
            catch (Exception e)
            {
                ConsoleUtils.LogAsync("Could not save shortcut. Exception: " + e);
                return false;
            }

            return true;
        }
    }
}