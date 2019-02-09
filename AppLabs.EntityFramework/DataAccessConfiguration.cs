using AppLabs.EntityFramework.Interfaces;

namespace AppLabs.EntityFramework
{
    public class DataAccessConfiguration: IDataAccessConfiguration
    {
        public string ConnectionString { get; set; }
        public bool DatabaseOnMemory { get; set; }
        
        public bool UseSqlite { get; set; }

        public DataAccessConfiguration(string connectionString, bool databaseOnMemory, bool useSqlite)
        {
            ConnectionString = connectionString;
            DatabaseOnMemory = databaseOnMemory;
            UseSqlite = useSqlite;
        }
    }
}
