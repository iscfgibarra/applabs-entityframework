
using AppLabs.EntityFramework.Test.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppLabs.EntityFramework.Test.Mappings
{
    public class ProyectoMapping
    {
        public ProyectoMapping(EntityTypeBuilder<Proyecto> builder)
        {
            builder.ToTable("Proyectos");
            builder.HasKey(e => e.ProyectoId);
            builder.Property(p => p.Nombre).HasMaxLength(100).IsRequired(true);
            builder.Property(p => p.Descripcion).HasMaxLength(150);
        }
    }
}
