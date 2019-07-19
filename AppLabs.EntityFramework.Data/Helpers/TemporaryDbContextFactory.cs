using Microsoft.EntityFrameworkCore.Design;

namespace AppLabs.EntityFramework.Data.Helpers
{
    public class TemporaryDbContextFactory : IDesignTimeDbContextFactory<BitacoraContext>
    {
        public BitacoraContext CreateDbContext(string[] args)
        {            
            var bc= new BitacoraContext();
            bc.DataAccessConfiguration = new DataAccessConfiguration("Data Source=E:\\bitacora.db", true);
            return bc;
        }
    }
}
