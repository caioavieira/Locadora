using Locadora.Infrastructure.Contextos;
using System;

namespace Locadora.Infrastructure.Transacoes
{
    public class Transacao : IDisposable
    {
        private readonly LocadoraContext _locadoraContext;

        public Transacao(LocadoraContext locadoraContext)
        {
            _locadoraContext = locadoraContext;
            _locadoraContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            _locadoraContext.SaveChanges();
            
            if (_locadoraContext.Database.CurrentTransaction != null)
                _locadoraContext.Database.CommitTransaction();
        }

        public void Dispose()
        {
            if (_locadoraContext.Database.CurrentTransaction != null)
                _locadoraContext.Database.RollbackTransaction();
        }
    }
}