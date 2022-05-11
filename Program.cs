using System;
using System.Security.Principal;
using System.Windows.Forms;
using System.Linq;
using ClausaComm_Installer.ClausaCommManipulation;
using ClausaComm_Installer.Forms;
using ClausaComm_Installer.Utils;

namespace ClausaComm_Installer
{
    internal static class Program
    {
        public const string Name = "ClausaComm";
        public const string ExeName = Name + ".exe";
        public const string Description = "ClausaComm - a LAN chatting app.";
        public const string MinimizedArgument = "-minimized"; 
        public const string UninstallerDescription = "ClausaComm Uninstaller";
        public static readonly bool AlreadyInstalled = ClausaCommInstallation.IsInstalled();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form formToRun;

            if (AlreadyInstalled)
            {
                if (args.Contains("/u"))
                    formToRun = new UninstallForm();
                else
                    formToRun = new AlreadyInstalledForm();
            }
            else if (!IsUserAdministrator())
                formToRun = new NotAnAdminForm();
            else
                formToRun = new InstallForm();

            ConsoleUtils.Log("____________________\nProgram started [" + DateTime.Now + "]\nForm to run: " + formToRun.GetType());
            Application.Run(formToRun);
        }

        public static void Terminate()
        {
            Application.Exit();
            Environment.Exit(0);
        }

        public static bool IsUserAdministrator()
        {
            try
            {
                var user = WindowsIdentity.GetCurrent();
                var principal = new WindowsPrincipal(user);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch
            {
                return false;
            }
        }
    }
}