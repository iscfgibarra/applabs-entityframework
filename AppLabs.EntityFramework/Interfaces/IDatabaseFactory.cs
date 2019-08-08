using System;

namespace AppLabs.EntityFramework.Interfaces
{
    public interface IDatabaseFactory : IDisposable
    {
        [Obsolete("Get is deprecated, please use Create instead.")]
        IDbContext Get();

        IDbContext Create();
    }
}
