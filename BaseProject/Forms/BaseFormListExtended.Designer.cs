namespace BaseProject.Forms {
    partial class BaseFormListExtended {
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
            tsBase = new BaseProject.Controls.BaseToolStripMenuItemEx();
            btnAdd = new ToolStripButton();
            separator1 = new ToolStripSeparator();
            btnEdit = new ToolStripButton();
            Separator2 = new ToolStripSeparator();
            btnDelete = new ToolStripButton();
            Separator3 = new ToolStripSeparator();
            btnView = new ToolStripButton();
            btnRefresh = new ToolStripButton();
            pnlBaseToolStrip = new Panel();
            pnlBaseBottom.SuspendLayout();
            pnlBottomButtonHolder.SuspendLayout();
            tsBase.SuspendLayout();
            pnlBaseToolStrip.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBaseBottom
            // 
            pnlBaseBottom.Location = new Point(0, 398);
            pnlBaseBottom.Size = new Size(800, 52);
            // 
            // pnlBottomButtonHolder
            // 
            pnlBottomButtonHolder.Location = new Point(589, 3);
            // 
            // tsBase
            // 
            tsBase.Items.AddRange(new ToolStripItem[] { btnAdd, separator1, btnEdit, Separator2, btnDelete, Separator3, btnView, btnRefresh });
            tsBase.Location = new Point(0, 0);
            tsBase.Name = "tsBase";
            tsBase.Size = new Size(800, 25);
            tsBase.TabIndex = 2;
            tsBase.Text = "baseToolStripMenuItemEx1";
            // 
            // btnAdd
            // 
            btnAdd.Image = Properties.Resources.add_folder;
            btnAdd.ImageTransparentColor = Color.Magenta;
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(76, 22);
            btnAdd.Text = "&Add Item";
            btnAdd.Click += btnAdd_Click;
            // 
            // separator1
            // 
            separator1.Name = "separator1";
            separator1.Size = new Size(6, 25);
            // 
            // btnEdit
            // 
            btnEdit.Image = Properties.Resources.edit_folder;
            btnEdit.ImageTransparentColor = Color.Magenta;
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(74, 22);
            btnEdit.Text = "&Edit Item";
            btnEdit.Click += btnEdit_Click;
            // 
            // Separator2
            // 
            Separator2.Name = "Separator2";
            Separator2.Size = new Size(6, 25);
            // 
            // btnDelete
            // 
            btnDelete.Image = Properties.Resources.trash;
            btnDelete.ImageTransparentColor = Color.Magenta;
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(87, 22);
            btnDelete.Text = "&Delete Item";
            btnDelete.Click += btnDelete_Click;
            // 
            // Separator3
            // 
            Separator3.Name = "Separator3";
            Separator3.Size = new Size(6, 25);
            // 
            // btnView
            // 
            btnView.Image = Properties.Resources.file;
            btnView.ImageTransparentColor = Color.Magenta;
            btnView.Name = "btnView";
            btnView.Size = new Size(79, 22);
            btnView.Text = "&View Item";
            btnView.Click += btnView_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Alignment = ToolStripItemAlignment.Right;
            btnRefresh.Image = Properties.Resources.refresh;
            btnRefresh.ImageTransparentColor = Color.Magenta;
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(66, 22);
            btnRefresh.Text = "&Refresh";
            btnRefresh.Click += btnRefresh_Click;
            // 
            // pnlBaseToolStrip
            // 
            pnlBaseToolStrip.Controls.Add(tsBase);
            pnlBaseToolStrip.Dock = DockStyle.Top;
            pnlBaseToolStrip.Location = new Point(0, 70);
            pnlBaseToolStrip.Name = "pnlBaseToolStrip";
            pnlBaseToolStrip.Size = new Size(800, 29);
            pnlBaseToolStrip.TabIndex = 3;
            // 
            // BaseFormListExtended
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlBaseToolStrip);
            DisplayInfoBar = true;
            Name = "BaseFormListExtended";
            Text = "BaseFormListExtended";
            Controls.SetChildIndex(pnlBaseBottom, 0);
            Controls.SetChildIndex(pnlBaseToolStrip, 0);
            pnlBaseBottom.ResumeLayout(false);
            pnlBottomButtonHolder.ResumeLayout(false);
            tsBase.ResumeLayout(false);
            tsBase.PerformLayout();
            pnlBaseToolStrip.ResumeLayout(false);
            pnlBaseToolStrip.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        protected Controls.BaseToolStripMenuItemEx tsBase;
        protected ToolStripButton btnAdd;
        protected ToolStripSeparator separator1;
        protected ToolStripButton btnEdit;
        protected ToolStripSeparator Separator2;
        protected ToolStripButton btnDelete;
        protected ToolStripSeparator Separator3;
        protected ToolStripButton btnView;
        protected ToolStripButton btnRefresh;
        protected Panel pnlBaseToolStrip;
    }
}