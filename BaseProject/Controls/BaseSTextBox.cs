using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Controls {
    public class BaseSTextBox : TextBox {
        #region Fields
        private IContainer components;
        #endregion

        #region Properties
        [Category("BaseProject")]
        [Description("Determines whether an empty value should be highlighted.")]
        [DefaultValue(false)]
        public bool OnEmptyText { get; set; }
        [Category("BaseProject")]
        [Description("The background color when the control loses focus.")]
        public Color OnTxtLeave { get; set; }
        [Category("BaseProject")]
        [Description("The background color when the control is focused.")]
        public Color OnTxtEnter { get; set; }
        #endregion

        #region Constructor
        public BaseSTextBox() {
            InitializeComponent();
            OnTxtEnter = Color.LightSteelBlue;
            OnTxtLeave = SystemColors.Window;
            OnEmptyText = false;
            BackColor = SystemColors.Window;
            MaxLength = 255;
        }
        #endregion

        #region Enter / Leave
        private void BaseSTextBox_Enter(object sender, EventArgs e) {
            BackColor = OnTxtEnter;
        }

        private void BaseSTextBox_Leave(object sender, EventArgs e) {
            if (OnEmptyText) {
                if (string.IsNullOrWhiteSpace(Text)) {
                    BackColor = Color.Red;
                }
                else {
                    BackColor = OnTxtLeave;
                }
            }
            else {
                BackColor = OnTxtLeave;
            }
        }
        #endregion

        #region KeyPress
        private void BaseSTextBox_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == '\'') {
                e.Handled = true;
            }
        }
        #endregion

        #region KeyDown
        private void BaseSTextBox_KeyDown(object sender, KeyEventArgs e) {

        }
        #endregion

        #region Clipboard
        protected override void WndProc(ref Message m) {
            // WM_PASTE
            if (m.Msg == 0x0302) {
                string clipboardText = Clipboard.GetText();
                if (!string.IsNullOrEmpty(clipboardText)) {
                    string text = clipboardText.Trim().Replace("'", "");
                    int selectionStart = SelectionStart;
                    int selectionLength = SelectionLength;
                    Text = Text.Remove(selectionStart, selectionLength).Insert(selectionStart, text);
                    SelectionStart = selectionStart + text.Length;
                }
                return;
            }
            base.WndProc(ref m);
        }
        #endregion

        #region Dispose
        protected override void Dispose(bool disposing) {
            if (disposing && components != null) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

        #region InitializeComponent
        private void InitializeComponent() {
            base.SuspendLayout();
            base.KeyDown += new KeyEventHandler(BaseSTextBox_KeyDown);
            base.Leave += new EventHandler(BaseSTextBox_Leave);
            base.KeyPress += new KeyPressEventHandler(BaseSTextBox_KeyPress);
            base.Enter += new EventHandler(BaseSTextBox_Enter);
            base.ResumeLayout(false);
        }
        #endregion
    }
}
