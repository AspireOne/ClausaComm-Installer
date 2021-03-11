using System.Windows.Forms;

namespace ClausaComm_Installer.Forms
{
    public partial class NotAnAdminForm : Form
    {
        public sealed override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }
        
        public NotAnAdminForm()
        {
            InitializeComponent();
            PleaseRestartAsAdminLbl.Text = LocalizedStrings.PleaseRestartTheInstallerAsAdmin;
            Text = LocalizedStrings.MissingAdminPrivileges;
        }
    }
}