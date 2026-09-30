using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Forms {
    public partial class BaseFormList : Form {
        #region Properties

        [Browsable(false)]
        public bool IsDirty { get; protected set; }

        [Category("BaseProject")]
        [Description("Allows the Enter key to behave like the Tab key.")]
        [DefaultValue(true)]
        public bool UseKeyDownTab { get; set; }

        [Category("BaseProject")]
        [Description("Displays the information bar.")]
        [DefaultValue(true)]
        public bool DisplayInfoBar {
            get {
                return pnlInfo.Visible;
            }
            set {
                pnlInfo.Visible = value;
            }
        }

        [Category("BaseProject")]
        [Description("Image displayed in the information bar.")]
        public Image InfoImage {
            get {
                return picInfo.Image;
            }
            set {
                picInfo.Image = value;
            }
        }

        [Category("BaseProject")]
        [Description("Title displayed in the information bar.")]
        public string InfoText1 {
            get {
                return lblInfoTitle.Text;
            }
            set {
                lblInfoTitle.Text = value;
            }
        }

        [Category("BaseProject")]
        [Description("Message displayed in the information bar.")]
        public string InfoText2 {
            get {
                return lblInfoMessage.Text;
            }
            set {
                lblInfoMessage.Text = value;
            }
        }

        [Category("BaseProject")]
        [Description("Background color of the information bar.")]
        public Color InfoBackColor {
            get {
                return pnlInfo.BackColor;
            }
            set {
                pnlInfo.BackColor = value;
            }
        }

        [Category("BaseProject")]
        [Description("Color of the information title.")]
        public Color InfoTitleColor {
            get {
                return lblInfoTitle.ForeColor;
            }
            set {
                lblInfoTitle.ForeColor = value;
            }
        }

        [Category("BaseProject")]
        [Description("Color of the information message.")]
        public Color InfoMessageColor {
            get {
                return lblInfoMessage.ForeColor;
            }
            set {
                lblInfoMessage.ForeColor = value;
            }
        }
        #endregion

        #region Constructor

        public BaseFormList() {
            InitializeComponent();
            IsDirty = false;
            UseKeyDownTab = true;
            DisplayInfoBar = true;
            InfoText1 = "Information";
            InfoText2 = "Ready.";
            InfoTitleColor = Color.Black;
            InfoMessageColor = Color.Black;
        }

        #endregion

        #region Key Events

        private void BaseFormList_KeyDown(
            object sender,
            KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.Enter:
                    if (!UseKeyDownTab) {
                        return;
                    }
                    e.SuppressKeyPress = true;
                    SendKeys.Send("{TAB}");
                    break;

                case Keys.F5:
                    RefreshList();
                    break;

                case Keys.Escape:
                    Close();
                    break;
            }
        }

        #endregion

        #region Refresh

        protected virtual void RefreshList() {
        }

        #endregion

        #region Close

        private void btnClose_Click(
            object sender,
            EventArgs e) {
            Close();
        }

        #endregion
    }
}
