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
    public partial class BaseFormListWithSearch : BaseFormListExtended {
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
                    pnlBaseSearch.Visible = value;
                    pnlBaseSearch.Enabled = value;
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
                if (!ShowSearch) {
                    _showSearchDates = false;
                }
                else {
                    _showSearchDates = value;
                }

                if (pnlSearchDate != null) {
                    pnlSearchDate.Visible = _showSearchDates;
                    pnlSearchDate.Enabled = _showSearchDates;
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
        public DateTime DateFrom {
            get {
                return dtpDateFromBase.Value.Date;
            }
        }

        [Browsable(false)]
        public DateTime DateTo {
            get {
                return dtpDateToBase.Value.Date;
            }
        }

        [Browsable(false)]
        public string SearchText {
            get {
                return stxtSearch.Text;
            }
        }
        #endregion

        public BaseFormListWithSearch() {
            InitializeComponent();
        }

        #region Search Events
        private void stxtSearch_TextChanged(object sender, EventArgs e) {
            if (!SearchWithEnterKey) {
                RefreshList();
            }
        }

        private void stxtSearch_KeyDown(object sender, KeyEventArgs e) {
            if (SearchWithEnterKey && e.KeyCode == Keys.Enter) {
                e.SuppressKeyPress = true;
                RefreshList();
            }
        }

        private void dtpDateFromBase_ValueChanged(object sender, EventArgs e) {
            RefreshList();
        }

        private void dtpDateToBase_ValueChanged(object sender, EventArgs e) {
            RefreshList();
        }
        #endregion

    }
}
