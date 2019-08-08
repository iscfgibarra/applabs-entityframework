using AppLabs.EntityFramework.Interfaces;
using System;

namespace AppLabs.EntityFramework
{
    public class DatabaseFactory<TContext> : Disposable, IDatabaseFactory 
        where TContext : IDbContext, new()
    {
        private IDbContext _dataContext;
        
        private readonly IDataAccessConfiguration _dataAccessConfiguration;

        public DatabaseFactory(IDataAccessConfiguration dataAccessConfiguration)
        {
            _dataAccessConfiguration = dataAccessConfiguration;
        }

        [Obsolete("Get is deprecated, please use Create instead.")]
        public IDbContext Get()
        {
            if (_dataContext != null) return _dataContext;
            
            _dataContext = new TContext();
            _dataContext.DataAccessConfiguration = _dataAccessConfiguration;

            return _dataContext;
        }

        public IDbContext Create()
        {
            if (_dataContext != null) return _dataContext;

            _dataContext = new TContext();
            _dataContext.DataAccessConfiguration = _dataAccessConfiguration;

            return _dataContext;
        }

        protected override void DisposeCore()
        {
            _dataContext?.Dispose();
        }
    }
}
