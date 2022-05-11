using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private static readonly string BinariesZipPath = Path.Combine(GlobalPaths.Temp, "ClausaComm_Binaries.zip");
        private readonly string InstallDir;
        private readonly string ClausaCommExePath;
        private readonly string UninstallerExePath;

        public ClausaCommInstallation(string installDir)
        {
            InstallDir = installDir;
            ClausaCommExePath = Path.Combine(InstallDir, Program.ExeName);
            UninstallerExePath = Path.Combine(InstallDir, ClausaCommUninstallation.UninstallerExeName);
        }

        public static bool IsInstalled()
        {
            using (RegistryKey key = RegKey.OpenSubKey(RegistryUninstallPath))
            {
                if (key == null || Directory.Exists(InstallationDir.GetCurrentInstallDirOrNull()))
                    return key != null;
                
                ConsoleUtils.Log("Registry value exists but the actual program directory doesn't. Deleting registry value.");
                TryDoStep(() => RegKey.DeleteSubKey(RegistryUninstallPath));
                return false;

            }
        }

        public void InstallAsync(Action<string> finishedCallback)
        {
            ThreadUtils.RunThread(() => PerformInstallationAsync(finishedCallback), false);
        }

        private void PerformInstallationAsync(Action<string> finishedCallback)
        {
            /*
             * Action: Installation step
             * Action: The reverse action of the step (e.g. 'create a file' -> delete a file)
             * String: A friendly error string.
             */
            string[] extractedFilesFromBinary = { };
            var installationSteps = new[]
            {
                new Tuple<Func<bool>, Action, string>(
                    () =>
                    {
                        if (!Directory.Exists(InstallDir))
                            Directory.CreateDirectory(InstallDir);
                        return true;
                    },
                    () => Directory.Delete(InstallDir),
                    LocalizedStrings.CouldNotExtractBinaries),

                // -> Extract program binaries to program installation folder.
                // <- Delete the extracted files in the installation folder.
                new Tuple<Func<bool>, Action, string>(
                    () =>
                    {
                        ExtractBinaries(out extractedFilesFromBinary);
                        return true;
                    },
                    () => extractedFilesFromBinary.ForEach(File.Delete),
                    LocalizedStrings.CouldNotExtractBinaries),

                // -> Make a copy of the program exe to be used for invoking uninstallation.
                // <- Delete the copied exe.
                new Tuple<Func<bool>, Action, string>(
                    () =>
                    {
                        File.Copy(GlobalPaths.ThisProgram, UninstallerExePath, true);
                        return true;
                    },
                    () => File.Delete(UninstallerExePath),
                    LocalizedStrings.CouldNotCopyInstallerToInstallationDir),

                // -> Add needed registry values.
                // <- Delete the program's subkey in registry.
                new Tuple<Func<bool>, Action, string>(
                    () =>
                    {
                        AddRegistryValues();
                        return true;
                    },
                    () => RegKey.DeleteSubKeyTree(RegistryUninstallPath),
                    LocalizedStrings.CouldNotAddValuesToRegistry),
                
                // -> Add shortcuts to start menu.
                // <- Remove shortcuts from start menu.
                new Tuple<Func<bool>, Action, string>(
                    () => ProgramShortcuts.AddShortcutsToStartMenu(ClausaCommExePath, UninstallerExePath),
                    ProgramShortcuts.RemoveShortcutsFromStartMenu,
                    LocalizedStrings.CouldNotAddShortcutsToStartMenu),

                // -> Add program shortcut to Desktop.
                // <- Remove program shortcut from Desktop.
                new Tuple<Func<bool>, Action, string>(
                    () => ProgramShortcuts.AddProgramShortcutToDesktop(ClausaCommExePath),
                    ProgramShortcuts.RemoveProgramShortcutFromDesktop,
                    LocalizedStrings.CouldNotAddShortcutToDesktop),
                
                // -> Set program to launch on PC startup.
                // <- Set program to not launch on PC startup.
                new Tuple<Func<bool>, Action, string>(
                    () => SetLaunchOnStartup(true),
                    () => SetLaunchOnStartup(false),
                    LocalizedStrings.CouldNotSetLaunchOnStartup),
            };

            // Performs every installation step.
            string error = null;
            for (int instIndex = 0; instIndex < installationSteps.Length; ++instIndex)
            {
                if (TryDoStep(installationSteps[instIndex].Item1))
                    continue;

                // Notes the error of the installation step that threw the error and starts reverting the steps from currIndex - 1.
                error = installationSteps[instIndex].Item3;
                ConsoleUtils.Log("Installation step " + instIndex + " failed. Friendly error msg: " + error);

                for (int uninstIndex = instIndex/* - 1*/; uninstIndex >= 0; --uninstIndex)
                {
                    bool success = TryDoStep(installationSteps[uninstIndex].Item2);
                    ConsoleUtils.Log("Revertion of step " + uninstIndex + " performed | succesfull: " + success);
                }

                break;
            }

            finishedCallback.Invoke(error);
        }

        private static bool TryDoStep(Func<bool> step)
        {
            try
            {
                return step.Invoke();
            }
            catch (Exception e)
            {
                ConsoleUtils.Log("(Un)installation step error: " + e);
                return false;
            }
        }

        private static bool TryDoStep(Action action)
        {
            return TryDoStep(() =>
            {
                action();
                return true;
            });
        }

        private void ExtractBinaries(out string[] extractedFilesPaths)
        {
            File.WriteAllBytes(BinariesZipPath, Resources.binaries);

            string[] filesBeforeExtract = Directory.GetFiles(InstallDir).Concat(Directory.GetDirectories(InstallDir)).ToArray();
            new FastZip().ExtractZip(BinariesZipPath, InstallDir, null);
            string[] filesAfterExtract = Directory.GetFiles(InstallDir).Concat(Directory.GetDirectories(InstallDir)).ToArray();

            extractedFilesPaths = filesAfterExtract.Where(file => !filesBeforeExtract.Contains(file)).ToArray();
            File.Delete(BinariesZipPath);
        }

        // Add to registry so that the program shows up in control panel's uninstall.
        private void AddRegistryValues()
        {
            using RegistryKey key = RegKey.CreateSubKey(RegistryUninstallPath);
            foreach (var pair in GetRegistryKeys())
                key.SetValue(pair.Key, pair.Value);
        }

        private bool SetLaunchOnStartup(bool launch)
        {
            using var registryKey = RegKey.OpenSubKey(RegistryStartupPath, true);
            if (registryKey == null)
            {
                ConsoleUtils.Log("RegistryKey (SubKey) was null when trying to set run at startup.");
                return false;
            }

            try
            {
                if (launch)
                    registryKey.SetValue(Program.Name, $"\"{Path.Combine(InstallDir, Program.ExeName)}\" {Program.MinimizedArgument}");
                else
                    registryKey.DeleteValue(Program.Name, false);

                return true;
            }
            catch (Exception e)
            {
                ConsoleUtils.Log(e);
                return false;
            }
        }

        private IEnumerable<KeyValuePair<string, object>> GetRegistryKeys()
        {
            return new Dictionary<string, object>
            {
                {"NoModify", 0x00000001},
                {"NoRepair", 0x00000001},
                {"Publisher", "Matěj Pešl <matejpesl1@gmail.com>"},
                {"DisplayName", Program.Name},
                {"UninstallString", '"' + Path.Combine(InstallDir, ClausaCommUninstallation.UninstallerExeName) + "\" " + ClausaCommUninstallation.UninstallArgument},
                {"URLInfoAbout", "https://aspireone.github.io/ClausaComm/"},
                {"DisplayIcon", '"' + Path.Combine(InstallDir, Program.ExeName) + '"'},
                {"InstallLocation", '"' + InstallDir + '"'},
                //{ "DisplayVersion", "Release" }
            };
        }
    }
}
