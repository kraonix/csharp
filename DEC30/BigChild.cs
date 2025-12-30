using System;
using System.Collections;
namespace ExtentionMethodDemo
{
    // A class that implements IDisposable to manage resources      
    public class BigMan : IDisposable
    {
        private bool _disposed;
        public ArrayList Names { get; set; }
        public BigMan()
        {
            Names = new ArrayList();
        }
                public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        // dispose pattern implementation
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }
            if (disposing)
            {
                if (Names != null)
                {
                    Names.Clear();
                    Names = null;
                }
            }
            _disposed = true;
        }
    }
}