using System;
using System.Collections.Generic;
using System.Text;

namespace AppLabs.EntityFramework.Interfaces
{
    public interface IDbContextConfiguration<TContext> : IDataAccessConfiguration
        where TContext : IDbContext, new()
    {
        IDataAccessConfiguration GetDataAccessConfiguration();
    }
}
