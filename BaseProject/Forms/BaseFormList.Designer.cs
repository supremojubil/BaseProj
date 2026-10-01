using System;
using System.Drawing;
using System.Windows.Forms;

namespace BaseProject.Forms {
    partial class BaseFormList {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlInfo;
        private PictureBox picInfo;
        private Panel pnlInfoText;
        private Label lblInfoTitle;
        private Label lblInfoMessage;

        protected Panel pnlBaseBottom;
        protected Panel pnlBottomButtonHolder;
        protected Button btnClose;
        private Label lblBase;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent() {
            pnlInfo = new Panel();
            pnlInfoText = new Panel();
            lblInfoMessage = new Label();
            lblInfoTitle = new Label();
            picInfo = new PictureBox();
            pnlBaseBottom = new Panel();
            pnlBottomButtonHolder = new Panel();
            btnClose = new Button();
            lblBase = new Label();
            pnlInfo.SuspendLayout();
            pnlInfoText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picInfo).BeginInit();
            pnlBaseBottom.SuspendLayout();
            pnlBottomButtonHolder.SuspendLayout();
            SuspendLayout();
            // 
            // pnlInfo
            // 
            pnlInfo.BackColor = Color.FromArgb(239, 246, 255);
            pnlInfo.BorderStyle = BorderStyle.FixedSingle;
            pnlInfo.Controls.Add(pnlInfoText);
            pnlInfo.Controls.Add(picInfo);
            pnlInfo.Dock = DockStyle.Top;
            pnlInfo.Location = new Point(0, 0);
            pnlInfo.Name = "pnlInfo";
            pnlInfo.Size = new Size(820, 82);
            pnlInfo.TabIndex = 0;
            // 
            // pnlInfoText
            // 
            pnlInfoText.BackColor = Color.Transparent;
            pnlInfoText.Controls.Add(lblInfoMessage);
            pnlInfoText.Controls.Add(lblInfoTitle);
            pnlInfoText.Location = new Point(82, 14);
            pnlInfoText.Name = "pnlInfoText";
            pnlInfoText.Size = new Size(715, 54);
            pnlInfoText.TabIndex = 1;
            // 
            // lblInfoMessage
            // 
            lblInfoMessage.Dock = DockStyle.Fill;
            lblInfoMessage.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInfoMessage.ForeColor = Color.FromArgb(71, 85, 105);
            lblInfoMessage.Location = new Point(0, 19);
            lblInfoMessage.Margin = new Padding(0);
            lblInfoMessage.Name = "lblInfoMessage";
            lblInfoMessage.Padding = new Padding(0, 4, 0, 0);
            lblInfoMessage.Size = new Size(715, 35);
            lblInfoMessage.TabIndex = 1;
            lblInfoMessage.Text = "Ready.";
            // 
            // lblInfoTitle
            // 
            lblInfoTitle.AutoSize = true;
            lblInfoTitle.Dock = DockStyle.Top;
            lblInfoTitle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInfoTitle.ForeColor = Color.FromArgb(30, 64, 175);
            lblInfoTitle.Location = new Point(0, 0);
            lblInfoTitle.Margin = new Padding(0);
            lblInfoTitle.Name = "lblInfoTitle";
            lblInfoTitle.Size = new Size(83, 19);
            lblInfoTitle.TabIndex = 0;
            lblInfoTitle.Text = "Information";
            // 
            // picInfo
            // 
            picInfo.BackColor = Color.Transparent;
            picInfo.Image = Properties.Resources.no_pictures;
            picInfo.Location = new Point(18, 17);
            picInfo.Name = "picInfo";
            picInfo.Size = new Size(48, 48);
            picInfo.SizeMode = PictureBoxSizeMode.CenterImage;
            picInfo.TabIndex = 0;
            picInfo.TabStop = false;
            // 
            // pnlBaseBottom
            // 
            pnlBaseBottom.BackColor = Color.FromArgb(248, 250, 252);
            pnlBaseBottom.Controls.Add(pnlBottomButtonHolder);
            pnlBaseBottom.Controls.Add(lblBase);
            pnlBaseBottom.Dock = DockStyle.Bottom;
            pnlBaseBottom.Location = new Point(0, 448);
            pnlBaseBottom.Name = "pnlBaseBottom";
            pnlBaseBottom.Size = new Size(820, 62);
            pnlBaseBottom.TabIndex = 1;
            // 
            // pnlBottomButtonHolder
            // 
            pnlBottomButtonHolder.BackColor = Color.Transparent;
            pnlBottomButtonHolder.Controls.Add(btnClose);
            pnlBottomButtonHolder.Dock = DockStyle.Right;
            pnlBottomButtonHolder.Location = new Point(590, 1);
            pnlBottomButtonHolder.Name = "pnlBottomButtonHolder";
            pnlBottomButtonHolder.Size = new Size(230, 61);
            pnlBottomButtonHolder.TabIndex = 2;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.White;
            btnClose.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(226, 232, 240);
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(241, 245, 249);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.FromArgb(51, 65, 85);
            btnClose.Location = new Point(137, 17);
            btnClose.Margin = new Padding(0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 29);
            btnClose.TabIndex = 0;
            btnClose.Text = "&Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // lblBase
            // 
            lblBase.BackColor = Color.FromArgb(226, 232, 240);
            lblBase.Dock = DockStyle.Top;
            lblBase.Location = new Point(0, 0);
            lblBase.Name = "lblBase";
            lblBase.Size = new Size(820, 1);
            lblBase.TabIndex = 0;
            // 
            // BaseFormList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(820, 510);
            Controls.Add(pnlInfo);
            Controls.Add(pnlBaseBottom);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BaseFormList";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BaseFormList";
            KeyDown += BaseFormList_KeyDown;
            pnlInfo.ResumeLayout(false);
            pnlInfoText.ResumeLayout(false);
            pnlInfoText.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picInfo).EndInit();
            pnlBaseBottom.ResumeLayout(false);
            pnlBottomButtonHolder.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}