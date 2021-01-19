using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ClausaComm_Installer.Properties;
using ClausaComm_Installer.Utils;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.Win32;

namespace ClausaComm_Installer.ClausaCommManipulation
{
    public class ClausaCommInstallation : ClausaCommManipulation
    {
        private static readonly string BinariesZipPath = Path.Combine(Paths.Temp, "ClausaComm_Binaries.zip");

        private readonly string InstallDir;
        private readonly string ClausaCommExePath;
        private readonly string UninstallerExePath;

        public ClausaCommInstallation(string installDir)
        {
            InstallDir = installDir;
            ClausaCommExePath = Path.Combine(InstallDir, Program.ClausaCommExeName);
            UninstallerExePath = Path.Combine(InstallDir, ClausaCommUninstallation.UninstallerExeName);
        }

        public static bool IsInstalled()
        {
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(ClausaCommSubkeyPath))
                return key != null;
        }

        public void InstallAsync(Action<string> finishedCallback)
        {
            ThreadUtils.RunThread(() => PerformInstallationAsync(finishedCallback), false);
        }

        private void PerformInstallationAsync(Action<string> finishedCallback)
        {
             string[] extractedFilesFromBinary = { };
            /*
             * Action: Installation step
             * Action: The reverse action of the step (e.g. 'create a file' -> delete a file)
             * String: A friendly error string.
             */
            var installationSteps = new Tuple<Action, Action, string>[]
            {
                new Tuple<Action, Action, string>(
                    () => ExtractBinaries(out extractedFilesFromBinary),
                    () => extractedFilesFromBinary.ForEach(File.Delete),
                    LocalizedStrings.CouldNotExtractBinaries),

                new Tuple<Action, Action, string>(
                    () => File.Copy(Paths.ThisProgram, UninstallerExePath, true),
                    () => File.Delete(UninstallerExePath),
                    LocalizedStrings.CouldNotCopyInstallerToInstallationDir),

                new Tuple<Action, Action, string>(
                    AddRegistryValues,
                    () => Registry.LocalMachine.DeleteSubKeyTree(ClausaCommSubkeyPath),
                    LocalizedStrings.CouldNotAddValuesToRegistry),

                new Tuple<Action, Action, string>(
                    () => ProgramShortcuts.AddShortcutsToStartMenu(ClausaCommExePath, UninstallerExePath),
                    ProgramShortcuts.RemoveShortcutsFromStartMenu,
                    LocalizedStrings.CouldNotAddShortcutsToStartMenu),

                new Tuple<Action, Action, string>(
                    () => ProgramShortcuts.AddProgramShortcutToDesktop(ClausaCommExePath),
                    ProgramShortcuts.RemoveProgramShortcutFromDesktop,
                    LocalizedStrings.CouldNotAddShortcutToDesktop),
            };

            // Performs every installation step.
            string error = null;
            for (int instIndex = 0; instIndex < installationSteps.Length; ++instIndex)
            {
                if (TryDoInstallationStep(installationSteps[instIndex].Item1))
                {
                    ConsoleUtils.LogAsync("Installation step " + instIndex + " performed.");
                    continue;
                }

                // Notes the error of the installation step that threw the error and starts reverting the steps from currIndex - 1.
                error = installationSteps[instIndex].Item3;
                ConsoleUtils.LogAsync("Installation step " + instIndex + " failed. Friendly error msg: " + error);

                for (int uninstIndex = instIndex/* - 1*/; uninstIndex >= 0; --uninstIndex)
                {
                    bool success = TryDoInstallationStep(installationSteps[uninstIndex].Item2);
                    ConsoleUtils.LogAsync("Revertion of step " + uninstIndex + " performed | succesfull: " + success);
                }

                break;
            }

            Finish(error, finishedCallback);
        }

        private static void Finish(string friendlyErrorMsg, Action<string> finishedCallback)
        {
            finishedCallback.Invoke(friendlyErrorMsg);
        }

        private static bool TryDoInstallationStep(Action step)
        {
            try
            {
                step.Invoke();
                return true;
            }
            catch (Exception e)
            {
                ConsoleUtils.LogAsync("(Un)installation step error: " + e);
                return false;
            }
        }

        private void ExtractBinaries(out string[] extractedFilesPaths)
        {
            if (!Directory.Exists(InstallDir))
                Directory.CreateDirectory(InstallDir);

            File.WriteAllBytes(BinariesZipPath, Resources.binaries);

            string[] filesBeforeExtract = Directory.GetFiles(InstallDir).Concat(Directory.GetDirectories(InstallDir)).ToArray();

            var unzipper = new FastZip();
            unzipper.ExtractZip(BinariesZipPath, InstallDir, null);

            string[] filesAfterExtract = Directory.GetFiles(InstallDir).Concat(Directory.GetDirectories(InstallDir)).ToArray();

            extractedFilesPaths = filesAfterExtract.Where(file => !filesBeforeExtract.Contains(file)).ToArray();
            File.Delete(BinariesZipPath);
        }

        // Add to registry so that the program shows up in control panel's uninstall.
        private void AddRegistryValues()
        {
            //TODO: Make this safer - try to not pass a whole ass path to createsubkey()
            using (RegistryKey key = Registry.LocalMachine.CreateSubKey(ClausaCommSubkeyPath))
            {
                foreach (var pair in GetRegistryKeys())
                    key.SetValue(pair.Key, pair.Value);
            }
        }

        private IEnumerable<KeyValuePair<string, object>> GetRegistryKeys()
        {
            return new Dictionary<string, object>
            {
                {"NoModify", 0x00000001},
                {"NoRepair", 0x00000001},
                {"Publisher", "Matěj Pešl <matejpesl1@gmail.com>"},
                {"DisplayName", Program.ClausaCommName},
                {"UninstallString", '"' + Path.Combine(InstallDir, ClausaCommUninstallation.UninstallerExeName) + "\" " + ClausaCommUninstallation.UninstallArgument},
                {"URLInfoAbout", "https://aspireone.github.io/ClausaComm/"},
                {"DisplayIcon", '"' + Path.Combine(InstallDir, Program.ClausaCommExeName) + '"'},
                {"InstallLocation", '"' + InstallDir + '"'},
                //{ "DisplayVersion", "Release" }
            };
        }
    }
}
