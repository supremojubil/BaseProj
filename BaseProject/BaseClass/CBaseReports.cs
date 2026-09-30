using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.BaseClass {
    public class CBaseReports {
        #region Constants

        public const string RPT_CRIT_ALL = "ALL";

        #endregion

        #region Date Range

        public static string GetDateRange(DateTime dateFrom, DateTime dateTo) {
            return "From " + dateFrom.ToShortDateString() + " To " + dateTo.ToShortDateString();
        }

        #endregion

        #region Paper Size

        public int GetPaperSizeIndex(string paperName) {
            PrintDocument printDocument = new PrintDocument();

            for (int i = 0; i < printDocument.PrinterSettings.PaperSizes.Count; i++) {
                if (printDocument.PrinterSettings.PaperSizes[i].PaperName.Equals(paperName)) {
                    return i;
                }
            }

            return -1;
        }

        public void LoadPaperSize(ComboBox comboBox) {
            comboBox.Items.Clear();
            PrintDocument printDocument = new PrintDocument();

            for (int i = 0; i < printDocument.PrinterSettings.PaperSizes.Count; i++) {
                comboBox.Items.Add(printDocument.PrinterSettings.PaperSizes[i].PaperName);
            }
        }

        #endregion
    }
}
