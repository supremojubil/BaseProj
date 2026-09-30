using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Controls {
    public class BaseComboBoxEx : ComboBox {
        private IContainer components;
        #region Properties

        [Category("BaseProject")]
        [Description("Determines whether the dropdown should be shown when the control receives focus.")]
        [DefaultValue(false)]
        public bool IsDropShown { get; set; }

        [Category("BaseProject")]
        [Description("Background color when the control loses focus.")]
        public Color OnTxtLeave { get; set; }

        [Category("BaseProject")]
        [Description("Background color when the control receives focus.")]
        public Color OnTxtEnter { get; set; }

        #endregion
        #region Constructor

        public BaseComboBoxEx() {
            OnTxtEnter = Color.LightSteelBlue;
            OnTxtLeave = SystemColors.Window;
            InitializeComponent();
            BackColor = SystemColors.Window;
        }

        #endregion

        #region Events

        private void BaseComboBoxEx_Leave(object sender, EventArgs e) {
            BackColor = OnTxtLeave;
        }

        private void BaseComboBoxEx_Enter(object sender, EventArgs e) {
            BackColor = OnTxtEnter;
            if (IsDropShown) {
                base.DroppedDown = true;
            }
            else {
                base.DroppedDown = false;
            }
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
            base.Leave += new EventHandler(BaseComboBoxEx_Leave);
            base.Enter += new EventHandler(BaseComboBoxEx_Enter);
            base.ResumeLayout(false);
        }
        #endregion
    }
}
