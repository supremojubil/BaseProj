using BaseProject.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.BaseClass {
    public class CCommonForms {
        #region Connection Settings
        public bool ConnectionSettings() {
            using (ManageConnectionSettings frm = new ManageConnectionSettings()) {
               return frm.ShowDialog() == DialogResult.OK;
            }
        }
        #endregion

        #region Password For Settings
        public bool PasswordForSettings() {
            using (ManagePasswordForSettings frm = new ManagePasswordForSettings()) {
                return frm.ShowDialog() == DialogResult.OK;
            }
        }
        #endregion

    }
}
