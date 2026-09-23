using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.BaseClass {
    public class BaseConstants {
        public enum FormMode {
            Add,
            Update,
            ReadOnly
        }
        public const string ACTIVE_STATUS = "ACTIVE";
        public const string INACTIVE_STATUS = "IN-ACTIVE";
        public const string YES = "YES";
        public const string NO = "NO";
        public static string USERNAME { get; set; }
        public static string ACCESS { get; set; }
    }
}
