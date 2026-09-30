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
using static BaseProject.BaseClass.BaseConstants;

namespace BaseProject.Forms {
    public partial class BaseMaintainForm : BaseFormList {
        #region Fields
        private FormMode _formMode;
        private bool _useTwoSaveButtons;
        private string _textSaveClose;
        private string _textClose;
        #endregion

        #region Properties
        [Browsable(false)]
        [Category("BaseProject")]
        [Description("Determines the current form mode.")]
        public FormMode FormMode {
            get {
                return _formMode;
            }
            set {
                _formMode = value;
                ApplyFormMode();
            }
        }
        [Category("BaseProject")]
        [Description("Determines whether Save and New is available.")]
        [DefaultValue(true)]
        public bool UseTwoSaveButtons {
            get {
                return _useTwoSaveButtons;
            }
            set {
                _useTwoSaveButtons = value;
                ApplyFormMode();
            }
        }
        [Category("BaseProject")]
        [Description("Text displayed on the Save and Close button.")]
        public string TextSaveClose {
            get {
                return _textSaveClose;
            }
            set {
                _textSaveClose = value;
                if (btnBaseSaveClose != null) {
                    btnBaseSaveClose.Text = value;
                }
            }
        }
        [Category("BaseProject")]
        [Description("Text displayed on the Close button.")]
        public string TextClose {
            get {
                return _textClose;
            }
            set {
                _textClose = value;
                if (_textClose != null) {
                    btnClose.Text = value;
                }
            }
        }
        #endregion

        #region Constructor
        public BaseMaintainForm() {
            InitializeComponent();
            _useTwoSaveButtons = true;
            _textSaveClose = "&Save and Close";
            _textClose = "&Cancel";
            FormMode = FormMode.Add;
        }
        #endregion

        #region Form Mode
        private void ApplyFormMode() {
            if (btnBaseSaveClose == null || btnBaseSaveNew == null || btnClose == null) {
                return;
            }
            switch (FormMode) {
                case FormMode.Add:
                    ConfigureAddMode();
                    break;
                case FormMode.Update:
                    ConfigureUpdateMode();
                    break;
                case FormMode.ReadOnly:
                    ConfigureReadOnlyMode();
                    break;
            }
            Invalidate();
        }
        private void ConfigureAddMode() {
            btnBaseSaveClose.Text = TextSaveClose;
            btnBaseSaveClose.Visible = true;
            btnBaseSaveClose.Enabled = true;
            btnBaseSaveNew.Text = "Save and &New";
            btnBaseSaveNew.Visible = UseTwoSaveButtons;
            btnBaseSaveNew.Enabled = UseTwoSaveButtons;
            btnClose.Text = TextClose;
        }
        private void ConfigureUpdateMode() {
            btnBaseSaveClose.Text = "&Update";
            btnBaseSaveClose.Visible = true;
            btnBaseSaveClose.Enabled = true;
            btnBaseSaveNew.Visible = false;
            btnBaseSaveNew.Enabled = false;
            btnClose.Text = TextClose;
        }

        private void ConfigureReadOnlyMode() {
            btnBaseSaveClose.Visible = false;
            btnBaseSaveClose.Enabled = false;
            btnBaseSaveNew.Visible = false;
            btnBaseSaveNew.Enabled = false;
            btnClose.Text = "&Close";
        }
        #endregion

        #region Save and Close
        private void btnBaseSaveClose_Click(object sender, EventArgs e) {
            try {
                if (FormMode == FormMode.Add) {
                    SaveNewRecord();
                    return;
                }
                if (FormMode == FormMode.Update) {
                    UpdateRecord();
                    return;
                }
                if (FormMode == FormMode.ReadOnly) {
                    Close();
                }
            }
            catch (Exception ex) {
                ShowException(ex);
            }
        }

        private void SaveNewRecord() {
            if (!ValidateDataOnSave()) {
                return;
            }
            if (!OnSaveAdd()) {
                return;
            }
            IsDirty = true;
            Close();
        }

        private void UpdateRecord() {
            if (!ValidateDataOnUpdate()) {
                return;
            }
            if (!OnSaveUpdate()) {
                return;
            }
            IsDirty = true;
            Close();
        }
        #endregion

        #region Save and New

        private void btnBaseSaveNew_Click(object sender, EventArgs e) {
            try {
                if (FormMode == FormMode.Add) {
                    SaveAndCreateAnother();
                    return;
                }
                if (FormMode == FormMode.ReadOnly) {
                    Close();
                }
            }
            catch (Exception ex) {
                ShowException(ex);
            }
        }

        private void SaveAndCreateAnother() {
            if (!ValidateDataOnSave()) {
                return;
            }
            if (!OnSaveAdd()) {
                return;
            }
            IsDirty = true;
            OnLoadAdd();
        }
        #endregion

        #region Error Handling
        protected virtual void ShowException(Exception exception) {
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
        #endregion

        #region Add
        protected virtual void OnLoadAdd() {
            throw new NotImplementedException("OnLoadAdd has not been implemented.");
        }
        [Description("Apply add/save logic here.")]
        protected virtual bool OnSaveAdd() {
            throw new NotImplementedException("OnSaveAdd has not been implemented.");
        }
        #endregion

        #region Update
        [Description("Apply update logic here.")]
        protected virtual bool OnSaveUpdate() {
            throw new NotImplementedException("OnSaveUpdate has not been implemented.");
        }
        #endregion

        #region Validation
        [Description("Apply validation logic before saving a new record.")]
        protected virtual bool ValidateDataOnSave() {
            throw new NotImplementedException("ValidateDataOnSave has not been implemented.");
        }
        [Description("Apply validation logic before updating a record.")]
        protected virtual bool ValidateDataOnUpdate() {
            throw new NotImplementedException("ValidateDataOnUpdate has not been implemented.");
        }
        #endregion
    }
}
