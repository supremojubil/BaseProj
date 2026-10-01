namespace BaseProject.Forms {
    partial class BaseFormListWithSearchAsync {
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
            pnlBaseSearch = new Panel();
            lblBaseSearch = new Label();
            pnlSearchDate = new Panel();
            lblDateTo = new Label();
            lblDateFrom = new Label();
            dtpDateFromBase = new DateTimePicker();
            dtpDateToBase = new DateTimePicker();
            stxtSearch = new BaseProject.Controls.BaseSTextBox();
            btnUseItem = new Button();
            pnlBaseBottom.SuspendLayout();
            pnlBottomButtonHolder.SuspendLayout();
            pnlInfo.SuspendLayout();
            pnlInfoText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picInfo).BeginInit();
            pnlBaseSearch.SuspendLayout();
            pnlSearchDate.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBaseToolStrip
            // 
            pnlBaseToolStrip.Location = new Point(0, 77);
            // 
            // pnlBaseBottom
            // 
            pnlBaseBottom.Location = new Point(0, 426);
            // 
            // pnlBottomButtonHolder
            // 
            pnlBottomButtonHolder.Controls.Add(btnUseItem);
            pnlBottomButtonHolder.Controls.SetChildIndex(btnClose, 0);
            pnlBottomButtonHolder.Controls.SetChildIndex(btnUseItem, 0);
            // 
            // pnlBaseSearch
            // 
            pnlBaseSearch.BackColor = Color.FromArgb(227, 239, 255);
            pnlBaseSearch.Controls.Add(lblBaseSearch);
            pnlBaseSearch.Controls.Add(pnlSearchDate);
            pnlBaseSearch.Controls.Add(stxtSearch);
            pnlBaseSearch.Dock = DockStyle.Top;
            pnlBaseSearch.Location = new Point(0, 108);
            pnlBaseSearch.Name = "pnlBaseSearch";
            pnlBaseSearch.Size = new Size(800, 77);
            pnlBaseSearch.TabIndex = 4;
            // 
            // lblBaseSearch
            // 
            lblBaseSearch.AutoSize = true;
            lblBaseSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBaseSearch.Image = Properties.Resources.search_16;
            lblBaseSearch.ImageAlign = ContentAlignment.MiddleLeft;
            lblBaseSearch.Location = new Point(31, 28);
            lblBaseSearch.Name = "lblBaseSearch";
            lblBaseSearch.Size = new Size(66, 15);
            lblBaseSearch.TabIndex = 4;
            lblBaseSearch.Text = "      Search:";
            // 
            // pnlSearchDate
            // 
            pnlSearchDate.Controls.Add(lblDateTo);
            pnlSearchDate.Controls.Add(lblDateFrom);
            pnlSearchDate.Controls.Add(dtpDateFromBase);
            pnlSearchDate.Controls.Add(dtpDateToBase);
            pnlSearchDate.Dock = DockStyle.Right;
            pnlSearchDate.Location = new Point(557, 0);
            pnlSearchDate.Name = "pnlSearchDate";
            pnlSearchDate.Size = new Size(243, 77);
            pnlSearchDate.TabIndex = 1;
            // 
            // lblDateTo
            // 
            lblDateTo.AutoSize = true;
            lblDateTo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDateTo.Location = new Point(14, 42);
            lblDateTo.Name = "lblDateTo";
            lblDateTo.Size = new Size(53, 15);
            lblDateTo.TabIndex = 4;
            lblDateTo.Text = "Date To:";
            // 
            // lblDateFrom
            // 
            lblDateFrom.AutoSize = true;
            lblDateFrom.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDateFrom.Location = new Point(11, 13);
            lblDateFrom.Name = "lblDateFrom";
            lblDateFrom.Size = new Size(69, 15);
            lblDateFrom.TabIndex = 3;
            lblDateFrom.Text = "Date From:";
            // 
            // dtpDateFromBase
            // 
            dtpDateFromBase.Format = DateTimePickerFormat.Short;
            dtpDateFromBase.Location = new Point(86, 9);
            dtpDateFromBase.Name = "dtpDateFromBase";
            dtpDateFromBase.Size = new Size(145, 23);
            dtpDateFromBase.TabIndex = 0;
            dtpDateFromBase.ValueChanged += dtpDateFromBase_ValueChanged;
            // 
            // dtpDateToBase
            // 
            dtpDateToBase.Format = DateTimePickerFormat.Short;
            dtpDateToBase.Location = new Point(87, 38);
            dtpDateToBase.Name = "dtpDateToBase";
            dtpDateToBase.Size = new Size(144, 23);
            dtpDateToBase.TabIndex = 1;
            dtpDateToBase.ValueChanged += dtpDateToBase_ValueChanged;
            // 
            // stxtSearch
            // 
            stxtSearch.BackColor = SystemColors.Window;
            stxtSearch.Location = new Point(104, 23);
            stxtSearch.MaxLength = 255;
            stxtSearch.Name = "stxtSearch";
            stxtSearch.OnTxtEnter = Color.LightSteelBlue;
            stxtSearch.OnTxtLeave = SystemColors.Window;
            stxtSearch.Size = new Size(302, 23);
            stxtSearch.TabIndex = 0;
            stxtSearch.TextChanged += stxtSearch_TextChanged;
            stxtSearch.KeyDown += stxtSearch_KeyDown;
            // 
            // btnUseItem
            // 
            btnUseItem.Location = new Point(36, 18);
            btnUseItem.Name = "btnUseItem";
            btnUseItem.Size = new Size(89, 28);
            btnUseItem.TabIndex = 1;
            btnUseItem.Text = "&Use Item";
            btnUseItem.UseVisualStyleBackColor = true;
            btnUseItem.Click += btnUseItem_Click;
            // 
            // BaseFormListWithSearchAsync
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 490);
            Controls.Add(pnlBaseSearch);
            Name = "BaseFormListWithSearchAsync";
            Text = "BaseFormListWithSearchAsync";
            Controls.SetChildIndex(pnlBaseBottom, 0);
            Controls.SetChildIndex(pnlInfo, 0);
            Controls.SetChildIndex(pnlBaseToolStrip, 0);
            Controls.SetChildIndex(pnlBaseSearch, 0);
            pnlBaseBottom.ResumeLayout(false);
            pnlBottomButtonHolder.ResumeLayout(false);
            pnlInfo.ResumeLayout(false);
            pnlInfoText.ResumeLayout(false);
            pnlInfoText.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picInfo).EndInit();
            pnlBaseSearch.ResumeLayout(false);
            pnlBaseSearch.PerformLayout();
            pnlSearchDate.ResumeLayout(false);
            pnlSearchDate.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlBaseSearch;
        private Label lblBaseSearch;
        private Panel pnlSearchDate;
        private Label lblDateTo;
        private Label lblDateFrom;
        private DateTimePicker dtpDateFromBase;
        private DateTimePicker dtpDateToBase;
        private Controls.BaseSTextBox stxtSearch;
        private Button btnUseItem;
    }
}