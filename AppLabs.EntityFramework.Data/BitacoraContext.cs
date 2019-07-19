using AppLabs.EntityFramework.Interfaces;
using AppLabs.EntityFramework.Data.Entities;
using AppLabs.EntityFramework.Test.Mappings;
using Microsoft.EntityFrameworkCore;

namespace AppLabs.EntityFramework.Data
{
    public class BitacoraContext : DbContext, IDbContext
    {
        public IDataAccessConfiguration DataAccessConfiguration { get; set; }
        
        public BitacoraContext()
        {
            
        }

        public BitacoraContext(DbContextOptions options) : base(options)
        {
            
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                if (DataAccessConfiguration.UseOnMemory)
                {
                    optionsBuilder.UseInMemoryDatabase("DbInMemory");
                }
                else if (DataAccessConfiguration.UseSqlite)
                {
                    optionsBuilder.UseSqlite(DataAccessConfiguration.ConnectionString);
                }
                else if(DataAccessConfiguration.UseSqlServer)
                {
                    optionsBuilder.UseSqlServer(
                        DataAccessConfiguration.ConnectionString, options => options.EnableRetryOnFailure());
                } else
                {
                    optionsBuilder.UseSqlServer(
                        DataAccessConfiguration.ConnectionString, options => options.EnableRetryOnFailure());
                }
            }
        }

        public DbSet<Etiqueta> Etiquetas { get; set; }

        public DbSet<Entrada> Entradas { get; set; }

        public DbSet<Proyecto> Proyectos { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new ProyectoMapping(modelBuilder.Entity<Proyecto>());
            new EtiquetaMapping(modelBuilder.Entity<Etiqueta>());
            new EntradaMapping(modelBuilder.Entity<Entrada>());          
        }
    }
}
