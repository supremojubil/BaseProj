using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Controls {
    [DataGridViewColumnDesignTimeVisible(true)]
    public class BaseDataGridViewTextBoxColumn : DataGridViewTextBoxColumn {
        private string myTag;
        public string MyTag {
            get {
                return myTag;
            }
            set {
                myTag = value;
            }
        }

        public override object Clone() {
            BaseDataGridViewTextBoxColumn obj = base.Clone() as BaseDataGridViewTextBoxColumn;
            obj.myTag = myTag;
            return obj;
        }
    }
}
