using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClausaComm_Installer
{

    internal static class LocalizedStrings
    {
        private enum Language
        {
            English,
            Czech
        };

        // Creating a dict and then converting it to keyvaluepair because we couldn't use inline initialization otherwise.
        private static readonly KeyValuePair<Language, string>[] LangCodes = new Dictionary<Language, string>
        {
            {Language.Czech, "cs"},
            {Language.English, "en"}
        }.ToArray();

        private static readonly Language CurrLang = InitCurrLang();

        private static Language InitCurrLang()
        {
            var langPair = LangCodes.FirstOrDefault(x => x.Value == CultureInfo.CurrentUICulture.TwoLetterISOLanguageName);

            if (langPair.Equals(default(KeyValuePair<Language, string>)))
                return Language.English;

            return langPair.Key;
        }

        /*
         * The rules below are just general guidelines, but practically, every specific instance and a specific context has it's string
         * stored in this class without being meant (or be able) to be reused, and many of them slightly violate those guidelines.
         *
         *
         * Normally named properties are full sentences or words (e.g. beginning with an upper case letter and ending with a punctuation,
         * except for some specific instances and some words, which may not end with a punctuation or start with an uppercase letter).
         *
         * Properties beginning with a _ (underscore) are not full senteces, but rather just a part of sentence. They most of the times
         * begin with a lower case letter and don't end with a punctuation, and are usually private, helping "full-sentence" properties
         * (adressed above) to put together the sentence.
         *
         * The names of the properties should be the exact string contained without special characters, except for some specific instances,
         * where the name of the property may be the point the string is adressing, e.g. "property SuccesfullInstallation | string "The
         * installation was succesfull").
         *
        */

        public static string InstalledSuccesfully
        {
            get
            {
                switch (CurrLang)
                {
                    case Language.English:
                        return "Installed succesfully!";
                    case Language.Czech:
                        return "Úspěšně nainstalováno!";
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public static string OpenUninstallationFile
        {
            get
            {
                switch (CurrLang)
                {
                    case Language.English:
                        return "Open uninstaller";
                    case Language.Czech:
                        return "Otevřít odinstalační soubor";
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public static string MissingAdminPrivileges
        {
            get
            {
                switch (CurrLang)
                {
                    case Language.English:
                        return "Missing administrator privileges";
                    case Language.Czech:
                        return "Chybí administrátorská práva";
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public static string PleaseRestartTheInstallerAsAdmin
        {
            get
            {
                switch (CurrLang)
                {
                    case Language.English:
                        return "Please restart the installer as admin.";
                    case Language.Czech:
                        return "Restartujte, prosím, instalační program jako administrátor.";
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public static string DoYouReallyWishToUninstallClausaComm
        {
            get
            {
                switch (CurrLang)
                {
                    case Language.English:
                        return "Do you really wish to uninstall ClausaComm?";
                    case Language.Czech:
                        return "Opravdu si přejete ClausaComm odinstalovat?";
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public static string ClausaCommUninstallation
        {
            get
            {
                switch (CurrLang)
                {
                    case Language.English:
                        return "ClausaComm uninstallation";
                    case Language.Czech:
                        return "ClausaComm odinstalace";
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public static string InstallationFolder
        {
            get
            {
                switch (CurrLang)
                {
                    case Language.English:
                        return "Installation folder";
                    case Language.Czech:
                        return "Instalační složka";
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public static string ClausaCommIsAlreadyInstalled
        {
            get
            {
                switch (CurrLang)
                {
                    case Language.English:
                        return "ClausaComm is already installed.";
                    case Language.Czech:
                        return "ClausaComm je už nainstalován.";
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public static string CouldNotAddValuesToRegistry
        {
            get
            {
                switch (CurrLang)
                {
                    case Language.English:
                        return "Could not add values to registry.";
                    case Language.Czech:
                        return "Nepovedlo se přidat hodnoty do registru.";
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public static string CouldNotAddShortcutToDesktop
        {
            get
            {
                switch (CurrLang)
                {
                    case Language.English:
                        return "Could not add shortcut to desktop.";
                    case Language.Czech:
                        return "Nepovedlo se přidat zástupce na plochu.";
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public static string CouldNotAddShortcutsToStartMenu
        {
            get
            {
                switch (CurrLang)
                {
                    case Language.English:
                        return "Could not add shortcuts to start menu.";
                    case Language.Czech:
                        return "Nepovedlo se přidat zástupce do start menu.";
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public static string CouldNotCopyInstallerToInstallationDir
        {
            get
            {
                switch (CurrLang)
                {
                    case Language.English:
                        return "Could not copy installer to installation dir.";
                    case Language.Czech:
                        return "Nepovedlo se zkopírovat instalační soubor do instalační složky.";
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public static string CouldNotExtractBinaries
        {
            get
            {
                switch (CurrLang)
                {
                    case Language.English:
                        return "Could not extract binaries.";
                    case Language.Czech:
                        return "Nelze extrahovat zip se soubory.";
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public static string YouCanAlsoInstallItManually
        {
            get
            {
                switch (CurrLang)
                {
                    case Language.English:
                        return "You can also install it manually.";
                    case Language.Czech:
                        return "Můžete to také nainstalovat manuálně.";
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public static string SelectClausaCommInstallFolder
        {
            get
            {
                switch (CurrLang)
                {
                    case Language.English:
                        return "Select ClausaComm installation folder";
                    case Language.Czech:
                        return "Vyberte složku, kde bude nainstalován ClausaComm";
                    default:
                        throw new NotImplementedException();
                }
            }
        }


        public static string ClausaCommInstaller
        {
            get
            {
                switch (CurrLang)
                {
                    case Language.English:
                        return "ClausaComm Installer";
                    case Language.Czech:
                        return "ClausaComm Instalační soubor";
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public static string ClausaCommInstallation
        {
            get
            {
                switch (CurrLang)
                {
                    case Language.English:
                        return "ClausaComm Installation";
                    case Language.Czech:
                        return "ClausaComm Instalace";
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public static string RemoveThisInstallationFile
        {
            get
            {
                switch (CurrLang)
                {
                    case Language.English:
                        return "Remove this installation file";
                    case Language.Czech:
                        return "Smazat tento instalační soubor";
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public static string Uninstall
        {
            get
            {
                switch (CurrLang)
                {
                    case Language.English:
                        return "Uninstall";
                    case Language.Czech:
                        return "Odinstalovat";
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public static string Cancel
        {
            get
            {
                switch (CurrLang)
                {
                    case Language.English:
                        return "Cancel";
                    case Language.Czech:
                        return "Zrušit";
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public static string DotnetNotInstalledDoYouWantToDownloadAndInstallNow
        {
            get
            {
                switch (CurrLang)
                {
                    case Language.English:
                        return ".NET 5 is not installed. Do you want to download and install it now?";
                    case Language.Czech:
                        return ".NET 5 není nainstalován. Chcete ho stáhnout a nainstalovat teď?";
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public static string WhereDoYouWantToInstallClausaCommTo
        {
            get
            {
                switch (CurrLang)
                {
                    case Language.English:
                        return "Where do you want to install ClausaComm to?";
                    case Language.Czech:
                        return "Kam chcete ClausaComm nainstalovat?";
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public static string Install
        {
            get
            {
                switch (CurrLang)
                {
                    case Language.English:
                        return "Install";
                    case Language.Czech:
                        return "Instalovat";
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public static string Close
        {
            get
            {
                switch (CurrLang)
                {
                    case Language.English:
                        return "Close";
                    case Language.Czech:
                        return "Zavřít";
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public static string Error
        {
            get
            {
                switch (CurrLang)
                {
                    case Language.English:
                        return "Error";
                    case Language.Czech:
                        return "Chyba";
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public static string CouldNotInstall
        {
            get
            {
                switch (CurrLang)
                {
                    case Language.English:
                        return "Could not install.";
                    case Language.Czech:
                        return "Instalace neúspěšná.";
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public static string InstallingClausaComm
        {
            get
            {
                switch (CurrLang)
                {
                    case Language.English:
                        return "Installing ClausaComm...";
                    case Language.Czech:
                        return "Instalace ClausaComm...";
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public static string DotnetInstalledClausaCommMayNotBeAbleToStartUntilPcRestart
        {
            get
            {
                switch (CurrLang)
                {
                    case Language.English:
                        return ".NET Installed! ClausaComm may not be able to start until you restart your PC.";
                    case Language.Czech:
                        return ".NET naistalován! ClausaComm možná nebude moci fungovat dokud nerestartujete PC.";
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public static string Reinstall
        {
            get
            {
                switch (CurrLang)
                {
                    case Language.English:
                        return "Reinstall";
                    case Language.Czech:
                        return "Reinstalovat";
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public static string Uninstalling
        {
            get
            {
                switch (CurrLang)
                {
                    case Language.English:
                        return "Uninstalling...";
                    case Language.Czech:
                        return "Odinstalace...";
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public static string SuccesfullyUninstalledTheProgramWillNowClose
        {
            get
            {
                switch (CurrLang)
                {
                    case Language.English:
                        return "Succesfully uninstalled, the program will now close...";
                    case Language.Czech:
                        return "Úspěšně odinstalováno, program se teď zavře...";
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public static string CouldNotUninstall
        {
            get
            {
                switch (CurrLang)
                {
                    case Language.English:
                        return "Could not uninstall.";
                    case Language.Czech:
                        return "Odinstalace neúspěšná.";
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public static string Downloading
        {
            get
            {
                switch (CurrLang)
                {
                    case Language.English:
                        return "Downloading...";
                    case Language.Czech:
                        return "Stahování...";
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public static string Installing
        {
            get
            {
                switch (CurrLang)
                {
                    case Language.English:
                        return "Installing...";
                    case Language.Czech:
                        return "Instalace...";
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public static string TheChosenPathDoesntExist
        {
            get
            {
                switch (CurrLang)
                {
                    case Language.English:
                        return "The chosen path doesn't exist.";
                    case Language.Czech:
                        return "Vybraná cesta neexistuje.";
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        private static string _PleaseInstallDotnetManually
        {
            get
            {
                switch (CurrLang)
                {
                    case Language.English:
                        return "please install .NET manually";
                    case Language.Czech:
                        return "nainstalujte prosím .NET manuálně";
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public static string CouldNotDownloadPleaseInstallDotnetManually
        {
            get
            {
                switch (CurrLang)
                {
                    case Language.English:
                        return "Could not download, " + _PleaseInstallDotnetManually + ".";
                    case Language.Czech:
                        return "Nelze stáhnout, " + _PleaseInstallDotnetManually + ".";
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public static string CouldNotInstallPleaseDownloadDotnetManually
        {
            get
            {
                switch (CurrLang)
                {
                    case Language.English:
                        return "Could not install, " + _PleaseInstallDotnetManually + ".";
                    case Language.Czech:
                        return "Nelze nainstalovat, " + _PleaseInstallDotnetManually + ".";
                    default:
                        throw new NotImplementedException();
                }
            }
        }
    }
}
