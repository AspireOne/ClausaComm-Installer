using System.Windows.Forms;
using ClausaComm_Installer.Utils;

namespace ClausaComm_Installer.Forms
{
    public partial class AlreadyInstalledForm : Form
    {
        public AlreadyInstalledForm()
        {
            InitializeComponent();
            InitTexts();
        }

        private void InitTexts()
        {
            Text = LocalizedStrings.ClausaCommIsAlreadyInstalled;
            AlreadyInstalledLbl.Text = LocalizedStrings.ClausaCommIsAlreadyInstalled;
            InstallationPathLbl.Text = LocalizedStrings.InstallationFolder + @": ";
            InstallationPath.Text = InstallationDir.GetCurrentInstallDirOrNull();
            OpenUninstallerButton.Text = LocalizedStrings.OpenUninstallationFile;
            CloseButton.Text = LocalizedStrings.Close;
        }

        private void CloseButton_Click(object sender, System.EventArgs e)
        {
            Program.Terminate();
        }

        private void OpenUninstallerButton_Click(object sender, System.EventArgs e)
        {
            ConsoleUtils.RunProcess('"' + ProgramShortcuts.UninstallerStartMenuShortcut + '"', false, false);
            Program.Terminate();
        }
    }
}
