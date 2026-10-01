using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Controls {
    public class BaseNumericOnlyEditingControl : DataGridViewTextBoxEditingControl {
        #region Validation
        private bool IsValidForNumberInput(char c) {
            if (!char.IsDigit(c) && c != '\b' && c != '.') {
                return c == '-';
            }
            return true;
        }
        #endregion

        #region KeyPress
        protected override void OnKeyPress(KeyPressEventArgs e) {
            if (!IsValidForNumberInput(e.KeyChar)) {
                e.Handled = true;
            }
            base.OnKeyPress(e);
        }
        #endregion
    }
}
