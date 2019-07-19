using AppLabs.EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppLabs.EntityFramework
{
    public class DataAccessConfiguration: IDataAccessConfiguration
    {
        public string ConnectionString { get; set; }
        public bool UseOnMemory { get; set; }
        public bool UseSqlite { get; set; }
        public bool UseSqlServer { get; set; }

       /// <summary>
       /// Use Sqlite or Database on Memory
       /// </summary>
       /// <param name="connectionString">Connection string only for Sqlite</param>
       /// <param name="useSqlite"></param>
       /// <param name="useOnMemory"></param>
        public DataAccessConfiguration(string connectionString,  bool useSqlite, bool useOnMemory = false)
        {
            ConnectionString = connectionString;
            UseOnMemory = useOnMemory;
            UseSqlite = useSqlite;
            UseSqlServer = false;
        }

        /// <summary>
        /// Use SqlServer Default
        /// </summary>
        /// <param name="connectionString">Connection string for SQL Server</param>
        public DataAccessConfiguration(string connectionString)
        {
            ConnectionString = connectionString;
            UseOnMemory = false;
            UseSqlite = false;
            UseSqlServer = true;
        }        
    }
}
