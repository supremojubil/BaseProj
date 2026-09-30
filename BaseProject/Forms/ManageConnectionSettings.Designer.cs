namespace BaseProject.Forms {
    partial class ManageConnectionSettings {
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
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            txtHost = new TextBox();
            txtDatabase = new TextBox();
            txtPort = new TextBox();
            lblUsername = new Label();
            lblPassword = new Label();
            lblHost = new Label();
            lblDatabase = new Label();
            lblPort = new Label();
            pnlBaseBottom.SuspendLayout();
            pnlBottomButtonHolder.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBaseBottom
            // 
            pnlBaseBottom.Location = new Point(0, 241);
            pnlBaseBottom.Size = new Size(397, 52);
            // 
            // pnlBottomButtonHolder
            // 
            pnlBottomButtonHolder.Location = new Point(186, 3);
            pnlBottomButtonHolder.TabIndex = 0;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(120, 86);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(239, 23);
            txtUsername.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(120, 115);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(239, 23);
            txtPassword.TabIndex = 1;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtHost
            // 
            txtHost.Location = new Point(120, 144);
            txtHost.Name = "txtHost";
            txtHost.Size = new Size(239, 23);
            txtHost.TabIndex = 2;
            // 
            // txtDatabase
            // 
            txtDatabase.Location = new Point(120, 173);
            txtDatabase.Name = "txtDatabase";
            txtDatabase.Size = new Size(239, 23);
            txtDatabase.TabIndex = 3;
            // 
            // txtPort
            // 
            txtPort.Location = new Point(120, 202);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(239, 23);
            txtPort.TabIndex = 4;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(27, 90);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(63, 15);
            lblUsername.TabIndex = 7;
            lblUsername.Text = "Username:";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(27, 120);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(60, 15);
            lblPassword.TabIndex = 8;
            lblPassword.Text = "Password:";
            // 
            // lblHost
            // 
            lblHost.AutoSize = true;
            lblHost.Location = new Point(27, 148);
            lblHost.Name = "lblHost";
            lblHost.Size = new Size(35, 15);
            lblHost.TabIndex = 9;
            lblHost.Text = "Host:";
            // 
            // lblDatabase
            // 
            lblDatabase.AutoSize = true;
            lblDatabase.Location = new Point(27, 178);
            lblDatabase.Name = "lblDatabase";
            lblDatabase.Size = new Size(58, 15);
            lblDatabase.TabIndex = 10;
            lblDatabase.Text = "Database:";
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.Location = new Point(27, 205);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(32, 15);
            lblPort.TabIndex = 11;
            lblPort.Text = "Port:";
            // 
            // ManageConnectionSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(397, 293);
            Controls.Add(lblPort);
            Controls.Add(lblDatabase);
            Controls.Add(lblHost);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Controls.Add(txtPort);
            Controls.Add(txtDatabase);
            Controls.Add(txtHost);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            DisplayInfoBar = true;
            InfoImage = Properties.Resources.settings;
            InfoText1 = "Connection Settings";
            InfoText2 = "This is where you can configure connection.";
            Name = "ManageConnectionSettings";
            Text = "ManageConnectionSettings";
            TextSaveClose = "&Save";
            UseTwoSaveButtons = false;
            Load += ManageConnectionSettings_Load;
            Controls.SetChildIndex(pnlBaseBottom, 0);
            Controls.SetChildIndex(txtUsername, 0);
            Controls.SetChildIndex(txtPassword, 0);
            Controls.SetChildIndex(txtHost, 0);
            Controls.SetChildIndex(txtDatabase, 0);
            Controls.SetChildIndex(txtPort, 0);
            Controls.SetChildIndex(lblUsername, 0);
            Controls.SetChildIndex(lblPassword, 0);
            Controls.SetChildIndex(lblHost, 0);
            Controls.SetChildIndex(lblDatabase, 0);
            Controls.SetChildIndex(lblPort, 0);
            pnlBaseBottom.ResumeLayout(false);
            pnlBottomButtonHolder.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtHost;
        private TextBox txtDatabase;
        private TextBox txtPort;
        private Label lblUsername;
        private Label lblPassword;
        private Label lblHost;
        private Label lblDatabase;
        private Label lblPort;
    }
}