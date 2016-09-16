using System;
using Microsoft.Practices.ServiceLocation;
using UnibenWeb.Infra.Data.Context;
using UnibenWeb.Infra.Data.Interfaces;

namespace UnibenWeb.Infra.Data.UoW
{
    class FirebirdUnitOfWork : IUnitOfWork
    {
        private readonly FirebirdContext _fbContext;
        private readonly ContextManager _contextManager = ServiceLocator.Current.GetInstance<IContextManager>() as ContextManager;
        private bool _disposed;

        public FirebirdUnitOfWork()
        {
            _fbContext = _contextManager.GetFbContext();
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void SaveChanges(bool doLog, string userId)
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _fbContext.Dispose();
                }
            }
            _disposed = true;
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
