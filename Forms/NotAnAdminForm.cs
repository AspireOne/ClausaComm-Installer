using System.Windows.Forms;

namespace ClausaComm_Installer.Forms
{
    public partial class NotAnAdminForm : Form
    {
        public NotAnAdminForm()
        {
            InitializeComponent();
            PleaseRestartAsAdminLbl.Text = LocalizedStrings.PleaseRestartTheInstallerAsAdmin;
            Text = LocalizedStrings.MissingAdminPrivileges;
        }
    }
}