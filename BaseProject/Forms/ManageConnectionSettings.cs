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
    public partial class ManageConnectionSettings : BaseMaintainForm {
        public ManageConnectionSettings() {
            InitializeComponent();
        }

        private void ManageConnectionSettings_Load(object sender, EventArgs e) {
            LoadConnectionSettings();
        }
        private void LoadConnectionSettings() {
            PublicConnection connection = new PublicConnection();
            txtUsername.Text = connection.Username;
            txtPassword.Text = connection.Password;
            txtHost.Text = connection.Host;
            txtDatabase.Text = connection.Database;
            txtPort.Text = connection.Port.ToString();
        }

        protected override bool OnSaveAdd() {
            if (!CBaseMessages.AskMessage("Save connection settings?", "Confirm")) {
                return false;
            }
            PublicConnection connection = new PublicConnection();
            connection.Username = txtUsername.Text.Trim();
            connection.Password = txtPassword.Text;
            connection.Host = txtHost.Text.Trim();
            connection.Database = txtDatabase.Text.Trim();
            connection.Port = txtPort.Text.Trim();
            CBaseMessages.ShowMessage("Successful!", "Connection settings have been successfully saved.", "Information", CBaseMessages.MSGINFO);
            return true;
        }

        protected override bool ValidateDataOnSave() {
            if (string.IsNullOrWhiteSpace(txtUsername.Text)) {
                CBaseMessages.WarningMessage("Please enter username.", "Warning");
                txtUsername.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtHost.Text)) {
                CBaseMessages.WarningMessage("Please enter host.", "Warning");
                txtHost.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDatabase.Text)) {
                CBaseMessages.WarningMessage("Please enter database.", "Warning");
                txtDatabase.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPort.Text)) {
                CBaseMessages.WarningMessage("Please enter port.", "Warning");
                txtPort.Focus();
                return false;
            }
            if (!uint.TryParse(txtPort.Text, out uint port)) {
                CBaseMessages.WarningMessage("Please enter a valid port.", "Warning");
                txtPort.Focus();
                return false;
            }
            if (port == 0 || port > 65535) {
                CBaseMessages.WarningMessage("Please enter a valid port between 1 and 65535.", "Warning");
                txtPort.Focus();
                return false;
            }
            return true;
        }
    }
}
