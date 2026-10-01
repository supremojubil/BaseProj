namespace BaseProject.Forms {
    partial class BaseFormListAsync {
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
            pnlBaseBottom = new Panel();
            pnlBottomButtonHolder = new Panel();
            btnClose = new Button();
            lblBase = new Label();
            pnlInfo = new Panel();
            pnlInfoText = new Panel();
            lblInfoMessage = new Label();
            lblInfoTitle = new Label();
            picInfo = new PictureBox();
            pnlBaseBottom.SuspendLayout();
            pnlBottomButtonHolder.SuspendLayout();
            pnlInfo.SuspendLayout();
            pnlInfoText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picInfo).BeginInit();
            SuspendLayout();
            // 
            // pnlBaseBottom
            // 
            pnlBaseBottom.Controls.Add(pnlBottomButtonHolder);
            pnlBaseBottom.Controls.Add(lblBase);
            pnlBaseBottom.Dock = DockStyle.Bottom;
            pnlBaseBottom.Location = new Point(0, 386);
            pnlBaseBottom.Name = "pnlBaseBottom";
            pnlBaseBottom.Size = new Size(800, 64);
            pnlBaseBottom.TabIndex = 0;
            // 
            // pnlBottomButtonHolder
            // 
            pnlBottomButtonHolder.Controls.Add(btnClose);
            pnlBottomButtonHolder.Dock = DockStyle.Right;
            pnlBottomButtonHolder.Location = new Point(560, 3);
            pnlBottomButtonHolder.Name = "pnlBottomButtonHolder";
            pnlBottomButtonHolder.Size = new Size(240, 61);
            pnlBottomButtonHolder.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(138, 17);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(89, 28);
            btnClose.TabIndex = 0;
            btnClose.Text = "&Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblBase
            // 
            lblBase.BorderStyle = BorderStyle.Fixed3D;
            lblBase.Dock = DockStyle.Top;
            lblBase.Location = new Point(0, 0);
            lblBase.Name = "lblBase";
            lblBase.Size = new Size(800, 3);
            lblBase.TabIndex = 1;
            // 
            // pnlInfo
            // 
            pnlInfo.BackColor = SystemColors.GradientInactiveCaption;
            pnlInfo.BorderStyle = BorderStyle.FixedSingle;
            pnlInfo.Controls.Add(pnlInfoText);
            pnlInfo.Controls.Add(picInfo);
            pnlInfo.Dock = DockStyle.Top;
            pnlInfo.Location = new Point(0, 0);
            pnlInfo.Name = "pnlInfo";
            pnlInfo.Size = new Size(800, 77);
            pnlInfo.TabIndex = 1;
            // 
            // pnlInfoText
            // 
            pnlInfoText.Controls.Add(lblInfoMessage);
            pnlInfoText.Controls.Add(lblInfoTitle);
            pnlInfoText.Location = new Point(75, 7);
            pnlInfoText.Name = "pnlInfoText";
            pnlInfoText.Size = new Size(699, 64);
            pnlInfoText.TabIndex = 0;
            // 
            // lblInfoMessage
            // 
            lblInfoMessage.Dock = DockStyle.Fill;
            lblInfoMessage.Location = new Point(0, 15);
            lblInfoMessage.Name = "lblInfoMessage";
            lblInfoMessage.Size = new Size(699, 49);
            lblInfoMessage.TabIndex = 3;
            lblInfoMessage.Text = "Ready.";
            // 
            // lblInfoTitle
            // 
            lblInfoTitle.AutoSize = true;
            lblInfoTitle.Dock = DockStyle.Top;
            lblInfoTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblInfoTitle.Location = new Point(0, 0);
            lblInfoTitle.Name = "lblInfoTitle";
            lblInfoTitle.Size = new Size(74, 15);
            lblInfoTitle.TabIndex = 2;
            lblInfoTitle.Text = "Information";
            // 
            // picInfo
            // 
            picInfo.Image = Properties.Resources.no_pictures;
            picInfo.Location = new Point(12, 11);
            picInfo.Name = "picInfo";
            picInfo.Size = new Size(45, 45);
            picInfo.SizeMode = PictureBoxSizeMode.CenterImage;
            picInfo.TabIndex = 1;
            picInfo.TabStop = false;
            // 
            // BaseFormListAsync
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlInfo);
            Controls.Add(pnlBaseBottom);
            Name = "BaseFormListAsync";
            Text = "BaseFormListAsync";
            KeyDown += BaseFormListAsync_KeyDown;
            pnlBaseBottom.ResumeLayout(false);
            pnlBottomButtonHolder.ResumeLayout(false);
            pnlInfo.ResumeLayout(false);
            pnlInfoText.ResumeLayout(false);
            pnlInfoText.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picInfo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        protected Panel pnlBaseBottom;
        protected Panel pnlBottomButtonHolder;
        protected Panel pnlInfo;
        protected Button btnClose;
        protected Label lblBase;
        protected Panel pnlInfoText;
        protected PictureBox picInfo;
        protected Label lblInfoMessage;
        protected Label lblInfoTitle;
    }
}