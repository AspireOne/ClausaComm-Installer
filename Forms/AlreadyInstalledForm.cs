using System.Windows.Forms;

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
            InstallationPathLbl.Text = LocalizedStrings.InstallationFolder + ": ";
            InstallationPath.Text = InstallationDir.GetCurrentInstallDirOrNull();
        }
    }
}
