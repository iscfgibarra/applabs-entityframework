using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AppLabs.EntityFramework.Interfaces;
using AppLabs.EntityFramework.Paged;
using Microsoft.EntityFrameworkCore;

namespace AppLabs.EntityFramework
{
    public class Repository<T>: IRepository<T> 
        where T : class
    {
        private readonly IDbContext _dataContext;
        private readonly DbSet<T> _dbset;

        public DbSet<T> DbSet => _dbset;

        public Repository(IDatabaseFactory databaseFactory)
        {            
            _dataContext = databaseFactory.Create();
            _dbset = _dataContext.Set<T>();
        }

        public Repository(IDbContext dbContext)
        {
            _dataContext = dbContext;
            _dbset = _dataContext.Set<T>();
        }


        public IDbContext DbContext => _dataContext;

        public virtual void Add(T entity)
        {
            _dbset.Add(entity);
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbset.AddAsync(entity);
            return entity;
        }

        public virtual T Update(T entity)
        {
            _dbset.Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }
        
        public virtual void Delete(T entity)
        {
            _dbset.Remove(entity);
        }
        
        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = _dbset.Where(where).AsEnumerable();
            foreach (T obj in objects)
                _dbset.Remove(obj);
        }

     
        public virtual T GetById(int id)
        {
            return _dbset.Find(id);
        }
        public virtual T GetById(string id)
        {
            return _dbset.Find(id);
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbset.FindAsync(id);
        }

        public virtual async Task<T> GetByIdAsync(string id)
        {
            return await _dbset.FindAsync(id);
        }

        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> @where)
        {
            return await _dbset.Where(where).FirstOrDefaultAsync();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbset.ToList();
        }


        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _dbset.Where(where).ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> @where)
        {
            return await _dbset.Where(where).ToListAsync();
        }

        public PagedResult<T> GetPage(int page, int pageSize)
        {
            return _dbset.GetPaged(page, pageSize);
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return _dbset.Where(where).FirstOrDefault();
        }
    }
}
