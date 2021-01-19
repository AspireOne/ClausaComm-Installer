using System.ComponentModel;
using System.Windows.Forms;

namespace ClausaComm_Installer.Forms
{
    partial class NotAnAdminForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotAnAdminForm));
            this.PleaseRestartAsAdminLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PleaseRestartAsAdminLbl
            // 
            this.PleaseRestartAsAdminLbl.AutoSize = true;
            this.PleaseRestartAsAdminLbl.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PleaseRestartAsAdminLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.PleaseRestartAsAdminLbl.Location = new System.Drawing.Point(35, 28);
            this.PleaseRestartAsAdminLbl.Name = "PleaseRestartAsAdminLbl";
            this.PleaseRestartAsAdminLbl.Size = new System.Drawing.Size(378, 28);
            this.PleaseRestartAsAdminLbl.TabIndex = 0;
            this.PleaseRestartAsAdminLbl.Text = "Please restart the installer as admin.";
            // 
            // NotAnAdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 87);
            this.Controls.Add(this.PleaseRestartAsAdminLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NotAnAdminForm";
            this.Text = "Not an administrator";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label PleaseRestartAsAdminLbl;
    }
}