
namespace ClausaComm_Installer.Forms
{
    partial class AlreadyInstalledForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlreadyInstalledForm));
            this.AlreadyInstalledLbl = new System.Windows.Forms.Label();
            this.InstallationPathLbl = new System.Windows.Forms.Label();
            this.InstallationPath = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AlreadyInstalledLbl
            // 
            this.AlreadyInstalledLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.AlreadyInstalledLbl.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AlreadyInstalledLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.AlreadyInstalledLbl.Location = new System.Drawing.Point(0, 0);
            this.AlreadyInstalledLbl.Name = "AlreadyInstalledLbl";
            this.AlreadyInstalledLbl.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.AlreadyInstalledLbl.Size = new System.Drawing.Size(546, 92);
            this.AlreadyInstalledLbl.TabIndex = 0;
            this.AlreadyInstalledLbl.Text = "ClausaComm is already installed.";
            this.AlreadyInstalledLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // InstallationPathLbl
            // 
            this.InstallationPathLbl.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.InstallationPathLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.InstallationPathLbl.Location = new System.Drawing.Point(2, 157);
            this.InstallationPathLbl.Name = "InstallationPathLbl";
            this.InstallationPathLbl.Size = new System.Drawing.Size(213, 23);
            this.InstallationPathLbl.TabIndex = 1;
            this.InstallationPathLbl.Text = "Installation folder:";
            this.InstallationPathLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InstallationPath
            // 
            this.InstallationPath.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.InstallationPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.InstallationPath.Location = new System.Drawing.Point(221, 148);
            this.InstallationPath.Name = "InstallationPath";
            this.InstallationPath.Size = new System.Drawing.Size(325, 43);
            this.InstallationPath.TabIndex = 2;
            this.InstallationPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AlreadyInstalledForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 200);
            this.Controls.Add(this.InstallationPath);
            this.Controls.Add(this.InstallationPathLbl);
            this.Controls.Add(this.AlreadyInstalledLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AlreadyInstalledForm";
            this.Text = "ClausaComm is already installed";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label AlreadyInstalledLbl;
        private System.Windows.Forms.Label InstallationPathLbl;
        private System.Windows.Forms.Label InstallationPath;
    }
}