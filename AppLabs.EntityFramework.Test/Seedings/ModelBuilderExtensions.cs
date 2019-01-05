using System;
using AppLabs.EntityFramework.Test.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppLabs.EntityFramework.Test.Seedings
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proyecto>().HasData(
                new Proyecto
                {
                    ProyectoId = 1,
                    Nombre = "Estudiar Estadistica",
                    Descripcion = "Terminar el curso básico"
                },
                new Proyecto 
                {
                    ProyectoId = 2,
                    Nombre = "Estudiar Oratoria",
                    Descripcion = "Terminar Oratoria"
                }
             );

            modelBuilder.Entity<Etiqueta>().HasData(
                new Etiqueta
                {
                    EtiquetaId = 1,
                    Nombre = "Compra",
                    Descripcion = "Comprar un recurso"
                },
                new Etiqueta
                {
                    EtiquetaId = 2,
                    Nombre = "Estudiar",
                    Descripcion = "Estudiar un recurso"
                },
                new Etiqueta
                {
                    EtiquetaId = 3,
                    Nombre = "Certificación",
                    Descripcion = "Presentar examén de certificación"
                }
            );

           
            
        }
    }
}
