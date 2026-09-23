using BaseProject.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Infrastructure {
    public class CancellationInfo {
        public string Username;
        public string UserLevel;
        public string Remarks;
        public static CancellationInfo Create(string remarks) {
            return new CancellationInfo {
                Username = BaseConstants.USERNAME,
                UserLevel = BaseConstants.ACCESS,
                Remarks = remarks
            };
        }
        public CancellationInfo(string username, string userLevel, string remarks) {
            Username = username;
            UserLevel = userLevel;
            Remarks = remarks;
        }
        private CancellationInfo() { 
        
        }
    }
}
