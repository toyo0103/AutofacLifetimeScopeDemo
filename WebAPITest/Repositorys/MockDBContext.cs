using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPITest.Repositorys
{
    public class MockDBContext : IDisposable
    {
        private bool disposed = false;

        private Guid _id;
        public MockDBContext()
        {
            this._id = Guid.NewGuid();
        }

        public Guid GetID()
        {
            return this._id;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    // Free other state (managed objects).
                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~MockDBContext()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }
    }
}