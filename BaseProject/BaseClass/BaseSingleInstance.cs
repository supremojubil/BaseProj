using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.BaseClass {
    public class BaseSingleInstance {
        private const int SW_RESTORE = 9;
        #region Windows API
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern bool IsIconic(IntPtr hWnd);
        #endregion

        #region Single Instance
        public static bool IsSingleInstance(bool ShowWarningMessage) {
            Process[] processes = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
            if (processes.Length > 1) {
                return false;
            }
            return true;
        }
        #endregion

        #region Raise Main Window
        public static void RaiseTheMainWindow() {
            Process[] processes = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
            Process currentProcess = Process.GetCurrentProcess();
            foreach (Process process in processes) {
                if (process.Id == currentProcess.Id) {
                    continue;
                }
                IntPtr mainWindowHandle = process.MainWindowHandle;
                if (mainWindowHandle == IntPtr.Zero) {
                    continue;
                }
                if (IsIconic(mainWindowHandle)) {
                    ShowWindowAsync(mainWindowHandle, SW_RESTORE);
                }
                SetForegroundWindow(mainWindowHandle);
                break;
            }
        }
        #endregion
    }
}
