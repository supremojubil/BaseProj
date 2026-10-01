using BaseProject.BaseClass;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseProject.Forms {
    public partial class BaseFormListAsync : Form {
        #region Fields
        private Image _infoImage;
        private bool _displayInfoBar;
        #endregion

        #region Properties
        [Browsable(true)]
        [Category("BaseProject")]
        [Description("The image that will be used for the information bar.")]
        public Image InfoImage {
            get {
                return _infoImage;
            }
            set {
                _infoImage = value;
                if (picInfo != null) {
                    picInfo.Image = _infoImage;
                }
                Invalidate();
            }
        }
        [Browsable(true)]
        [Category("BaseProject")]
        [Description("Determines whether the information bar is displayed.")]
        [DefaultValue(true)]
        public bool DisplayInfoBar {
            get {
                return _displayInfoBar;
            }
            set {
                _displayInfoBar = value;
                if (pnlInfo != null) {
                    pnlInfo.Visible = _displayInfoBar;
                }
                Invalidate();
            }
        }
        [Browsable(true)]
        [Category("BaseProject")]
        [Description("Text displayed in the information title.")]
        public string InfoText1 {
            get {
                return lblInfoTitle.Text;
            }
            set {
                lblInfoTitle.Text = value;
            }
        }

        [Browsable(true)]
        [Category("BaseProject")]
        [Description("Text displayed in the information message.")]
        public string InfoText2 {
            get {
                return lblInfoMessage.Text;
            }
            set {
                lblInfoMessage.Text = value;
            }
        }

        [Browsable(true)]
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

        [Browsable(true)]
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

        [Browsable(true)]
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

        [Category("BaseProject")]
        [Description("Allows the Enter key to behave like the Tab key.")]
        [DisplayName("Key Down")]
        [DefaultValue(true)]
        public bool UseKeyDownTab { get; set; }

        [Browsable(false)]
        public bool IsDirty { get; protected set; }
        #endregion
        public BaseFormListAsync() {
            InitializeComponent();
            IsDirty = false;
        }

        private async void BaseFormListAsync_KeyDown(object sender, KeyEventArgs e) {
            if (!UseKeyDownTab) {
                return;
            }
            switch (e.KeyCode) {
                case Keys.Enter:
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    SendKeys.Send("{TAB}");
                    break;
                case Keys.F5:
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    await RefreshListAsync();
                    break;
                case Keys.Escape:
                    Close();
                    break;
            }
        }

        protected virtual Task RefreshListAsync() {
            return Task.CompletedTask;
        }

        private void btnClose_Click(object sender, EventArgs e) {
            Close();
        }
        #region Error Handling

        protected virtual void ShowException(Exception exception) {
            if (exception is ArgumentException) {
                CBaseMessages.ErrorMessage(exception.Message, "Argument Error");
                return;
            }

            if (exception is NotSupportedException) {
                CBaseMessages.ErrorMessage(exception.Message, "Not Supported Error");
                return;
            }

            if (exception is HttpRequestException) {
                CBaseMessages.ErrorMessage(exception.Message, "HTTP Request Error");
                return;
            }

            if (exception is JsonException) {
                CBaseMessages.ErrorMessage(exception.Message, "JSON Serialization Error");
                return;
            }

            if (exception is DbEntityValidationException entityException) {
                CBaseMessages.ErrorMessage(GetEntityValidationMessage(entityException), "Entity Error");
                return;
            }

            if (exception is EntityException) {
                CBaseMessages.ErrorMessage(exception.Message, "Entity Error");
                return;
            }

            if (exception is MySqlException mySqlException) {
                HandleMySqlException(mySqlException);
                return;
            }

            if (exception is WarningException) {
                CBaseMessages.ErrorMessage(exception.Message, "Warning");
                return;
            }

            StringBuilder message = new StringBuilder();
            message.Append(exception.Message);
            Exception innerException = exception.InnerException;

            while (innerException != null) {
                message.AppendLine();
                message.Append("Inner exception: ");
                message.Append(innerException.Message);
                innerException = innerException.InnerException;
            }

            CBaseMessages.ErrorMessage(message.ToString(), "Error");
        }

        private void HandleMySqlException(MySqlException exception) {
            switch (exception.Number) {
                case 0:
                    CBaseMessages.ErrorMessage("Can not connect to server.\n" + "Please contact administrator.", "MySql Error");
                    break;

                case 1045:
                    CBaseMessages.ErrorMessage("Invalid username/password.\n" + "Please try again.", "MySql Error");
                    break;

                default:
                    CBaseMessages.ErrorMessage(exception.Message, "MySql Error");
                    break;
            }
        }

        private string GetEntityValidationMessage(DbEntityValidationException exception) {
            StringBuilder message = new StringBuilder();
            foreach (DbEntityValidationResult entityResult in exception.EntityValidationErrors) {
                foreach (DbValidationError validationError in entityResult.ValidationErrors) {
                    if (!string.IsNullOrWhiteSpace(validationError.PropertyName)) {
                        message.Append(validationError.PropertyName);
                        message.Append(": ");
                    }
                    message.AppendLine(validationError.ErrorMessage);
                }
            }
            return message.ToString();
        }
        #endregion
    }
}
