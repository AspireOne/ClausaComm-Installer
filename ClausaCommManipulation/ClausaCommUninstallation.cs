using System;
using ClausaComm_Installer.Utils;
using Microsoft.Win32;

namespace ClausaComm_Installer.ClausaCommManipulation
{
    public class ClausaCommUninstallation : ClausaCommManipulation
    {
        private const int UninstallationDelaySecs = 10;
        public const string UninstallArgument = "/u";
        public const string UninstallerExeName = "uninstaller.exe";


        private ClausaCommUninstallation() {}

        public static void Uninstall(Action<bool> completedCallback)
        {
            // Install dir is taken from registry, so we must first get the path and only then can we delete the registry.
            string installDir = InstallationDir.GetCurrentInstallDirOrNull();

            bool deletedSubkey = TryDoUninstallationStep(() => Registry.LocalMachine.DeleteSubKey(ClausaCommSubkeyPath));
            ProgramShortcuts.DeletionSuccess shortcutsDeletion = ProgramShortcuts.RemoveAllShortcuts();

            SetUpUninstallTimer(installDir);

            ConsoleUtils.LogAsync("Uninstallation completed.\ndeleted subkey: " + deletedSubkey + "\nshortcuts deletion: " + shortcutsDeletion);

            completedCallback.Invoke(deletedSubkey);
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
                ConsoleUtils.LogAsync("Uninstallation step error: " + e);
                return false;
            }
        }

        private static void SetUpUninstallTimer(string installDir)
        {
            ConsoleUtils.RunProcess(ConsoleUtils.GetDelay(UninstallationDelaySecs) + " & rmdir /s /q \"" + installDir + '"', true, true);
        }
    }
}
