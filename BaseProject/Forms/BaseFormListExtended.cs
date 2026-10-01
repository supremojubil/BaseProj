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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseProject.Forms {
    public partial class BaseFormListExtended : BaseFormList {
        #region Fields
        private bool _allowAdd;
        private bool _allowEdit;
        private bool _allowDelete;
        private bool _allowView;
        private bool _allowRefresh;
        private bool _showToolStrip;

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
            }
        }

        [Category("BaseProject List")]
        [Description("Determines whether the View button is displayed.")]
        [DefaultValue(true)]
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

                if (pnlBaseToolStrip != null) {
                    pnlBaseToolStrip.Visible = value;
                    pnlBaseToolStrip.Enabled = value;
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
        public BaseFormListExtended() {
            InitializeComponent();
        }
        #region ToolStrip Events
        private void btnAdd_Click(object sender, EventArgs e) {
            try {
                if (AddNewitem()) {
                    RefreshList();
                    IsDirty = true;
                }
            }
            catch (ArgumentException ex) {
                ShowError(ex.Message, "Argument Error");
            }
            catch (NotSupportedException ex) {
                ShowError(ex.Message, "Not Supported Error");
            }
            catch (EntityException ex) {
                ShowError(ex.Message, "Entity Error");
            }
            catch (DbEntityValidationException ex) {
                ShowError(GetEntityValidationMessage(ex), "Entity Validation Error");
            }
            catch (MySqlException ex) {
                HandleMySqlException(ex);
            }
            catch (Exception ex) {
                ShowException(ex);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e) {
            try {
                if (EditItem()) {
                    RefreshList();
                    IsDirty = true;
                }
            }
            catch (ArgumentException ex) {
                ShowError(ex.Message, "Argument Error");
            }
            catch (NotSupportedException ex) {
                ShowError(ex.Message, "Not Supported Error");
            }
            catch (EntityException ex) {
                ShowError(ex.Message, "Entity Error");
            }
            catch (DbEntityValidationException ex) {
                ShowError(GetEntityValidationMessage(ex), "Entity Error");
            }
            catch (MySqlException ex) {
                HandleMySqlException(ex);
            }
            catch (Exception ex) {
                ShowException(ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            try {
                if (!ValidateDelete()) {
                    return;
                }
                if (DeleteItem()) {
                    RefreshList();
                    IsDirty = true;
                }
            }
            catch (ArgumentException ex) {
                ShowError(ex.Message, "Argument Error");
            }
            catch (NotSupportedException ex) {
                ShowError(ex.Message, "Not Supported Error");
            }
            catch (EntityException ex) {
                ShowError(ex.Message, "Entity Error");
            }
            catch (DbEntityValidationException ex) {
                ShowError(GetEntityValidationMessage(ex), "Entity Error");
            }
            catch (MySqlException ex) {
                HandleMySqlException(ex);
            }
            catch (Exception ex) {
                ShowException(ex);
            }
        }

        private void btnView_Click(object sender, EventArgs e) {
            try {        
                ViewItem();
            }
            catch (ArgumentException ex) {
                ShowError(ex.Message, "Argument Error");
            }
            catch (NotSupportedException ex) {
                ShowError(ex.Message, "Not Supported Error");
            }
            catch (EntityException ex) {
                ShowError(ex.Message, "Entity Error");
            }
            catch (DbEntityValidationException ex) {
                ShowError(GetEntityValidationMessage(ex), "Entity Error");
            }
            catch (MySqlException ex) {
                HandleMySqlException(ex);
            }
            catch (Exception ex) {
                ShowException(ex);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) {
            try {
                RefreshList();
            }
            catch (ArgumentException ex) {
                ShowError(ex.Message, "Argument Error");
            }
            catch (NotSupportedException ex) {
                ShowError(ex.Message, "Not Supported Error");
            }
            catch (EntityException ex) {
                ShowError(ex.Message, "Entity Error");
            }
            catch (DbEntityValidationException ex) {
                ShowError(GetEntityValidationMessage(ex), "Entity Error");
            }
            catch (MySqlException ex) {
                HandleMySqlException(ex);
            }
            catch (Exception ex) {
                ShowException(ex);
            }
        }
        #endregion

        #region List Actions
        protected virtual bool AddNewitem() {
            throw new NotImplementedException("AddNewItem has not been implemented.");
        }
        protected virtual bool EditItem() {
            throw new NotImplementedException("EditItem has not been implemented.");
        }
        protected virtual bool DeleteItem() {
            throw new NotImplementedException("DeleteItem has not been implemented.");
        }
        protected virtual bool ViewItem() {
            throw new NotImplementedException("ViewItem has not been implemented.");
        }
        protected virtual bool ValidateDelete() {
            throw new NotImplementedException("AddNewItem has not been implemented.");
        }
        #endregion

        #region Refresh
        protected override void RefreshList() {

        }
        #endregion

        #region Error Handling
        private void ShowError(string message, string caption) {
            CBaseMessages.ErrorMessage(message, caption);
        }

        private void HandleMySqlException(MySqlException exception) {
            switch (exception.Number) {
                case 0:
                    ShowError("Can not connect to server.\n" + "Please contact administrator.", "MySql Error");
                    break;

                case 1045:
                    ShowError("Invalid username/password.\n" + "Please try again.", "MySql Error");
                    break;

                default:
                    ShowError(exception.Message, "MySql Error");
                    break;
            }
        }

        protected virtual void ShowException(Exception exception) {
            CBaseMessages.ErrorMessage(exception.Message, "Error");
        }
        private string GetEntityValidationMessage(DbEntityValidationException exception) {
            StringBuilder message = new StringBuilder();
            foreach (DbEntityValidationResult entityResult in exception.EntityValidationErrors) {
                foreach (DbValidationError validationError in entityResult.ValidationErrors) {
                    message.AppendLine(validationError.PropertyName + ": " + validationError.ErrorMessage);
                }
            }
            return message.ToString();
        }
        #endregion
    }
}
