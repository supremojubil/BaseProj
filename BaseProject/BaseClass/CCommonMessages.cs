using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.BaseClass {
    public class CCommonMessages {
        public void FormModeNotSupported(Form form) {
            CBaseMessages.ShowMessage("Mode Not Supported.", "Form Mode Not Supported.\nThis window will now close.", "Warning", CBaseMessages.MSGWARNING);
            form.Close();
        }
        public void MessageErrorConnection() {
            CBaseMessages.ShowMessage("Connection error", "Something is wrong with the connection.\nPlease check server status.", "Error", CBaseMessages.MSGSTOP);
        }
    
    }
}
