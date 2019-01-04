using System;

namespace AppLabs.EntityFramework.Interfaces
{
    public interface IDatabaseFactory : IDisposable
    {
        IDbContext Get();       
    }
}
