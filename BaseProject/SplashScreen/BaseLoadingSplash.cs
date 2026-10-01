using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseProject.SplashScreen {
    public partial class BaseLoadingSplash : Form {
        #region Fields
        private string _statusInfo = "Please wait...";
        #endregion
        
        #region Properties
        [Browsable(false)]
        public string StatusInfo {
            get {
                return _statusInfo;
            }
            set {
                _statusInfo = value;
                ChangeStatusText();
            }
        }

        #endregion

        public BaseLoadingSplash() {
            InitializeComponent();
        }
        
        #region Status
        private void ChangeStatusText() {
            if (IsDisposed) {
                return;
            }

            if (InvokeRequired) {
                BeginInvoke(new MethodInvoker(ChangeStatusText));
                return;
            }

            lblStatus.Text = _statusInfo;
        }
        #endregion
    }
}
