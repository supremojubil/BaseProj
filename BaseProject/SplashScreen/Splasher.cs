using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.SplashScreen {
    public static class Splasher {
        #region Fields
        private static BaseSplashScreen _splashForm;
        private static Thread _splashThread;
        private static readonly object _syncLock = new object();
        #endregion
        #region Properties

        public static string Status {
            get {
                if (_splashForm == null) {
                    throw new InvalidOperationException("Splash screen is not currently displayed.");
                }

                return _splashForm.StatusInfo;
            }
            set {
                if (_splashForm != null) {
                    _splashForm.StatusInfo = value;
                }
            }
        }

        public static string BuildNo {
            get {
                if (_splashForm == null) {
                    throw new InvalidOperationException("Splash screen is not currently displayed.");
                }
                return _splashForm.BuildInfo;
            }
            set {
                if (_splashForm != null) {
                    _splashForm.BuildInfo = value;
                }
            }
        }

        #endregion

        #region Show

        public static void Show() {
            lock (_syncLock) {
                if (_splashThread != null) {
                    return;
                }

                _splashThread = new Thread(ShowThread) {
                        IsBackground = true
                    };

                _splashThread.SetApartmentState(ApartmentState.STA);
                _splashThread.Start();
            }
        }
        #endregion

        #region Show Thread
        private static void ShowThread() {
            _splashForm = new BaseSplashScreen();
            Application.Run(_splashForm);
        }
        #endregion

        #region Close

        public static void Close() {
            lock (_syncLock) {
                if (_splashForm == null) {
                    return;
                }

                try {
                    if (_splashForm.IsHandleCreated) {
                        _splashForm.BeginInvoke(new MethodInvoker(_splashForm.Close));
                    }
                }
                catch {
                    // Splash screen is already closing.
                }

                _splashForm = null;
                _splashThread = null;
            }
        }
        #endregion
    }
}
