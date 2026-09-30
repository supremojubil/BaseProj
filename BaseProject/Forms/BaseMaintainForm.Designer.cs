namespace BaseProject.Forms {
    partial class BaseMaintainForm {
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
            SuspendLayout();
            // 
            // pnlBaseBottom
            // 
            pnlBaseBottom.Controls.Add(btnBaseSaveNew);
            pnlBaseBottom.Location = new Point(0, 398);
            pnlBaseBottom.Size = new Size(800, 52);
            pnlBaseBottom.Controls.SetChildIndex(pnlBottomButtonHolder, 0);
            pnlBaseBottom.Controls.SetChildIndex(btnBaseSaveNew, 0);
            // 
            // pnlBottomButtonHolder
            // 
            pnlBottomButtonHolder.Controls.Add(btnBaseSaveClose);
            pnlBottomButtonHolder.Location = new Point(589, 3);
            pnlBottomButtonHolder.Controls.SetChildIndex(btnClose, 0);
            pnlBottomButtonHolder.Controls.SetChildIndex(btnBaseSaveClose, 0);
            // 
            // btnBaseSaveClose
            // 
            btnBaseSaveClose.Location = new Point(18, 12);
            btnBaseSaveClose.Name = "btnBaseSaveClose";
            btnBaseSaveClose.Size = new Size(95, 25);
            btnBaseSaveClose.TabIndex = 1;
            btnBaseSaveClose.Text = "&Save and Close";
            btnBaseSaveClose.UseVisualStyleBackColor = true;
            btnBaseSaveClose.Click += btnBaseSaveClose_Click;
            // 
            // btnBaseSaveNew
            // 
            btnBaseSaveNew.Location = new Point(12, 15);
            btnBaseSaveNew.Name = "btnBaseSaveNew";
            btnBaseSaveNew.Size = new Size(95, 25);
            btnBaseSaveNew.TabIndex = 3;
            btnBaseSaveNew.Text = "&Save and New";
            btnBaseSaveNew.UseVisualStyleBackColor = true;
            btnBaseSaveNew.Click += btnBaseSaveNew_Click;
            // 
            // BaseMaintainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            DisplayInfoBar = true;
            Name = "BaseMaintainForm";
            Text = "BaseMaintainForm";
            pnlBaseBottom.ResumeLayout(false);
            pnlBottomButtonHolder.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnBaseSaveClose;
        private Button btnBaseSaveNew;
    }
}