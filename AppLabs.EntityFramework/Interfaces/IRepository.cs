using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AppLabs.EntityFramework.Paged;

namespace AppLabs.EntityFramework.Interfaces
{
    public interface IRepository<T>
        where T : class
    {
        void Add(T entity);

        Task<T> AddAsync(T entity);

        T Update(T entity);

        void Delete(T entity);
        
        void Delete(Expression<Func<T, bool>> where);
        
        T GetById(int id);

        T GetById(string id);
        
        T Get(Expression<Func<T, bool>> where);
        
        IEnumerable<T> GetAll();
        
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);

        Task<T> GetAsync(Expression<Func<T, bool>> where);

        Task<T> GetByIdAsync(int id);
        
        Task<T> GetByIdAsync(string id);

        Task<IEnumerable<T>> GetAllAsync();
        
        Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> where);

        PagedResult<T> GetPage(int page, int numberOfRows);
    }
}
