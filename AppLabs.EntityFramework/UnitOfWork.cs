using System;
using System.Collections.Generic;
using System.Linq;
using AppLabs.EntityFramework.Interfaces;

namespace AppLabs.EntityFramework
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>
        where TContext : IDbContext, new()
    {        
        private readonly IDbContext _dataContext;       
        private readonly Dictionary<Type, object> _repositories;

        public IDbContext DbContext => _dataContext;



        public UnitOfWork(IDbContextConfiguration<TContext> dbContextConfiguration)
        {
            _dataContext = new TContext();
            _dataContext.DataAccessConfiguration = dbContextConfiguration.GetDataAccessConfiguration();
            _repositories = new Dictionary<Type, object>();
        }


        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories.Keys.Contains(typeof(TEntity)))
            {
                return _repositories[typeof(TEntity)] as IRepository<TEntity>;
            }

            var repository = new Repository<TEntity>(_dataContext);
            _repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        public int Save()
        {
            return _dataContext.SaveChanges();
        }
    }
}
