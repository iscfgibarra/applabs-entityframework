using AppLabs.EntityFramework.Interfaces;

namespace AppLabs.EntityFramework
{
    public class DbContextConfiguration<TContext> : IDbContextConfiguration<TContext>
        where TContext : IDbContext, new()
    {
        public string ConnectionString { get; set; }
        public bool UseOnMemory { get; set; }
        public bool UseSqlite { get; set; }
        public bool UseSqlServer { get; set; }

        private DataAccessConfiguration _dataAccessConfiguration;

        /// <summary>
        /// Use Sqlite or Database on Memory
        /// </summary>
        /// <param name="connectionString">Connection string only for Sqlite</param>
        /// <param name="useSqlite"></param>
        /// <param name="useOnMemory"></param>
        public DbContextConfiguration(string connectionString, bool useSqlite, bool useOnMemory = false)
        {
            ConnectionString = connectionString;
            UseOnMemory = useOnMemory;
            UseSqlite = useSqlite;
            UseSqlServer = false;
            _dataAccessConfiguration = new DataAccessConfiguration(connectionString, useSqlite, useOnMemory);
        }

        /// <summary>
        /// Use SqlServer Default
        /// </summary>
        /// <param name="connectionString">Connection string for SQL Server</param>
        public DbContextConfiguration(string connectionString)
        {
            ConnectionString = connectionString;
            UseOnMemory = false;
            UseSqlite = false;
            UseSqlServer = true;
            _dataAccessConfiguration = new DataAccessConfiguration(connectionString);
        }


        public IDataAccessConfiguration GetDataAccessConfiguration()
        {
            return _dataAccessConfiguration;
        }
    }
}
