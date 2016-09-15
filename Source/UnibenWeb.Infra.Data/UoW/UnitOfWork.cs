using System;
using Microsoft.Practices.ServiceLocation;
using UnibenWeb.Infra.CrossCutting.Audit.Context;
using UnibenWeb.Infra.Data.Context;
using UnibenWeb.Infra.Data.Interfaces;

namespace UnibenWeb.Infra.Data.UoW
{
    public class UnitOfWork: IUnitOfWork
    {

        private readonly UnibenContext _context;
        private readonly FirebirdContext _fbContext;
        private readonly UnibenLogContext _logContext;
        private readonly ContextManager _contextManager = ServiceLocator.Current.GetInstance<IContextManager>() as ContextManager;

        private bool _disposed;

        public UnitOfWork()
        {
            _context = _contextManager.GetContext();
            _fbContext = _contextManager.GetFbContext();
            _logContext = _contextManager.GetContextLog();
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void SaveChanges(bool doLog, string userId)
        {
            // Detecta as alterações existentes na instância corrente do DbContext.
            if (doLog)
            {
                _context.ChangeTracker.DetectChanges();
                _logContext.DoChanges(_context.ChangeTracker.Entries(), userId);
            }
            _context.SaveChanges();
            if (doLog)
            {
                _logContext.SaveChanges();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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