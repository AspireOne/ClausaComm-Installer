using Microsoft.Win32;

namespace ClausaComm_Installer.ClausaCommManipulation
{
    public abstract class ClausaCommManipulation
    {
        public const string RegistryStartupPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
        public const string RegistryUninstallPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\" + ClausaCommSubkeyName;
        private const string ClausaCommSubkeyName = Program.Name;
        public static readonly RegistryKey RegKey = Registry.CurrentUser;
    }
}
