using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Controls {
    [DataGridViewColumnDesignTimeVisible(true)]
    public class BaseNumericOnlyColumn : DataGridViewTextBoxColumn {
        #region Fields
        private string myTag;
        #endregion

        #region Properties
        public string MyTag {
            get {
                return myTag;
            }
            set {
                myTag = value;
            }
        }

        public override DataGridViewCell CellTemplate {
            get {
                return base.CellTemplate;
            }
            set {
                if (value != null && !(value is BaseNumericOnlyCell)) {
                    throw new InvalidCastException("Must be a BaseNumericOnlyCell");
                }
                base.CellTemplate = value;
            }
        }
        #endregion

        #region Constructor
        public BaseNumericOnlyColumn() {
            CellTemplate = new BaseNumericOnlyCell();
        }
        #endregion

        #region Clone
        public override object Clone() {
            BaseNumericOnlyColumn obj = base.Clone() as BaseNumericOnlyColumn;
            obj.myTag = myTag;
            return obj;
        }
        #endregion
    }
}
