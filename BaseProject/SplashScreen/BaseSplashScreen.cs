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
    public partial class BaseSplashScreen : Form {
        #region Fields
        private string _statusInfo = "Loading...";
        private string _buildInfo = "";
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

        [Browsable(false)]
        public string BuildInfo {
            get {
                return _buildInfo;
            }
            set {
                _buildInfo = value;
                ChangeBuildInfo();
            }
        }
        #endregion

        public BaseSplashScreen() {
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

        #region Build
        private void ChangeBuildInfo() {
            if (IsDisposed) {
                return;
            }

            if (InvokeRequired) {
                BeginInvoke(new MethodInvoker(ChangeBuildInfo));
                return;
            }

            lblBuild.Text = $"Build {_buildInfo}";
        }

        #endregion

        #region Close

        protected override void OnFormClosing(
            FormClosingEventArgs e) {
            base.OnFormClosing(e);
        }

        #endregion
    }
}
