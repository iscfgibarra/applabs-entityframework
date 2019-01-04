using AppLabs.EntityFramework.Interfaces;

namespace AppLabs.EntityFramework
{
    public class DataAccessConfiguration: IDataAccessConfiguration
    {
        public string ConnectionString { get; set; }
        public bool DatabaseOnMemory { get; set; }

        public DataAccessConfiguration(string connectionString, bool databaseOnMemory)
        {
            ConnectionString = connectionString;
            DatabaseOnMemory = databaseOnMemory;
        }
    }
}
