namespace AppLabs.EntityFramework.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity: class;
        int Save();
    }
}

