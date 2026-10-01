using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Controls {
    public class BaseNumericOnlyCell : DataGridViewTextBoxCell {
        #region Edit Control
        public override Type EditType {
            get {
                return typeof(BaseNumericOnlyEditingControl);
            }
        }
        #endregion

        #region Value Type
        public override Type ValueType {
            get {
                return typeof(double);
            }
        }
        #endregion

        #region Default New Row Value
        public override object DefaultNewRowValue {
            get {
                return 0;
            }
        }
        #endregion
    }
}
