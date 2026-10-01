namespace BaseProject.Forms {
    partial class BaseMaintainFormAsync {
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
            btnBaseSaveClose = new Button();
            btnBaseSaveNew = new Button();
            pnlBaseBottom.SuspendLayout();
            pnlBottomButtonHolder.SuspendLayout();
            pnlInfo.SuspendLayout();
            pnlInfoText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picInfo).BeginInit();
            SuspendLayout();
            // 
            // pnlBaseBottom
            // 
            pnlBaseBottom.Controls.Add(btnBaseSaveNew);
            pnlBaseBottom.Controls.SetChildIndex(btnBaseSaveNew, 0);
            pnlBaseBottom.Controls.SetChildIndex(lblBase, 0);
            pnlBaseBottom.Controls.SetChildIndex(pnlBottomButtonHolder, 0);
            // 
            // pnlBottomButtonHolder
            // 
            pnlBottomButtonHolder.Controls.Add(btnBaseSaveClose);
            pnlBottomButtonHolder.Controls.SetChildIndex(btnClose, 0);
            pnlBottomButtonHolder.Controls.SetChildIndex(btnBaseSaveClose, 0);
            // 
            // btnBaseSaveClose
            // 
            btnBaseSaveClose.Location = new Point(26, 17);
            btnBaseSaveClose.Name = "btnBaseSaveClose";
            btnBaseSaveClose.Size = new Size(98, 28);
            btnBaseSaveClose.TabIndex = 1;
            btnBaseSaveClose.Text = "&Save and Close";
            btnBaseSaveClose.UseVisualStyleBackColor = true;
            btnBaseSaveClose.Click += btnBaseSaveClose_Click;
            // 
            // btnBaseSaveNew
            // 
            btnBaseSaveNew.Location = new Point(25, 21);
            btnBaseSaveNew.Name = "btnBaseSaveNew";
            btnBaseSaveNew.Size = new Size(100, 28);
            btnBaseSaveNew.TabIndex = 2;
            btnBaseSaveNew.Text = "Save and &New";
            btnBaseSaveNew.UseVisualStyleBackColor = true;
            btnBaseSaveNew.Click += btnBaseSaveNew_Click;
            // 
            // BaseMaintainFormAsync
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Name = "BaseMaintainFormAsync";
            Text = "BaseMaintainFormAsync";
            pnlBaseBottom.ResumeLayout(false);
            pnlBottomButtonHolder.ResumeLayout(false);
            pnlInfo.ResumeLayout(false);
            pnlInfoText.ResumeLayout(false);
            pnlInfoText.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picInfo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnBaseSaveNew;
        private Button btnBaseSaveClose;
    }
}