using System;
using System.Threading;
using System.Windows.Forms;
using ClausaComm_Installer.ClausaCommManipulation;
using ClausaComm_Installer.Utils;

namespace ClausaComm_Installer.Forms
{
    public partial class UninstallForm : Form
    {
        public UninstallForm()
        {
            InitializeComponent();
            InitTexts();
        }

        private void InitTexts()
        {
            DoYouWishToUninstallLbl.Text = LocalizedStrings.DoYouReallyWishToUninstallClausaComm;
            Text = LocalizedStrings.ClausaCommUninstallation;
            UninstallButton.Text = LocalizedStrings.Uninstall;
            CancelButton.Text = LocalizedStrings.Cancel;
        }

        private void UninstallButton_Click(object sender, EventArgs e)
        {
            UninstallButton.Enabled = false;
            UninstallationProgress.Text = LocalizedStrings.Uninstalling;
            ClausaCommUninstallation.Uninstall(UninstallCompletedCallback);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Program.Terminate();
        }

        private void UninstallCompletedCallback(bool success)
        {
            string progressText;
            if (success)
            {
                progressText = LocalizedStrings.SuccesfullyUninstalledTheProgramWillNowClose;
                ThreadUtils.RunThread(() =>
                {
                    Thread.Sleep(1000);
                    Program.Terminate();
                }, true);
            }
            else
            {
                progressText = LocalizedStrings.CouldNotUninstall;
            }

            InvokeOnMainThread(() => UninstallationProgress.Text = progressText);
        }

        private void InvokeOnMainThread(Action action)
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(action.Invoke));
            else
                action.Invoke();
        }
    }
}
