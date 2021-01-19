using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Windows.Forms;
using ClausaComm_Installer.ClausaCommManipulation;
using ClausaComm_Installer.DotnetManipulation;
using ClausaComm_Installer.Utils;

namespace ClausaComm_Installer.Forms
{
    public partial class InstallForm : Form
    {
        // C# 3
        public InstallForm()
        {
            InitializeComponent();
            InitComponentsText();

            // If .NET 5 is not installed (dotnet not installed panel is visible), disable Install button and vice versa.
            DotnetNotInstalledPanel.VisibleChanged += (o, e) => InstallButton.Enabled = !DotnetNotInstalledPanel.Visible;
            DotnetNotInstalledPanel.Visible = !DotnetChecker.IsDotnetInstalled();
            InstallationPathTextbox.Text = InstallationDir.DefaultInstallationDir;
        }

        private void InitComponentsText()
        {
            InstallButton.Text = LocalizedStrings.Install;
            DotnetInstallButton.Text = LocalizedStrings.Install;
            InstallationLocationQuestion.Text = LocalizedStrings.WhereDoYouWantToInstallClausaCommTo;
            Title.Text = LocalizedStrings.ClausaCommInstallation;
            DotnetInstalledLabel.Text = LocalizedStrings.DotnetNotInstalledDoYouWantToDownloadAndInstallNow;
            CloseButton.Text = LocalizedStrings.Close;
            Text = LocalizedStrings.ClausaCommInstaller;
            ManualDownloadLink.Text = LocalizedStrings.YouCanAlsoInstallItManually;
            RemoveInstallerCheckbox.Text = LocalizedStrings.RemoveThisInstallationFile;
        }

        private void DotnetInstallButton_Click(object sender, EventArgs e)
        {
            DotnetInstallButton.Enabled = false;
            DotnetInstallProgress.Text = LocalizedStrings.Downloading;
            DotnetInstallator.DownloadDotnetAsync(DownloadProgressUpdateCallback, DotnetDownloadFinishedCallback);
        }

        private void DotnetDownloadFinishedCallback(object _, AsyncCompletedEventArgs e)
        {
            ConsoleUtils.LogAsync(".NET download finished. Cancelled: " + e.Cancelled + " | Error: " + e.Error);

            if (e.Error != null || e.Cancelled)
            {
                InvokeOnMainThread(() =>
                {
                    DotnetInstallProgress.Text =  LocalizedStrings.CouldNotDownloadPleaseInstallDotnetManually;
                    DotnetInstallationProgressBar.Style = ProgressBarStyle.Continuous;
                    DotnetInstallationProgressBar.Value = 0;
                    
                });
                return;
            }

            InvokeOnMainThread(() =>
            {
                DotnetInstallProgress.Text = LocalizedStrings.Installing;
                DotnetInstallationProgressBar.Style = ProgressBarStyle.Marquee;
                DotnetInstallator.InstallDotnetAsync(InstallationFinishedCallback);
            });
        }

        private void InstallationFinishedCallback(bool succesfull)
        {
            DotnetInstallator.DeleteDotnetInstallatorFile();

            byte barValue = 0;
            string installProgress;
            bool installButtonEnabled = false;

            if (succesfull)
            {
                installProgress = LocalizedStrings.DotnetInstalledClausaCommMayNotBeAbleToStartUntilPcRestart;
                barValue = 100;
                installButtonEnabled = true;
            }
            else
            {
                DotnetInstallator.OpenDotnetInstallWebsite();
                installProgress = LocalizedStrings.CouldNotInstallPleaseDownloadDotnetManually;
            }

            InvokeOnMainThread(() =>
            {
                DotnetInstallationProgressBar.Style = ProgressBarStyle.Continuous;
                DotnetInstallationProgressBar.Value = barValue;
                DotnetInstallProgress.Text = installProgress;
                InstallButton.Enabled = installButtonEnabled;
            });
        }

        private void DownloadProgressUpdateCallback(object _, DownloadProgressChangedEventArgs e)
        {
            DotnetInstallationProgressBar.Value = e.ProgressPercentage;
        }

        private void ManualDotnetInstallLink_Clicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DotnetInstallator.OpenDotnetInstallWebsite();
        }

        private void InstallButton_Click(object sender, EventArgs e)
        {
            string directory = InstallationPathTextbox.Text;

            if (!Directory.Exists(directory))
            {
                ClausaCommInstallationProgress.Text = LocalizedStrings.TheChosenPathDoesntExist;
                return;
            }

            ClausaCommInstallationProgress.Text = LocalizedStrings.InstallingClausaComm;
            InstallButton.Enabled = false;
            string installationDir = InstallationDir.ConcatPathToProgramDir(directory);

            new ClausaCommInstallation(installationDir).InstallAsync(ClausaCommInstallFinished);
        }

        private void ClausaCommInstallFinished(string error)
        {
            InvokeOnMainThread(() =>
            {
                if (error == null)
                {
                    ClausaCommInstallationProgress.Text = LocalizedStrings.InstalledSuccesfully;
                    ClosePanel.Visible = true;
                    foreach (Control c in InstallationPathSelectionPanel.Controls)
                        c.Enabled = false;
                    return;   
                }

                ClausaCommInstallationProgress.Text = LocalizedStrings.CouldNotInstall + ' ' + LocalizedStrings.Error + ": " + error;
            });
        }

        private void InvokeOnMainThread(Action action)
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(action.Invoke));
            else
                action.Invoke();
        }

        private void ChooseInstallationDirButton_Click(object sender, EventArgs e)
        {
            InstallationDir.OpenSelectDirDialogAsync(InstallationDirChosenCallback);
        }

        public void InstallationDirChosenCallback(string path)
        {
            if (!string.IsNullOrEmpty(path) && Directory.Exists(path))
                InvokeOnMainThread(() => InstallationPathTextbox.Text = path);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            //TODO: Try switch admin on
            if (RemoveInstallerCheckbox.Checked)
                ConsoleUtils.RunProcess(ConsoleUtils.GetDelay(1) + " & del /f /q \"" + Paths.ThisProgram + '"', true, false);
            Program.Terminate();
        }

        private void PathTextbox_TextChanged(object sender, EventArgs e)
        {
            ResetPathButton.Visible = InstallationPathTextbox.Text != InstallationDir.DefaultInstallationDir;
        }

        private void ResetPathButton_Click(object sender, EventArgs e)
        {
            InstallationPathTextbox.Text = InstallationDir.DefaultInstallationDir;
        }

        private void ContentPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
