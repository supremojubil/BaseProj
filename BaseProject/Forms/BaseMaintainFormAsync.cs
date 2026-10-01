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
    public partial class BaseMaintainFormAsync : BaseFormListAsync {
        #region Fields
        private BaseConstants.FormMode _formMode;
        private bool _useTwoSaveButtons;
        private string _textSaveClose;
        private string _textClose;
        #endregion

        #region Properties

        [Browsable(false)]
        [Category("BaseProject")]
        [Description("Determines the current form mode.")]
        public BaseConstants.FormMode FormMode {
            get {
                return _formMode;
            }
            set {
                _formMode = value;
                LoadFormMode();
            }
        }

        [Category("BaseProject")]
        [Description("Determines whether Save and Close and Save and New buttons are available.")]
        [DefaultValue(true)]
        public bool UseTwoSaveButtons {
            get {
                return _useTwoSaveButtons;
            }
            set {
                _useTwoSaveButtons = value;
                LoadFormMode();
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

                if (btnClose != null) {
                    btnClose.Text = value;
                }
            }
        }

        #endregion
        public BaseMaintainFormAsync() {
            InitializeComponent();
            FormMode = BaseConstants.FormMode.Add;
        }
        private void LoadFormMode() {
            if (btnBaseSaveClose == null || btnBaseSaveNew == null || btnClose == null) {
                return;
            }
            switch (FormMode) {
                case BaseConstants.FormMode.Add:
                    btnBaseSaveClose.Text = TextSaveClose;
                    btnBaseSaveClose.Visible = true;
                    btnBaseSaveClose.Enabled = true;
                    btnBaseSaveNew.Text = "Save and &New";
                    btnBaseSaveNew.Visible = UseTwoSaveButtons;
                    btnBaseSaveNew.Enabled = UseTwoSaveButtons;
                    btnClose.Text = TextClose;
                    break;
                case BaseConstants.FormMode.Update:
                    btnBaseSaveClose.Text = "&Update and Close";
                    btnBaseSaveClose.Visible = true;
                    btnBaseSaveClose.Enabled = true;
                    btnBaseSaveNew.Visible = false;
                    btnBaseSaveNew.Enabled = false;
                    btnClose.Text = TextClose;
                    break;
                case BaseConstants.FormMode.ReadOnly:
                    btnBaseSaveClose.Visible = false;
                    btnBaseSaveClose.Enabled = false;
                    btnBaseSaveNew.Visible = false;
                    btnBaseSaveNew.Enabled = false;
                    btnClose.Text = TextClose;
                    break;
            }
            Invalidate();
        }

        private async void btnBaseSaveClose_Click(object sender, EventArgs e) {
            try {
                SetEnable(false);
                switch (FormMode) {
                    case BaseConstants.FormMode.Add:
                        if (await OnSaveAdd()) {
                            IsDirty = true;
                            DialogResult = DialogResult.OK;
                            Close();
                        }
                        break;
                    case BaseConstants.FormMode.Update:
                        if (await OnSaveUpdate()) {
                            IsDirty = true;
                            DialogResult = DialogResult.OK;
                            Close();
                        }
                        break;
                    case BaseConstants.FormMode.ReadOnly:
                        Close();
                        break;

                }
            }
            catch (Exception ex) {
                ShowException(ex);
            }
            finally {
                SetEnable();
            }
        }

       
        private async void btnBaseSaveNew_Click(object sender, EventArgs e) {
            try {
                SetEnable(false);
                switch (FormMode) {
                    case BaseConstants.FormMode.Add:
                        if (await OnSaveAdd()) {
                            IsDirty = true;
                            await OnLoadAdd();
                        }
                        break;

                    case BaseConstants.FormMode.ReadOnly:
                        Close();
                        break;
                }
            }
            catch (Exception ex) {
                ShowException(ex);
            }
            finally {
                SetEnable();
            }
        }

        protected virtual Task OnLoadAdd() {
            throw new NotImplementedException("OnLoadAdd has not been implemented.");
        }
        [Description("Apply save logic here.")]
        protected virtual Task<bool> OnSaveAdd() {
            throw new NotImplementedException("OnSaveAdd has not been implemented.");
        }
        [Description("Apply update logic here.")]
        protected virtual Task<bool> OnSaveUpdate() {
            throw new NotImplementedException("OnSaveUpdate has not been implemented.");
        }
        #region Button State
        protected virtual void SetEnable(bool enable = true) {
            btnBaseSaveClose.Enabled = enable;
            btnBaseSaveNew.Enabled = enable;
        }
        #endregion

    }
}
