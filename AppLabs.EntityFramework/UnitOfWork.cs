using System;
using System.Collections.Generic;
using System.Linq;
using AppLabs.EntityFramework.Interfaces;

namespace AppLabs.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {        
        private readonly IDbContext _dataContext;
        private readonly IDatabaseFactory _databaseFactory;
        private readonly Dictionary<Type, object> _repositories;

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
            _dataContext = _databaseFactory.Get();
            _repositories = new Dictionary<Type, object>();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories.Keys.Contains(typeof(TEntity)))
            {
                return _repositories[typeof(TEntity)] as IRepository<TEntity>;
            }

            var repository = new Repository<TEntity>(_databaseFactory);
            _repositories.Add(typeof(TEntity), repository);

            return repository;
        }

        public int Save()
        {
            return _dataContext.SaveChanges();
        }
    }
}
