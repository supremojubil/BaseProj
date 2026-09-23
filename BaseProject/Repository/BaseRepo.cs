using System;
using System.Data.Entity;

namespace BaseProject.Repository {
    public class BaseRepo<T> : IDisposable where T : DbContext, new() {
        protected T _ts;
        private bool SingleUse;
        private bool _disposed;

        public BaseRepo() {
            _ts = new T();
            SingleUse = false;
        }
        public BaseRepo(T ts) {
            _ts = ts;
            SingleUse = false;
        }
        public void Dispose() {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing) {
            if (!_disposed && disposing) {
                if (_ts != null && SingleUse) {
                    _ts?.Database?.Connection?.Close();
                    _ts?.Dispose();
                    _ts = null;
                }
                _disposed = true;
            }
        }
    }
}
