namespace AppLabs.EntityFramework.Interfaces
{
    public interface IUnitOfWork<TContext> 
        where TContext : IDbContext, new()
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity: class;
        int Save();
    }
}

