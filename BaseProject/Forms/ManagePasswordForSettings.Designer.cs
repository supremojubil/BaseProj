namespace BaseProject.Forms {
    partial class ManagePasswordForSettings {
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
            passwordSTextBox = new BaseProject.Controls.BaseSTextBox();
            lblPassword = new Label();
            pnlBaseBottom.SuspendLayout();
            pnlBottomButtonHolder.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBaseBottom
            // 
            pnlBaseBottom.Location = new Point(0, 82);
            pnlBaseBottom.Size = new Size(367, 52);
            // 
            // pnlBottomButtonHolder
            // 
            pnlBottomButtonHolder.Location = new Point(156, 3);
            pnlBottomButtonHolder.TabIndex = 0;
            // 
            // passwordSTextBox
            // 
            passwordSTextBox.BackColor = SystemColors.Window;
            passwordSTextBox.Location = new Point(108, 24);
            passwordSTextBox.MaxLength = 255;
            passwordSTextBox.Name = "passwordSTextBox";
            passwordSTextBox.OnTxtEnter = Color.LightSteelBlue;
            passwordSTextBox.OnTxtLeave = SystemColors.Window;
            passwordSTextBox.Size = new Size(231, 23);
            passwordSTextBox.TabIndex = 0;
            passwordSTextBox.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(35, 27);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(60, 15);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Password:";
            // 
            // ManagePasswordForSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(367, 134);
            Controls.Add(lblPassword);
            Controls.Add(passwordSTextBox);
            InfoText1 = "Information.";
            Name = "ManagePasswordForSettings";
            Text = "Enter Password for Settings";
            TextSaveClose = "&OK";
            UseTwoSaveButtons = false;
            DisplayInfoBar = false;
            Controls.SetChildIndex(pnlBaseBottom, 0);
            Controls.SetChildIndex(passwordSTextBox, 0);
            Controls.SetChildIndex(lblPassword, 0);
            pnlBaseBottom.ResumeLayout(false);
            pnlBottomButtonHolder.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Controls.BaseSTextBox passwordSTextBox;
        private Label lblPassword;
    }
}