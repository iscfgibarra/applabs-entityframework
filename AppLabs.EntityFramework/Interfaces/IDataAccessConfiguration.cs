namespace AppLabs.EntityFramework.Interfaces
{
    public interface IDataAccessConfiguration
    {
        string ConnectionString { get; set; }
        bool UseOnMemory { get; set; }
        bool UseSqlite { get; set; }
        bool UseSqlServer { get; set; }        
    }
}
