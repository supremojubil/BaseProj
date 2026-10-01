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
    public partial class BaseFormListExtendedAsync : BaseFormListAsync {
        #region Fields
        private bool _allowAdd;
        private bool _allowEdit;
        private bool _allowDelete;
        private bool _allowView;
        private bool _allowRefresh;
        private bool _showToolStrip;

        private TextImageRelation _textAndImageRelation;
        private ToolStripRenderMode _renderMode;

        private string _textAdd;
        private string _textEdit;
        private string _textDelete;
        private string _textView;
        private string _textRefresh;
        #endregion

        #region Properties
        [Category("BaseProject List")]
        [Description("Determines whether the Add button is displayed.")]
        [DefaultValue(true)]
        public bool AllowAdd {
            get {
                return _allowAdd;
            }
            set {
                _allowAdd = value;

                if (btnAdd != null) {
                    btnAdd.Visible = value;
                    btnAdd.Enabled = value;
                }

                if (Separator1 != null) {
                    Separator1.Visible = value;
                }
            }
        }

        [Category("BaseProject List")]
        [Description("Determines whether the Edit button is displayed.")]
        [DefaultValue(true)]
        public bool AllowEdit {
            get {
                return _allowEdit;
            }
            set {
                _allowEdit = value;

                if (btnEdit != null) {
                    btnEdit.Visible = value;
                    btnEdit.Enabled = value;
                }

                if (Separator2 != null) {
                    Separator2.Visible = value;
                }
            }
        }

        [Category("BaseProject List")]
        [Description("Determines whether the Delete button is displayed.")]
        [DefaultValue(true)]
        public bool AllowDelete {
            get {
                return _allowDelete;
            }
            set {
                _allowDelete = value;

                if (btnDelete != null) {
                    btnDelete.Visible = value;
                    btnDelete.Enabled = value;
                }
                if (Separator3 != null) {
                    Separator3.Visible = value;
                }
            }
        }

        [Category("BaseProject List")]
        [Description("Determines whether the View button is displayed.")]
        [DefaultValue(false)]
        public bool AllowView {
            get {
                return _allowView;
            }
            set {
                _allowView = value;

                if (btnView != null) {
                    btnView.Visible = value;
                    btnView.Enabled = value;
                }
            }
        }

        [Category("BaseProject List")]
        [Description("Determines whether the Refresh button is displayed.")]
        [DefaultValue(true)]
        public bool AllowRefresh {
            get {
                return _allowRefresh;
            }
            set {
                _allowRefresh = value;

                if (btnRefresh != null) {
                    btnRefresh.Visible = value;
                    btnRefresh.Enabled = value;
                }
            }
        }

        [Category("BaseProject List")]
        [Description("Determines whether the toolbar is displayed.")]
        [DefaultValue(true)]
        public bool ShowToolStrip {
            get {
                return _showToolStrip;
            }
            set {
                _showToolStrip = value;

                if (tsBase != null) {
                    tsBase.Enabled = value;
                    tsBase.Visible = value;
                }

                if (pnlBaseToolStrip != null) {
                    pnlBaseToolStrip.Enabled = value;
                    pnlBaseToolStrip.Visible = value;
                }
            }
        }

        [Category("BaseProject List")]
        [Description("Determines how text and images are displayed on the toolbar buttons.")]
        [DefaultValue(TextImageRelation.ImageBeforeText)]
        public TextImageRelation TextAndImageRelation {
            get {
                return _textAndImageRelation;
            }
            set {
                _textAndImageRelation = value;

                if (btnAdd != null) {
                    btnAdd.TextImageRelation = value;
                }

                if (btnEdit != null) {
                    btnEdit.TextImageRelation = value;
                }

                if (btnDelete != null) {
                    btnDelete.TextImageRelation = value;
                }

                if (btnView != null) {
                    btnView.TextImageRelation = value;
                }

                if (btnRefresh != null) {
                    btnRefresh.TextImageRelation = value;
                }
            }
        }

        [Category("BaseProject List")]
        [Description("Determines the rendering mode of the toolbar.")]
        [DefaultValue(ToolStripRenderMode.ManagerRenderMode)]
        public ToolStripRenderMode RenderMode {
            get {
                return _renderMode;
            }
            set {
                _renderMode = value;

                if (tsBase != null) {
                    tsBase.RenderMode = value;
                }
            }
        }

        [Category("BaseProject List")]
        [Description("Text displayed on the Add button.")]
        public string TextAdd {
            get {
                return _textAdd;
            }
            set {
                _textAdd = value;

                if (btnAdd != null) {
                    btnAdd.Text = value;
                }
            }
        }

        [Category("BaseProject List")]
        [Description("Text displayed on the Edit button.")]
        public string TextEdit {
            get {
                return _textEdit;
            }
            set {
                _textEdit = value;

                if (btnEdit != null) {
                    btnEdit.Text = value;
                }
            }
        }

        [Category("BaseProject List")]
        [Description("Text displayed on the Delete button.")]
        public string TextDelete {
            get {
                return _textDelete;
            }
            set {
                _textDelete = value;

                if (btnDelete != null) {
                    btnDelete.Text = value;
                }
            }
        }

        [Category("BaseProject List")]
        [Description("Text displayed on the View button.")]
        public string TextView {
            get {
                return _textView;
            }
            set {
                _textView = value;

                if (btnView != null) {
                    btnView.Text = value;
                }
            }
        }

        [Category("BaseProject List")]
        [Description("Text displayed on the Refresh button.")]
        public string TextRefresh {
            get {
                return _textRefresh;
            }
            set {
                _textRefresh = value;

                if (btnRefresh != null) {
                    btnRefresh.Text = value;
                }
            }
        }
        #endregion
        public BaseFormListExtendedAsync() {
            InitializeComponent();
        }

        private async void btnAdd_Click(object sender, EventArgs e) {
            try {
                if (await AddNewItem()) {
                    await RefreshListAsync();
                    IsDirty = true;
                }
            }
            catch (Exception ex) {
                ShowException(ex);
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e) {
            try {
                if (await EditItem()) {
                    await RefreshListAsync();
                    IsDirty = true;
                }
            }
            catch (Exception ex) {
                ShowException(ex);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e) {
            try {
                if (!ValidateDelete()) {
                    return;
                }
                if (await DeleteItem()) {
                    await RefreshListAsync();
                    IsDirty = true;
                }
            }
            catch (Exception ex) {
                ShowException(ex);
            }
        }

        private async void btnView_Click(object sender, EventArgs e) {
            try {
                await ViewItem();
            }
            catch (Exception ex) {
                ShowException(ex);
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e) {
            try {
                await RefreshListAsync();
            }
            catch (Exception ex) {
                ShowException(ex);
            }
        }

        private async void BaseFormListExtendedAsync_Load(object sender, EventArgs e) {
            if (DesignMode) {
                return;
            }
            try {
                await RefreshListAsync();
            }
            catch (Exception ex) {
                ShowException(ex);
            }
        }
        #region List Actions

        protected virtual Task<bool> AddNewItem() {
            throw new NotImplementedException("AddNewItem has not been implemented.");
        }

        protected virtual Task<bool> EditItem() {
            throw new NotImplementedException("EditItem has not been implemented.");
        }

        protected virtual Task<bool> DeleteItem() {
            throw new NotImplementedException("DeleteItem has not been implemented.");
        }

        protected virtual Task<bool> ViewItem() {
            throw new NotImplementedException("ViewItem has not been implemented.");
        }

        protected virtual bool ValidateDelete() {
            throw new NotImplementedException("ValidateDelete has not been implemented.");
        }

        #endregion

        #region Refresh

        protected virtual Task RefreshListAsync() {
            throw new NotImplementedException("RefreshListAsync has not been implemented.");
        }

        #endregion

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