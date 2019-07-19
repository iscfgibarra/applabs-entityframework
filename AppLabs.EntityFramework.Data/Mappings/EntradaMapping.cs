using AppLabs.EntityFramework.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppLabs.EntityFramework.Test.Mappings
{
    public class EntradaMapping
    {
        public EntradaMapping(EntityTypeBuilder<Entrada> builder)
        {
            builder.ToTable("Entradas");
            builder.HasKey(e => e.EntradaId);
            builder.Property(p => p.Nombre).HasMaxLength(100).IsRequired(true);
            builder.Property(p => p.Descripcion).HasMaxLength(150);
            builder.Property(p => p.Fecha).HasColumnType("datetime2");

            builder.HasOne(e => e.Proyecto)
                .WithMany(p => p.Entradas)
                .HasForeignKey(e => e.ProyectoId);

            builder.HasOne(e => e.Etiqueta)
                .WithMany(et => et.Entradas)
                .HasForeignKey(e => e.EtiquetaId);

        }
    }
}
