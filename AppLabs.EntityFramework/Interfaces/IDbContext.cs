using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AppLabs.EntityFramework.Interfaces
{
    public interface IDbContext
    {
        DbSet<T> Set<T>() where T : class;
        EntityEntry<T> Entry<T>(T entity) where T : class;
        IDataAccessConfiguration DataAccessConfiguration { get; set; }
        int SaveChanges();
        void Dispose();
    }
}