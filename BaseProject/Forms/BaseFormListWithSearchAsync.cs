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
    public partial class BaseFormListWithSearchAsync : BaseFormListExtendedAsync {
        #region Fields
        private bool _showSearch;
        private bool _showSearchField;
        private bool _showSearchDates;
        private bool _searchWithEnter;
        private bool _manageMode;
        #endregion

        #region Properties
        [Category("BaseProject Search")]
        [Description("Determines whether the search panel is displayed.")]
        [DefaultValue(true)]
        public bool ShowSearch {
            get {
                return _showSearch;
            }
            set {
                _showSearch = value;

                if (pnlBaseSearch != null) {
                    pnlBaseSearch.Enabled = value;
                    pnlBaseSearch.Visible = value;
                }

                if (!value) {
                    ShowSearchDates = false;
                }
            }
        }

        [Category("BaseProject Search")]
        [Description("Determines whether the search field is displayed.")]
        [DefaultValue(true)]
        public bool ShowSearchField {
            get {
                return _showSearchField;
            }
            set {
                _showSearchField = value;

                if (lblBaseSearch != null) {
                    lblBaseSearch.Visible = value;
                }

                if (stxtSearch != null) {
                    stxtSearch.Visible = value;
                }
            }
        }

        [Category("BaseProject Search")]
        [Description("Determines whether the date range search is displayed.")]
        [DefaultValue(true)]
        public bool ShowSearchDates {
            get {
                return _showSearchDates;
            }
            set {
                if (ShowSearch) {
                    _showSearchDates = value;
                }
                else {
                    _showSearchDates = false;
                }

                if (pnlSearchDate != null) {
                    pnlSearchDate.Enabled = _showSearchDates;
                    pnlSearchDate.Visible = _showSearchDates;
                }
            }
        }

        [Category("BaseProject Search")]
        [Description("Determines whether the search is performed when the Enter key is pressed.")]
        [DefaultValue(false)]
        public bool SearchWithEnterKey {
            get {
                return _searchWithEnter;
            }
            set {
                _searchWithEnter = value;
            }
        }

        [Browsable(false)]
        public bool ManageMode {
            get {
                return _manageMode;
            }
            set {
                _manageMode = value;

                if (btnUseItem != null) {
                    btnUseItem.Enabled = !value;
                    btnUseItem.Visible = !value;
                }

                if (pnlBaseToolStrip != null) {
                    pnlBaseToolStrip.Enabled = value;
                    pnlBaseToolStrip.Visible = value;
                }
            }
        }

        [Browsable(false)]
        protected DateTime DateFrom {
            get {
                return dtpDateFromBase.Value.Date;
            }
        }

        [Browsable(false)]
        protected DateTime DateTo {
            get {
                return dtpDateToBase.Value.Date;
            }
        }

        [Browsable(false)]
        protected string SearchTextBoxValue {
            get {
                return stxtSearch.Text;
            }
        }
        #endregion
        public BaseFormListWithSearchAsync() {
            InitializeComponent();
        }

        private async void stxtSearch_TextChanged(object sender, EventArgs e) {
            if (!SearchWithEnterKey) {
                try {
                    await RefreshListAsync();
                }
                catch (Exception ex) {
                    ShowException(ex);
                }
            }
        }

        private async void dtpDateFromBase_ValueChanged(object sender, EventArgs e) {
            try {
                await RefreshListAsync();
            }
            catch (Exception ex) {
                ShowException(ex);
            }
        }

        private async void dtpDateToBase_ValueChanged(object sender, EventArgs e) {
            try {
                await RefreshListAsync();
            }
            catch (Exception ex) {
                ShowException(ex);
            }
        }

        private void btnUseItem_Click(object sender, EventArgs e) {
            UseItem();
        }
        
        private async void stxtSearch_KeyDown(object sender, KeyEventArgs e) {
            if (SearchWithEnterKey && e.KeyCode == Keys.Enter) {
                e.SuppressKeyPress = true;
                try {
                    await RefreshListAsync();
                }
                catch (Exception ex) {
                    ShowException(ex);
                }
            }
        }
        protected virtual void UseItem() {
            throw new NotImplementedException("UseItem has not been implemented.");
        }
    }
}
