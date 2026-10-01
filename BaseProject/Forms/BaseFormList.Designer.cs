using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Forms {
    partial class BaseFormList {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.PictureBox picInfo;
        private System.Windows.Forms.Panel pnlInfoText;
        private System.Windows.Forms.Label lblInfoTitle;
        private System.Windows.Forms.Label lblInfoMessage;

        protected System.Windows.Forms.Panel pnlBaseBottom;
        protected System.Windows.Forms.Panel pnlBottomButtonHolder;
        protected System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblBase;

        protected override void Dispose(bool disposing) {
            if (disposing &&
                (components != null)) {
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
            pnlInfo.BackColor = Color.FromArgb(227, 239, 255);
            pnlInfo.BorderStyle = BorderStyle.FixedSingle;
            pnlInfo.Controls.Add(pnlInfoText);
            pnlInfo.Controls.Add(picInfo);
            pnlInfo.Dock = DockStyle.Top;
            pnlInfo.Location = new Point(0, 0);
            pnlInfo.Name = "pnlInfo";
            pnlInfo.Size = new Size(700, 70);
            pnlInfo.TabIndex = 0;
            // 
            // pnlInfoText
            // 
            pnlInfoText.Controls.Add(lblInfoMessage);
            pnlInfoText.Controls.Add(lblInfoTitle);
            pnlInfoText.Location = new Point(72, 8);
            pnlInfoText.Name = "pnlInfoText";
            pnlInfoText.Size = new Size(615, 52);
            pnlInfoText.TabIndex = 1;
            // 
            // lblInfoMessage
            // 
            lblInfoMessage.Dock = DockStyle.Fill;
            lblInfoMessage.Location = new Point(0, 15);
            lblInfoMessage.Name = "lblInfoMessage";
            lblInfoMessage.Size = new Size(615, 37);
            lblInfoMessage.TabIndex = 1;
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
            lblInfoTitle.TabIndex = 0;
            lblInfoTitle.Text = "Information";
            // 
            // picInfo
            // 
            picInfo.Image = Properties.Resources.no_pictures;
            picInfo.Location = new Point(12, 10);
            picInfo.Name = "picInfo";
            picInfo.Size = new Size(48, 48);
            picInfo.SizeMode = PictureBoxSizeMode.CenterImage;
            picInfo.TabIndex = 0;
            picInfo.TabStop = false;
            // 
            // pnlBaseBottom
            // 
            pnlBaseBottom.Controls.Add(pnlBottomButtonHolder);
            pnlBaseBottom.Controls.Add(lblBase);
            pnlBaseBottom.Dock = DockStyle.Bottom;
            pnlBaseBottom.Location = new Point(0, 363);
            pnlBaseBottom.Name = "pnlBaseBottom";
            pnlBaseBottom.Size = new Size(700, 52);
            pnlBaseBottom.TabIndex = 1;
            // 
            // pnlBottomButtonHolder
            // 
            pnlBottomButtonHolder.Controls.Add(btnClose);
            pnlBottomButtonHolder.Dock = DockStyle.Right;
            pnlBottomButtonHolder.Location = new Point(489, 3);
            pnlBottomButtonHolder.Name = "pnlBottomButtonHolder";
            pnlBottomButtonHolder.Size = new Size(211, 49);
            pnlBottomButtonHolder.TabIndex = 2;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(129, 12);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 25);
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
            lblBase.Size = new Size(700, 3);
            lblBase.TabIndex = 0;
            // 
            // BaseFormList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 415);
            Controls.Add(pnlInfo);
            Controls.Add(pnlBaseBottom);
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
