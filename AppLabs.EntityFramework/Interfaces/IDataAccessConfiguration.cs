namespace AppLabs.EntityFramework.Interfaces
{
    public interface IDataAccessConfiguration
    {
        string ConnectionString { get; set; }
        bool DatabaseOnMemory { get; set; }
    }
}
