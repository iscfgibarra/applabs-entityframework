namespace AppLabs.EntityFramework.Interfaces
{
    public interface IUnitOfWork<TContext> 
        where TContext : IDbContext, new()
    {
        IDbContext DbContext { get; }
        IRepository<TEntity> GetRepository<TEntity>() where TEntity: class;
        int Save();
    }
}

