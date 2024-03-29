﻿using System;
using ClausaComm_Installer.Utils;
using Microsoft.Win32;

namespace ClausaComm_Installer.ClausaCommManipulation
{
    public class ClausaCommUninstallation : ClausaCommManipulation
    {
        private const int UninstallationDelaySecs = 2;
        public const string UninstallArgument = "/u";
        public const string UninstallerExeName = "uninstaller.exe";


        private ClausaCommUninstallation() {}

        public static void Uninstall(Action<bool> completedCallback)
        {
            // Install dir is taken from registry, so we must first get the path and only then can we delete the registry.
            string installDir = InstallationDir.GetCurrentInstallDirOrNull();

            bool deletedSubkey = TryDoUninstallationStep(() => RegKey.DeleteSubKey(RegistryUninstallPath));
            bool deletedRunOnStartupKey = TryDoUninstallationStep(() =>
            {
                using var key = Registry.CurrentUser.OpenSubKey(RegistryStartupPath, true);
                key.DeleteValue("ClausaComm");
            });
            bool shortcutsDeleted = ProgramShortcuts.RemoveAllShortcuts();

            SetUpUninstallTimer(installDir);

            ConsoleUtils.Log($"Uninstallation completed." +
                             $"\nDeleted subkey: {deletedSubkey}" +
                             $"\nAll shortcuts deleted: {shortcutsDeleted}" +
                             $"\nDeleted RunOnStartup key: {deletedRunOnStartupKey}");

            completedCallback.Invoke(deletedSubkey && deletedRunOnStartupKey && shortcutsDeleted);
        }
        
        private static bool TryDoUninstallationStep(Action action)
        {
            try
            {
                action.Invoke();
                return true;
            }
            catch (Exception e)
            {
                ConsoleUtils.Log("Uninstallation step error: " + e);
                return false;
            }
        }

        /// <summary>Starts a separate process which will wait for x seconds and then delete the passed dir.</summary>
        /// <param name="installDir">The dir which will be deleted - ClausaComm's install dir.</param>
        private static void SetUpUninstallTimer(string installDir)
        {
            ConsoleUtils.RunProcess(ConsoleUtils.GetDelay(UninstallationDelaySecs) + " & rmdir /s /q \"" + installDir + '"', true, true);
        }
    }
}
