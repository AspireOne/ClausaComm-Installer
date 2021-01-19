using System.ComponentModel;
using System.Windows.Forms;

namespace ClausaComm_Installer.Forms
{
    partial class InstallForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstallForm));
            this.Title = new System.Windows.Forms.Label();
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.RemoveInstallerCheckbox = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.VerticalLine1 = new System.Windows.Forms.Panel();
            this.InstallButton = new System.Windows.Forms.Button();
            this.InstallationPathSelectionPanel = new System.Windows.Forms.Panel();
            this.ResetPathButton = new System.Windows.Forms.Button();
            this.InstallationLocationQuestion = new System.Windows.Forms.Label();
            this.ChooseInstallationDirButton = new System.Windows.Forms.Button();
            this.InstallationPathTextbox = new System.Windows.Forms.TextBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.ClausaCommInstallationProgress = new System.Windows.Forms.Label();
            this.DotnetNotInstalledPanel = new System.Windows.Forms.Panel();
            this.ManualDownloadLink = new System.Windows.Forms.LinkLabel();
            this.DotnetInstallProgress = new System.Windows.Forms.Label();
            this.DotnetInstallationProgressBar = new System.Windows.Forms.ProgressBar();
            this.DotnetInstallButton = new System.Windows.Forms.Button();
            this.DotnetInstalledLabel = new System.Windows.Forms.Label();
            this.ClosePanel = new System.Windows.Forms.Panel();
            this.ContentPanel.SuspendLayout();
            this.InstallationPathSelectionPanel.SuspendLayout();
            this.DotnetNotInstalledPanel.SuspendLayout();
            this.ClosePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title.Font = new System.Drawing.Font("Microsoft YaHei", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.Title.Location = new System.Drawing.Point(0, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(786, 83);
            this.Title.TabIndex = 0;
            this.Title.Text = "{ClausaComm Installation}";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ContentPanel
            // 
            this.ContentPanel.Controls.Add(this.ClosePanel);
            this.ContentPanel.Controls.Add(this.InstallButton);
            this.ContentPanel.Controls.Add(this.InstallationPathSelectionPanel);
            this.ContentPanel.Controls.Add(this.ClausaCommInstallationProgress);
            this.ContentPanel.Controls.Add(this.DotnetNotInstalledPanel);
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ContentPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.ContentPanel.Location = new System.Drawing.Point(0, 83);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(786, 331);
            this.ContentPanel.TabIndex = 1;
            this.ContentPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ContentPanel_Paint);
            // 
            // RemoveInstallerCheckbox
            // 
            this.RemoveInstallerCheckbox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.RemoveInstallerCheckbox.Checked = true;
            this.RemoveInstallerCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RemoveInstallerCheckbox.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RemoveInstallerCheckbox.Location = new System.Drawing.Point(33, 6);
            this.RemoveInstallerCheckbox.Name = "RemoveInstallerCheckbox";
            this.RemoveInstallerCheckbox.Size = new System.Drawing.Size(211, 21);
            this.RemoveInstallerCheckbox.TabIndex = 14;
            this.RemoveInstallerCheckbox.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(26, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(216, 1);
            this.panel1.TabIndex = 13;
            // 
            // VerticalLine1
            // 
            this.VerticalLine1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.VerticalLine1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VerticalLine1.Location = new System.Drawing.Point(26, 3);
            this.VerticalLine1.Name = "VerticalLine1";
            this.VerticalLine1.Size = new System.Drawing.Size(1, 72);
            this.VerticalLine1.TabIndex = 12;
            // 
            // InstallButton
            // 
            this.InstallButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InstallButton.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.InstallButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.InstallButton.Location = new System.Drawing.Point(293, 261);
            this.InstallButton.Name = "InstallButton";
            this.InstallButton.Size = new System.Drawing.Size(184, 64);
            this.InstallButton.TabIndex = 2;
            this.InstallButton.Text = "{Install}";
            this.InstallButton.UseVisualStyleBackColor = true;
            this.InstallButton.Click += new System.EventHandler(this.InstallButton_Click);
            // 
            // InstallationPathSelectionPanel
            // 
            this.InstallationPathSelectionPanel.Controls.Add(this.ResetPathButton);
            this.InstallationPathSelectionPanel.Controls.Add(this.InstallationLocationQuestion);
            this.InstallationPathSelectionPanel.Controls.Add(this.ChooseInstallationDirButton);
            this.InstallationPathSelectionPanel.Controls.Add(this.InstallationPathTextbox);
            this.InstallationPathSelectionPanel.Location = new System.Drawing.Point(46, 13);
            this.InstallationPathSelectionPanel.Name = "InstallationPathSelectionPanel";
            this.InstallationPathSelectionPanel.Size = new System.Drawing.Size(701, 57);
            this.InstallationPathSelectionPanel.TabIndex = 11;
            // 
            // ResetPathButton
            // 
            this.ResetPathButton.Location = new System.Drawing.Point(633, 30);
            this.ResetPathButton.Name = "ResetPathButton";
            this.ResetPathButton.Size = new System.Drawing.Size(61, 24);
            this.ResetPathButton.TabIndex = 10;
            this.ResetPathButton.Text = "{reset}";
            this.ResetPathButton.UseVisualStyleBackColor = true;
            this.ResetPathButton.Visible = false;
            this.ResetPathButton.Click += new System.EventHandler(this.ResetPathButton_Click);
            // 
            // InstallationLocationQuestion
            // 
            this.InstallationLocationQuestion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.InstallationLocationQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.InstallationLocationQuestion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.InstallationLocationQuestion.Location = new System.Drawing.Point(0, 2);
            this.InstallationLocationQuestion.Name = "InstallationLocationQuestion";
            this.InstallationLocationQuestion.Size = new System.Drawing.Size(327, 25);
            this.InstallationLocationQuestion.TabIndex = 1;
            this.InstallationLocationQuestion.Text = "{Where do you want to install ClausaComm to?}";
            // 
            // ChooseInstallationDirButton
            // 
            this.ChooseInstallationDirButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ChooseInstallationDirButton.Location = new System.Drawing.Point(667, 2);
            this.ChooseInstallationDirButton.Margin = new System.Windows.Forms.Padding(0);
            this.ChooseInstallationDirButton.Name = "ChooseInstallationDirButton";
            this.ChooseInstallationDirButton.Size = new System.Drawing.Size(27, 25);
            this.ChooseInstallationDirButton.TabIndex = 9;
            this.ChooseInstallationDirButton.Text = "...";
            this.ChooseInstallationDirButton.UseVisualStyleBackColor = true;
            this.ChooseInstallationDirButton.Click += new System.EventHandler(this.ChooseInstallationDirButton_Click);
            // 
            // InstallationPathTextbox
            // 
            this.InstallationPathTextbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.InstallationPathTextbox.Location = new System.Drawing.Point(333, 3);
            this.InstallationPathTextbox.Name = "InstallationPathTextbox";
            this.InstallationPathTextbox.Size = new System.Drawing.Size(331, 23);
            this.InstallationPathTextbox.TabIndex = 0;
            this.InstallationPathTextbox.TextChanged += new System.EventHandler(this.PathTextbox_TextChanged);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.CloseButton.AutoSize = true;
            this.CloseButton.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CloseButton.Location = new System.Drawing.Point(70, 33);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(130, 43);
            this.CloseButton.TabIndex = 10;
            this.CloseButton.Text = "{Close}";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // ClausaCommInstallationProgress
            // 
            this.ClausaCommInstallationProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ClausaCommInstallationProgress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ClausaCommInstallationProgress.Location = new System.Drawing.Point(12, 225);
            this.ClausaCommInstallationProgress.Name = "ClausaCommInstallationProgress";
            this.ClausaCommInstallationProgress.Size = new System.Drawing.Size(762, 27);
            this.ClausaCommInstallationProgress.TabIndex = 8;
            this.ClausaCommInstallationProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DotnetNotInstalledPanel
            // 
            this.DotnetNotInstalledPanel.Controls.Add(this.ManualDownloadLink);
            this.DotnetNotInstalledPanel.Controls.Add(this.DotnetInstallProgress);
            this.DotnetNotInstalledPanel.Controls.Add(this.DotnetInstallationProgressBar);
            this.DotnetNotInstalledPanel.Controls.Add(this.DotnetInstallButton);
            this.DotnetNotInstalledPanel.Controls.Add(this.DotnetInstalledLabel);
            this.DotnetNotInstalledPanel.Location = new System.Drawing.Point(46, 84);
            this.DotnetNotInstalledPanel.Name = "DotnetNotInstalledPanel";
            this.DotnetNotInstalledPanel.Size = new System.Drawing.Size(467, 140);
            this.DotnetNotInstalledPanel.TabIndex = 7;
            // 
            // ManualDownloadLink
            // 
            this.ManualDownloadLink.AutoSize = true;
            this.ManualDownloadLink.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(255)))));
            this.ManualDownloadLink.Location = new System.Drawing.Point(3, 124);
            this.ManualDownloadLink.Name = "ManualDownloadLink";
            this.ManualDownloadLink.Size = new System.Drawing.Size(218, 17);
            this.ManualDownloadLink.TabIndex = 8;
            this.ManualDownloadLink.TabStop = true;
            this.ManualDownloadLink.Text = "{You can also download it manually}";
            this.ManualDownloadLink.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(255)))));
            this.ManualDownloadLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ManualDotnetInstallLink_Clicked);
            // 
            // DotnetInstallProgress
            // 
            this.DotnetInstallProgress.Location = new System.Drawing.Point(130, 90);
            this.DotnetInstallProgress.Name = "DotnetInstallProgress";
            this.DotnetInstallProgress.Size = new System.Drawing.Size(310, 34);
            this.DotnetInstallProgress.TabIndex = 10;
            // 
            // DotnetInstallationProgressBar
            // 
            this.DotnetInstallationProgressBar.Location = new System.Drawing.Point(130, 49);
            this.DotnetInstallationProgressBar.Name = "DotnetInstallationProgressBar";
            this.DotnetInstallationProgressBar.Size = new System.Drawing.Size(310, 38);
            this.DotnetInstallationProgressBar.TabIndex = 9;
            // 
            // DotnetInstallButton
            // 
            this.DotnetInstallButton.Font = new System.Drawing.Font("Microsoft YaHei", 10F);
            this.DotnetInstallButton.Location = new System.Drawing.Point(6, 49);
            this.DotnetInstallButton.Name = "DotnetInstallButton";
            this.DotnetInstallButton.Size = new System.Drawing.Size(105, 38);
            this.DotnetInstallButton.TabIndex = 8;
            this.DotnetInstallButton.Text = "{Install}";
            this.DotnetInstallButton.UseVisualStyleBackColor = true;
            this.DotnetInstallButton.Click += new System.EventHandler(this.DotnetInstallButton_Click);
            // 
            // DotnetInstalledLabel
            // 
            this.DotnetInstalledLabel.AutoSize = true;
            this.DotnetInstalledLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DotnetInstalledLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.DotnetInstalledLabel.Location = new System.Drawing.Point(3, 9);
            this.DotnetInstalledLabel.Name = "DotnetInstalledLabel";
            this.DotnetInstalledLabel.Size = new System.Drawing.Size(457, 18);
            this.DotnetInstalledLabel.TabIndex = 7;
            this.DotnetInstalledLabel.Text = "{.NET 5 is not installed. Do you want to download and install it now?}";
            // 
            // ClosePanel
            // 
            this.ClosePanel.Controls.Add(this.panel1);
            this.ClosePanel.Controls.Add(this.RemoveInstallerCheckbox);
            this.ClosePanel.Controls.Add(this.CloseButton);
            this.ClosePanel.Controls.Add(this.VerticalLine1);
            this.ClosePanel.Location = new System.Drawing.Point(536, 249);
            this.ClosePanel.Name = "ClosePanel";
            this.ClosePanel.Size = new System.Drawing.Size(250, 82);
            this.ClosePanel.TabIndex = 15;
            this.ClosePanel.Visible = false;
            // 
            // InstallForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 414);
            this.Controls.Add(this.ContentPanel);
            this.Controls.Add(this.Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "InstallForm";
            this.Text = "ClausaComm Installer";
            this.ContentPanel.ResumeLayout(false);
            this.InstallationPathSelectionPanel.ResumeLayout(false);
            this.InstallationPathSelectionPanel.PerformLayout();
            this.DotnetNotInstalledPanel.ResumeLayout(false);
            this.DotnetNotInstalledPanel.PerformLayout();
            this.ClosePanel.ResumeLayout(false);
            this.ClosePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label Title;
        private Panel ContentPanel;
        private Panel DotnetNotInstalledPanel;
        private Label DotnetInstallProgress;
        private ProgressBar DotnetInstallationProgressBar;
        private Button DotnetInstallButton;
        private Label DotnetInstalledLabel;
        private Button InstallButton;
        private Label InstallationLocationQuestion;
        private TextBox InstallationPathTextbox;
        private LinkLabel ManualDownloadLink;
        private Label ClausaCommInstallationProgress;
        private Button ChooseInstallationDirButton;
        private Button CloseButton;
        private Panel InstallationPathSelectionPanel;
        private Button ResetPathButton;
        private Panel VerticalLine1;
        private Panel panel1;
        private CheckBox RemoveInstallerCheckbox;
        private Panel ClosePanel;
    }
}

