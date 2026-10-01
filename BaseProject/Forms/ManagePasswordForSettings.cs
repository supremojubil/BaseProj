using BaseProject.BaseClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseProject.Forms {
    public partial class ManagePasswordForSettings : BaseMaintainForm {
        public ManagePasswordForSettings() {
            InitializeComponent();
        }

        protected override bool OnSaveAdd() {
            if (passwordSTextBox.Text == "admin123!@#") {
                return true;
            } 
            CBaseMessages.WarningMessage("Invalid password. Please try again.", "Warning");
            passwordSTextBox.Clear();
            passwordSTextBox.Focus();
            return false;
        }

        protected override bool ValidateDataOnSave() {
            if (string.IsNullOrEmpty(passwordSTextBox.Text)) {
                CBaseMessages.WarningMessage("Please enter password.", "Warning");
                passwordSTextBox.Focus();
                return false;
            }
            return true;
        }
    }
}
