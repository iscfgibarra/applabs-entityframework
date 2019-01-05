using AppLabs.EntityFramework.Interfaces;
using AppLabs.EntityFramework.Test.Entities;
using AppLabs.EntityFramework.Test.Mappings;
using AppLabs.EntityFramework.Test.Seedings;
using Microsoft.EntityFrameworkCore;

namespace AppLabs.EntityFramework.Test
{
    public class BitacoraContext : DbContext, IDbContext
    {
        private string _connectionString;
        private bool _databaseOnMemory;

        public BitacoraContext()
        {
            
        }

        public BitacoraContext(DbContextOptions options) : base(options)
        {
            
        }

        public void SetConfiguration(IDataAccessConfiguration configuration)
        {
            _connectionString = configuration.ConnectionString;
            _databaseOnMemory = configuration.DatabaseOnMemory;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (_databaseOnMemory)
            {
                optionsBuilder.UseInMemoryDatabase("DbInMemory");
            }
            else
            {
                if (!optionsBuilder.IsConfigured)
                {

                    optionsBuilder.UseSqlServer(
                        _connectionString, options => options.EnableRetryOnFailure());
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
            
            //if (_databaseOnMemory)
            //{
            //    modelBuilder.Seed();
            //}
        }
    }
}
