using Microsoft.EntityFrameworkCore.Design;

namespace AppLabs.EntityFramework.Test.Helpers
{
    public class TemporaryDbContextFactory : IDesignTimeDbContextFactory<BitacoraContext>
    {
        public BitacoraContext CreateDbContext(string[] args)
        {            
            var bc= new BitacoraContext();
            bc.SetConfiguration(new DataAccessConfiguration("Data Source=E:\\bitacora.db", false, true));
            return bc;
        }
    }
}
