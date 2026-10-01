namespace BaseProject.Forms {
    partial class BaseFormListExtendedAsync {
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
            pnlBaseToolStrip = new Panel();
            tsBase = new ToolStrip();
            btnAdd = new ToolStripButton();
            Separator1 = new ToolStripSeparator();
            btnEdit = new ToolStripButton();
            Separator2 = new ToolStripSeparator();
            btnDelete = new ToolStripButton();
            Separator3 = new ToolStripSeparator();
            btnView = new ToolStripButton();
            btnRefresh = new ToolStripButton();
            pnlBaseToolStrip.SuspendLayout();
            tsBase.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBaseToolStrip
            // 
            pnlBaseToolStrip.Controls.Add(tsBase);
            pnlBaseToolStrip.Dock = DockStyle.Top;
            pnlBaseToolStrip.Location = new Point(0, 93);
            pnlBaseToolStrip.Name = "pnlBaseToolStrip";
            pnlBaseToolStrip.Size = new Size(800, 31);
            pnlBaseToolStrip.TabIndex = 3;
            // 
            // tsBase
            // 
            tsBase.Dock = DockStyle.Fill;
            tsBase.Items.AddRange(new ToolStripItem[] { btnAdd, Separator1, btnEdit, Separator2, btnDelete, Separator3, btnView, btnRefresh });
            tsBase.Location = new Point(0, 0);
            tsBase.Name = "tsBase";
            tsBase.Size = new Size(800, 31);
            tsBase.TabIndex = 0;
            tsBase.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            btnAdd.Image = Properties.Resources.add_folder;
            btnAdd.ImageTransparentColor = Color.Magenta;
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(76, 28);
            btnAdd.Text = "&Add Item";
            btnAdd.Click += btnAdd_Click;
            // 
            // Separator1
            // 
            Separator1.Name = "Separator1";
            Separator1.Size = new Size(6, 31);
            // 
            // btnEdit
            // 
            btnEdit.Image = Properties.Resources.edit_folder;
            btnEdit.ImageTransparentColor = Color.Magenta;
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(74, 28);
            btnEdit.Text = "&Edit Item";
            btnEdit.Click += btnEdit_Click;
            // 
            // Separator2
            // 
            Separator2.Name = "Separator2";
            Separator2.Size = new Size(6, 31);
            // 
            // btnDelete
            // 
            btnDelete.Image = Properties.Resources.trash;
            btnDelete.ImageTransparentColor = Color.Magenta;
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(87, 28);
            btnDelete.Text = "&Delete Item";
            btnDelete.Click += btnDelete_Click;
            // 
            // Separator3
            // 
            Separator3.Name = "Separator3";
            Separator3.Size = new Size(6, 31);
            // 
            // btnView
            // 
            btnView.Image = Properties.Resources.file;
            btnView.ImageTransparentColor = Color.Magenta;
            btnView.Name = "btnView";
            btnView.Size = new Size(79, 28);
            btnView.Text = "&View Item";
            btnView.Click += btnView_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Alignment = ToolStripItemAlignment.Right;
            btnRefresh.Image = Properties.Resources.refresh;
            btnRefresh.ImageTransparentColor = Color.Magenta;
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(66, 28);
            btnRefresh.Text = "&Refresh";
            btnRefresh.Click += btnRefresh_Click;
            // 
            // BaseFormListExtendedAsync
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlBaseToolStrip);
            Name = "BaseFormListExtendedAsync";
            Text = "BaseFormListExtendedAsync";
            Load += BaseFormListExtendedAsync_Load;
            Controls.SetChildIndex(pnlBaseToolStrip, 0);
            pnlBaseToolStrip.ResumeLayout(false);
            pnlBaseToolStrip.PerformLayout();
            tsBase.ResumeLayout(false);
            tsBase.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        protected Panel pnlBaseToolStrip;
        protected ToolStrip tsBase;
        protected ToolStripButton btnAdd;
        protected ToolStripSeparator Separator1;
        protected ToolStripButton btnEdit;
        protected ToolStripSeparator Separator2;
        protected ToolStripButton btnDelete;
        protected ToolStripSeparator Separator3;
        protected ToolStripButton btnView;
        protected ToolStripButton btnRefresh;
    }
}