﻿// <auto-generated />
using System;
using ESFE_AGAPE_BODEGA.API.Models.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ESFE_AGAPE_BODEGA.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240919041644_migration1")]
    partial class migration1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.33")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Bodega_Api_Esfe_Agape.Models.EN.Activo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodigoBarra")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstanteId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoActivoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoActivoId")
                        .IsUnique();

                    b.ToTable("activos");
                });

            modelBuilder.Entity("Bodega_Api_Esfe_Agape.Models.EN.DetalleIngresoActivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("IngresoActivoId")
                        .HasColumnType("int");

                    b.Property<int>("InventarioActivoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IngresoActivoId");

                    b.ToTable("detalleIngresos");
                });

            modelBuilder.Entity("Bodega_Api_Esfe_Agape.Models.EN.IngresoActivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Correlativo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("datetime2");

                    b.Property<string>("NumeroDocRelacionado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ingresoactivos");
                });

            modelBuilder.Entity("ESFE_AGAPE_BODEGA.API.Models.Entitys.Bodega", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("bodegas");
                });

            modelBuilder.Entity("ESFE_AGAPE_BODEGA.API.Models.Entitys.Estante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BodegaId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BodegaId");

                    b.ToTable("estantes");
                });

            modelBuilder.Entity("ESFE_AGAPE_BODEGA.API.Models.Entitys.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("ESFE_AGAPE_BODEGA.API.Models.Entitys.TipoActivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tipoActivos");
                });

            modelBuilder.Entity("ESFE_AGAPE_BODEGA.API.Models.Entitys.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DUI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RolId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Bodega_Api_Esfe_Agape.Models.EN.Activo", b =>
                {
                    b.HasOne("ESFE_AGAPE_BODEGA.API.Models.Entitys.TipoActivo", null)
                        .WithOne("activo")
                        .HasForeignKey("Bodega_Api_Esfe_Agape.Models.EN.Activo", "TipoActivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bodega_Api_Esfe_Agape.Models.EN.DetalleIngresoActivo", b =>
                {
                    b.HasOne("Bodega_Api_Esfe_Agape.Models.EN.IngresoActivo", "ingresoActivo")
                        .WithMany()
                        .HasForeignKey("IngresoActivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ingresoActivo");
                });

            modelBuilder.Entity("ESFE_AGAPE_BODEGA.API.Models.Entitys.Estante", b =>
                {
                    b.HasOne("ESFE_AGAPE_BODEGA.API.Models.Entitys.Bodega", "Bodega")
                        .WithMany()
                        .HasForeignKey("BodegaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bodega");
                });

            modelBuilder.Entity("ESFE_AGAPE_BODEGA.API.Models.Entitys.Usuario", b =>
                {
                    b.HasOne("ESFE_AGAPE_BODEGA.API.Models.Entitys.Rol", "Rol")
                        .WithMany("Usuarios")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("ESFE_AGAPE_BODEGA.API.Models.Entitys.Rol", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("ESFE_AGAPE_BODEGA.API.Models.Entitys.TipoActivo", b =>
                {
                    b.Navigation("activo")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
