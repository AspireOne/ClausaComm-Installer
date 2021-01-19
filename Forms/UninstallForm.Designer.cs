
namespace ClausaComm_Installer.Forms
{
    partial class UninstallForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UninstallForm));
            this.DoYouWishToUninstallLbl = new System.Windows.Forms.Label();
            this.UninstallButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.UninstallationProgress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DoYouWishToUninstallLbl
            // 
            this.DoYouWishToUninstallLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.DoYouWishToUninstallLbl.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DoYouWishToUninstallLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.DoYouWishToUninstallLbl.Location = new System.Drawing.Point(0, 0);
            this.DoYouWishToUninstallLbl.Name = "DoYouWishToUninstallLbl";
            this.DoYouWishToUninstallLbl.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.DoYouWishToUninstallLbl.Size = new System.Drawing.Size(519, 69);
            this.DoYouWishToUninstallLbl.TabIndex = 0;
            this.DoYouWishToUninstallLbl.Text = "Do you really wish to uninstall ClausaComm?";
            this.DoYouWishToUninstallLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // UninstallButton
            // 
            this.UninstallButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UninstallButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.UninstallButton.Location = new System.Drawing.Point(116, 150);
            this.UninstallButton.Name = "UninstallButton";
            this.UninstallButton.Size = new System.Drawing.Size(112, 50);
            this.UninstallButton.TabIndex = 1;
            this.UninstallButton.Text = "Uninstall";
            this.UninstallButton.UseVisualStyleBackColor = true;
            this.UninstallButton.Click += new System.EventHandler(this.UninstallButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CancelButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.CancelButton.Location = new System.Drawing.Point(281, 150);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(112, 50);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // UninstallationProgress
            // 
            this.UninstallationProgress.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UninstallationProgress.Location = new System.Drawing.Point(12, 103);
            this.UninstallationProgress.Name = "UninstallationProgress";
            this.UninstallationProgress.Size = new System.Drawing.Size(495, 44);
            this.UninstallationProgress.TabIndex = 3;
            this.UninstallationProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UninstallForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 212);
            this.Controls.Add(this.UninstallationProgress);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.UninstallButton);
            this.Controls.Add(this.DoYouWishToUninstallLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UninstallForm";
            this.Text = "Uninstall ClausaComm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label DoYouWishToUninstallLbl;
        private System.Windows.Forms.Button UninstallButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label UninstallationProgress;
    }
}