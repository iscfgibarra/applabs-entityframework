using System;
using System.Collections.Generic;
using System.Text;
using AppLabs.EntityFramework.Test.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppLabs.EntityFramework.Test.Mappings
{
    public class EtiquetaMapping
    {
        public EtiquetaMapping(EntityTypeBuilder<Etiqueta> builder)
        {
            builder.ToTable("Etiquetas");
            builder.HasKey(e => e.EtiquetaId);
            builder.Property(p => p.Nombre).HasMaxLength(100).IsRequired(true);
            builder.Property(p => p.Descripcion).HasMaxLength(150);
        }
    }
}
