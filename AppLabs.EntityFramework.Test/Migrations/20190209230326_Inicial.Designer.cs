﻿// <auto-generated />
using System;
using AppLabs.EntityFramework.Test;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AppLabs.EntityFramework.Test.Migrations
{
    [DbContext(typeof(BitacoraContext))]
    [Migration("20190209230326_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity("AppLabs.EntityFramework.Test.Entities.Entrada", b =>
                {
                    b.Property<int>("EntradaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion")
                        .HasMaxLength(150);

                    b.Property<int>("EtiquetaId");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("ProyectoId");

                    b.HasKey("EntradaId");

                    b.HasIndex("EtiquetaId");

                    b.HasIndex("ProyectoId");

                    b.ToTable("Entradas");
                });

            modelBuilder.Entity("AppLabs.EntityFramework.Test.Entities.Etiqueta", b =>
                {
                    b.Property<int>("EtiquetaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion")
                        .HasMaxLength(150);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("EtiquetaId");

                    b.ToTable("Etiquetas");
                });

            modelBuilder.Entity("AppLabs.EntityFramework.Test.Entities.Proyecto", b =>
                {
                    b.Property<int>("ProyectoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion")
                        .HasMaxLength(150);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("ProyectoId");

                    b.ToTable("Proyectos");
                });

            modelBuilder.Entity("AppLabs.EntityFramework.Test.Entities.Entrada", b =>
                {
                    b.HasOne("AppLabs.EntityFramework.Test.Entities.Etiqueta", "Etiqueta")
                        .WithMany("Entradas")
                        .HasForeignKey("EtiquetaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AppLabs.EntityFramework.Test.Entities.Proyecto", "Proyecto")
                        .WithMany("Entradas")
                        .HasForeignKey("ProyectoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}