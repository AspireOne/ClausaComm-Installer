using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;
using System.Linq;
using ClausaComm_Installer.ClausaCommManipulation;
using ClausaComm_Installer.Forms;
using ClausaComm_Installer.Utils;

namespace ClausaComm_Installer
{
    internal static class Program
    {
        public const string ClausaCommName = "ClausaComm";
        public const string ClausaCommExeName = ClausaCommName + ".exe";
        public const string ProgramDescription = "ClausaComm - a LAN chatting app.";
        public const string InstallerExeName = "ClausaComm Installer.exe";
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

            ConsoleUtils.LogAsync("____________________\nProgram started [" + DateTime.Now + "]");
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
