namespace BaseProject.BaseClass {
    public class CBaseMessages {
        public const string MSGQUESTION = "QUESTION";

        public const string MSGSTOP = "STOP";

        public const string MSGWARNING = "WARNING";

        public const string MSGINFO = "INFO";

        #region Message Box
        public static void ShowMessage(string mainTitle, string mainMessage, string heading, string icon) {
            MessageBoxIcon messageBoxIcon = MessageBoxIcon.Information;
            switch (icon) {
                case MSGQUESTION:
                    messageBoxIcon = MessageBoxIcon.Question;
                    break;
                case MSGSTOP:
                    messageBoxIcon = MessageBoxIcon.Error;
                    break;
                case MSGWARNING:
                    messageBoxIcon = MessageBoxIcon.Warning;
                    break;
                case MSGINFO:
                    messageBoxIcon = MessageBoxIcon.Information;
                    break;
            }
            MessageBox.Show(mainMessage, $"{heading}\n{mainTitle}", MessageBoxButtons.OK, messageBoxIcon);
        }
        #endregion

        #region Ask Message
        public static bool AskMessage(string message, string caption) {
            return MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
        #endregion

        #region Error Message
        public static void ErrorMessage(string message, string caption) {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        
        }
        #endregion

        #region Warning Message
        public static void WarningMessage(string message, string caption) {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion
    }
}
