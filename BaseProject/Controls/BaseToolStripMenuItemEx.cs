using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Controls {
    public class BaseToolStripMenuItemEx : ToolStrip {
        #region Fields
        private IContainer components;
        #endregion

        #region Properties
        [Category("BaseProject")]
        [Description("Determines whether the menu item can be disabled when it is not needed.")]
        [DefaultValue(false)]
        public bool DisableWhenNotNeeded { get; set; }
        #endregion

        #region Constructor
        public BaseToolStripMenuItemEx() {
            InitializeComponent();
            if (Enabled) {
                DisableWhenNotNeeded = false;
            }
            else {
                DisableWhenNotNeeded = true;
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
            components = new Container();
        }
        #endregion
    }
}
