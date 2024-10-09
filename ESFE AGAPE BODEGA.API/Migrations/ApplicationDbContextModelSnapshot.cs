﻿// <auto-generated />
using System;
using ESFE_AGAPE_BODEGA.API.Models.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ESFE_AGAPE_BODEGA.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.33")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AjusteInventarioInventarioActivo", b =>
                {
                    b.Property<int>("AjuesteInventariosId")
                        .HasColumnType("int");

                    b.Property<int>("InventarioActivosId")
                        .HasColumnType("int");

                    b.HasKey("AjuesteInventariosId", "InventarioActivosId");

                    b.HasIndex("InventarioActivosId");

                    b.ToTable("AjusteInventarioInventarioActivo");
                });

            modelBuilder.Entity("Bodega_Api_Esfe_Agape.Models.EN.Activo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Codigo")
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

                    b.HasIndex("EstanteId");

                    b.HasIndex("TipoActivoId");

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

                    b.HasIndex("InventarioActivoId");

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

                    b.HasIndex("UsuarioId");

                    b.ToTable("ingresoactivos");
                });

            modelBuilder.Entity("ESFE_AGAPE_BODEGA.API.Models.Entitys.AjusteInventario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Correlativo")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("datetime2");

                    b.Property<int>("TipoMantenimiento")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("ajusteInventarios");
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

            modelBuilder.Entity("ESFE_AGAPE_BODEGA.API.Models.Entitys.DetallePaqueteActivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ActivoId")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("PaqueteActivoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ActivoId");

                    b.HasIndex("PaqueteActivoId");

                    b.ToTable("detallePaqueteActivos");
                });

            modelBuilder.Entity("ESFE_AGAPE_BODEGA.API.Models.Entitys.DetalleSolicitudActivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ActivoId")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("PaqueteActivoId")
                        .HasColumnType("int");

                    b.Property<int>("SolicitudActivoId")
                        .HasColumnType("int");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("ActivoId");

                    b.HasIndex("PaqueteActivoId");

                    b.HasIndex("SolicitudActivoId");

                    b.ToTable("detalleSolicitudActivos");
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

            modelBuilder.Entity("ESFE_AGAPE_BODEGA.API.Models.Entitys.InventarioActivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ActivoId")
                        .HasColumnType("int");

                    b.Property<int>("EstanteId")
                        .HasColumnType("int");

                    b.Property<int>("Existencia")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ActivoId");

                    b.HasIndex("EstanteId");

                    b.ToTable("inventarioActivos");
                });

            modelBuilder.Entity("ESFE_AGAPE_BODEGA.API.Models.Entitys.KardexActivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaMovimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("InventarioActivoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Saldo")
                        .HasColumnType("datetime2");

                    b.Property<byte>("TipoMovimiento")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("InventarioActivoId");

                    b.ToTable("kardexActivos");
                });

            modelBuilder.Entity("ESFE_AGAPE_BODEGA.API.Models.Entitys.PaqueteActivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Correlativo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("paqueteActivos");
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

            modelBuilder.Entity("ESFE_AGAPE_BODEGA.API.Models.Entitys.SolicitudActivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correlativo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaEntrega")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaEntregaEsperada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaRecepcion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaRecepcionEsperada")
                        .HasColumnType("datetime2");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioIdBodegueroEntregaId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioIdBodegueroRecibeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.HasIndex("UsuarioIdBodegueroEntregaId");

                    b.HasIndex("UsuarioIdBodegueroRecibeId");

                    b.ToTable("solicitudActivos");
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

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("AjusteInventarioInventarioActivo", b =>
                {
                    b.HasOne("ESFE_AGAPE_BODEGA.API.Models.Entitys.AjusteInventario", null)
                        .WithMany()
                        .HasForeignKey("AjuesteInventariosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ESFE_AGAPE_BODEGA.API.Models.Entitys.InventarioActivo", null)
                        .WithMany()
                        .HasForeignKey("InventarioActivosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bodega_Api_Esfe_Agape.Models.EN.Activo", b =>
                {
                    b.HasOne("ESFE_AGAPE_BODEGA.API.Models.Entitys.Estante", "estante")
                        .WithMany("Activos")
                        .HasForeignKey("EstanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ESFE_AGAPE_BODEGA.API.Models.Entitys.TipoActivo", "tipoactivo")
                        .WithMany("activo")
                        .HasForeignKey("TipoActivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("estante");

                    b.Navigation("tipoactivo");
                });

            modelBuilder.Entity("Bodega_Api_Esfe_Agape.Models.EN.DetalleIngresoActivo", b =>
                {
                    b.HasOne("Bodega_Api_Esfe_Agape.Models.EN.IngresoActivo", "ingresoActivo")
                        .WithMany("DetalleIngresoActivos")
                        .HasForeignKey("IngresoActivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ESFE_AGAPE_BODEGA.API.Models.Entitys.InventarioActivo", "inventarioActivo")
                        .WithMany("DetalleIngresoActivos")
                        .HasForeignKey("InventarioActivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ingresoActivo");

                    b.Navigation("inventarioActivo");
                });

            modelBuilder.Entity("Bodega_Api_Esfe_Agape.Models.EN.IngresoActivo", b =>
                {
                    b.HasOne("ESFE_AGAPE_BODEGA.API.Models.Entitys.Usuario", "usuario")
                        .WithMany("IngresoActivos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("ESFE_AGAPE_BODEGA.API.Models.Entitys.AjusteInventario", b =>
                {
                    b.HasOne("ESFE_AGAPE_BODEGA.API.Models.Entitys.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ESFE_AGAPE_BODEGA.API.Models.Entitys.DetallePaqueteActivo", b =>
                {
                    b.HasOne("Bodega_Api_Esfe_Agape.Models.EN.Activo", "Activo")
                        .WithMany("detallePaqueteActivos")
                        .HasForeignKey("ActivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ESFE_AGAPE_BODEGA.API.Models.Entitys.PaqueteActivo", "PaqueteActivo")
                        .WithMany("DetallePaqueteActivos")
                        .HasForeignKey("PaqueteActivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activo");

                    b.Navigation("PaqueteActivo");
                });

            modelBuilder.Entity("ESFE_AGAPE_BODEGA.API.Models.Entitys.DetalleSolicitudActivo", b =>
                {
                    b.HasOne("Bodega_Api_Esfe_Agape.Models.EN.Activo", "Activo")
                        .WithMany("detalleSolicitudActivos")
                        .HasForeignKey("ActivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ESFE_AGAPE_BODEGA.API.Models.Entitys.PaqueteActivo", "PaqueteActivo")
                        .WithMany("DetalleSolicitudActivos")
                        .HasForeignKey("PaqueteActivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ESFE_AGAPE_BODEGA.API.Models.Entitys.SolicitudActivo", "SolicitudActivo")
                        .WithMany("DetalleSolicitudActivos")
                        .HasForeignKey("SolicitudActivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activo");

                    b.Navigation("PaqueteActivo");

                    b.Navigation("SolicitudActivo");
                });

            modelBuilder.Entity("ESFE_AGAPE_BODEGA.API.Models.Entitys.Estante", b =>
                {
                    b.HasOne("ESFE_AGAPE_BODEGA.API.Models.Entitys.Bodega", "Bodega")
                        .WithMany("estante")
                        .HasForeignKey("BodegaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bodega");
                });

            modelBuilder.Entity("ESFE_AGAPE_BODEGA.API.Models.Entitys.InventarioActivo", b =>
                {
                    b.HasOne("Bodega_Api_Esfe_Agape.Models.EN.Activo", "Activo")
                        .WithMany("InventarioActivos")
                        .HasForeignKey("ActivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ESFE_AGAPE_BODEGA.API.Models.Entitys.Estante", "Estante")
                        .WithMany("InventarioActivos")
                        .HasForeignKey("EstanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activo");

                    b.Navigation("Estante");
                });

            modelBuilder.Entity("ESFE_AGAPE_BODEGA.API.Models.Entitys.KardexActivo", b =>
                {
                    b.HasOne("ESFE_AGAPE_BODEGA.API.Models.Entitys.InventarioActivo", "InventarioActivo")
                        .WithMany()
                        .HasForeignKey("InventarioActivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InventarioActivo");
                });

            modelBuilder.Entity("ESFE_AGAPE_BODEGA.API.Models.Entitys.SolicitudActivo", b =>
                {
                    b.HasOne("ESFE_AGAPE_BODEGA.API.Models.Entitys.Usuario", "Usuario")
                        .WithMany("SolicitudActivos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ESFE_AGAPE_BODEGA.API.Models.Entitys.Usuario", "UsuarioBodegueroEntrega")
                        .WithMany("BodegasEntregaSolicitudes")
                        .HasForeignKey("UsuarioIdBodegueroEntregaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ESFE_AGAPE_BODEGA.API.Models.Entitys.Usuario", "UsuarioBodegueroRecibe")
                        .WithMany("BodegaRecibeSolicitudes")
                        .HasForeignKey("UsuarioIdBodegueroRecibeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Usuario");

                    b.Navigation("UsuarioBodegueroEntrega");

                    b.Navigation("UsuarioBodegueroRecibe");
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

            modelBuilder.Entity("Bodega_Api_Esfe_Agape.Models.EN.Activo", b =>
                {
                    b.Navigation("InventarioActivos");

                    b.Navigation("detallePaqueteActivos");

                    b.Navigation("detalleSolicitudActivos");
                });

            modelBuilder.Entity("Bodega_Api_Esfe_Agape.Models.EN.IngresoActivo", b =>
                {
                    b.Navigation("DetalleIngresoActivos");
                });

            modelBuilder.Entity("ESFE_AGAPE_BODEGA.API.Models.Entitys.Bodega", b =>
                {
                    b.Navigation("estante");
                });

            modelBuilder.Entity("ESFE_AGAPE_BODEGA.API.Models.Entitys.Estante", b =>
                {
                    b.Navigation("Activos");

                    b.Navigation("InventarioActivos");
                });

            modelBuilder.Entity("ESFE_AGAPE_BODEGA.API.Models.Entitys.InventarioActivo", b =>
                {
                    b.Navigation("DetalleIngresoActivos");
                });

            modelBuilder.Entity("ESFE_AGAPE_BODEGA.API.Models.Entitys.PaqueteActivo", b =>
                {
                    b.Navigation("DetallePaqueteActivos");

                    b.Navigation("DetalleSolicitudActivos");
                });

            modelBuilder.Entity("ESFE_AGAPE_BODEGA.API.Models.Entitys.Rol", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("ESFE_AGAPE_BODEGA.API.Models.Entitys.SolicitudActivo", b =>
                {
                    b.Navigation("DetalleSolicitudActivos");
                });

            modelBuilder.Entity("ESFE_AGAPE_BODEGA.API.Models.Entitys.TipoActivo", b =>
                {
                    b.Navigation("activo");
                });

            modelBuilder.Entity("ESFE_AGAPE_BODEGA.API.Models.Entitys.Usuario", b =>
                {
                    b.Navigation("BodegaRecibeSolicitudes");

                    b.Navigation("BodegasEntregaSolicitudes");

                    b.Navigation("IngresoActivos");

                    b.Navigation("SolicitudActivos");
                });
#pragma warning restore 612, 618
        }
    }
}
