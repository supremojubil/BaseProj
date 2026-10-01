namespace BaseProject.SplashScreen {
    partial class BaseSplashScreen {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlProgress = new System.Windows.Forms.Panel();
            this.pnlProgressValue = new System.Windows.Forms.Panel();
            this.lblApplicationName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblBuild = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.lblAccent = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // BaseSplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(18, 22, 28);
            this.ClientSize = new System.Drawing.Size(600, 330);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BaseSplashScreen";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(24, 29, 37);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(600, 330);
            this.pnlMain.TabIndex = 0;
            // 
            // lblAccent
            // 
            this.lblAccent.BackColor = System.Drawing.Color.FromArgb(0, 174, 239);
            this.lblAccent.Location = new System.Drawing.Point(40, 42);
            this.lblAccent.Name = "lblAccent";
            this.lblAccent.Size = new System.Drawing.Size(5, 58);
            this.lblAccent.TabIndex = 0;
            // 
            // lblApplicationName
            // 
            this.lblApplicationName.AutoSize = true;
            this.lblApplicationName.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblApplicationName.ForeColor = System.Drawing.Color.White;
            this.lblApplicationName.Location = new System.Drawing.Point(60, 38);
            this.lblApplicationName.Name = "lblApplicationName";
            this.lblApplicationName.Size = new System.Drawing.Size(220, 45);
            this.lblApplicationName.TabIndex = 1;
            this.lblApplicationName.Text = "BASE PROJECT";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(170, 180, 190);
            this.lblDescription.Location = new System.Drawing.Point(63, 87);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(250, 19);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Business Application Framework";
            // 
            // pnlProgress
            // 
            this.pnlProgress.BackColor = System.Drawing.Color.FromArgb(48, 55, 66);
            this.pnlProgress.Controls.Add(this.pnlProgressValue);
            this.pnlProgress.Location = new System.Drawing.Point(60, 164);
            this.pnlProgress.Name = "pnlProgress";
            this.pnlProgress.Size = new System.Drawing.Size(480, 5);
            this.pnlProgress.TabIndex = 3;
            // 
            // pnlProgressValue
            // 
            this.pnlProgressValue.BackColor = System.Drawing.Color.FromArgb(0, 174, 239);
            this.pnlProgressValue.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlProgressValue.Location = new System.Drawing.Point(0, 0);
            this.pnlProgressValue.Name = "pnlProgressValue";
            this.pnlProgressValue.Size = new System.Drawing.Size(120, 5);
            this.pnlProgressValue.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoEllipsis = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(210, 215, 220);
            this.lblStatus.Location = new System.Drawing.Point(60, 185);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(480, 24);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Loading application...";
            // 
            // lblBuild
            // 
            this.lblBuild.AutoSize = true;
            this.lblBuild.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBuild.ForeColor = System.Drawing.Color.FromArgb(130, 140, 150);
            this.lblBuild.Location = new System.Drawing.Point(60, 260);
            this.lblBuild.Name = "lblBuild";
            this.lblBuild.Size = new System.Drawing.Size(70, 15);
            this.lblBuild.TabIndex = 5;
            this.lblBuild.Text = "Build 1.0.0.0";
            // 
            // lblCopyright
            // 
            this.lblCopyright.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCopyright.ForeColor = System.Drawing.Color.FromArgb(100, 110, 120);
            this.lblCopyright.Location = new System.Drawing.Point(383, 260);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(157, 15);
            this.lblCopyright.TabIndex = 6;
            this.lblCopyright.Text = "© BaseProject";
            // 
            // pnlMain Controls
            // 
            this.pnlMain.Controls.Add(this.lblAccent);
            this.pnlMain.Controls.Add(this.lblApplicationName);
            this.pnlMain.Controls.Add(this.lblDescription);
            this.pnlMain.Controls.Add(this.pnlProgress);
            this.pnlMain.Controls.Add(this.lblStatus);
            this.pnlMain.Controls.Add(this.lblBuild);
            this.pnlMain.Controls.Add(this.lblCopyright);
            // 
            // Form Controls
            // 
            this.Controls.Add(this.pnlMain);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlProgress.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlProgress;
        private System.Windows.Forms.Panel pnlProgressValue;

        private System.Windows.Forms.Label lblApplicationName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblBuild;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Label lblAccent;
    }
}