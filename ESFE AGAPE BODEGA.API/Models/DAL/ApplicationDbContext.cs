using Bodega_Api_Esfe_Agape.Models.EN;
using ESFE_AGAPE_BODEGA.API.Models.Entitys;
using Microsoft.EntityFrameworkCore;

namespace ESFE_AGAPE_BODEGA.API.Models.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
        {
        }

        public DbSet<Activo> activos { get; set; }
        public DbSet<Estante> estantes { get; set; }
        public DbSet<IngresoActivo> ingresoactivos { get; set; }
        public DbSet<DetalleIngresoActivo> detalleIngresos { get; set; }
        public DbSet<TipoActivo> tipoActivos { get; set; }
        public DbSet<Bodega> bodegas { get; set; }
        public DbSet<Rol> roles { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<PaqueteActivo> paqueteActivos { get; set; }
        public DbSet<DetallePaqueteActivo> detallePaqueteActivos { get; set; }
        public DbSet<AjusteInventario> ajusteInventarios { get; set; }
        public DbSet<InventarioActivo> inventarioActivos { get; set; }
        public DbSet<SolicitudActivo> solicitudActivos { get; set; }
        public DbSet<DetalleSolicitudActivo> detalleSolicitudActivos { get; set; }
        public DbSet<KardexActivo> kardexActivos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PaqueteActivo>()
            .HasMany(p => p.DetallePaqueteActivos)
            .WithOne(d => d.PaqueteActivo)
            .HasForeignKey(d => d.PaqueteActivoId)
            .OnDelete(DeleteBehavior.Cascade); // Aquí habilitas la eliminación en cascada
                                               // Relación 1-a-muchos entre Usuario y SolicitudActivo (quien hace la solicitud)
                                               // Relación 1-a-muchos entre Usuario y SolicitudActivo (quien hace la solicitud)
            modelBuilder.Entity<SolicitudActivo>()
                .HasOne(s => s.Usuario)
                .WithMany(u => u.SolicitudActivos) // Asegúrate de tener esta colección en Usuario
                .HasForeignKey(s => s.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade); // Restringe la eliminación en cascada

            modelBuilder.Entity<SolicitudActivo>()
                .HasMany(s => s.DetalleSolicitudActivos)
                .WithOne(d => d.SolicitudActivo)
                .HasForeignKey(d => d.SolicitudActivoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación 1-a-1 entre UsuarioBodegueroEntrega y SolicitudActivo
            modelBuilder.Entity<SolicitudActivo>()
                .HasOne(s => s.UsuarioBodegueroEntrega)
                .WithMany(u => u.BodegasEntregaSolicitudes)
                .HasForeignKey(s => s.UsuarioIdBodegueroEntregaId)
                .OnDelete(DeleteBehavior.Restrict); // Evitar eliminación en cascada

            // Relación 1-a-1 entre UsuarioBodegueroRecibe y SolicitudActivo
            modelBuilder.Entity<SolicitudActivo>()
                .HasOne(s => s.UsuarioBodegueroRecibe)
                .WithMany(u => u.BodegaRecibeSolicitudes)
                .HasForeignKey(s => s.UsuarioIdBodegueroRecibeId)
                .OnDelete(DeleteBehavior.Restrict); // Evitar e

            modelBuilder.Entity<IngresoActivo>()
               .HasMany(i => i.DetalleIngresoActivos)
               .WithOne(d => d.ingresoActivo)
               .HasForeignKey(d => d.IngresoActivoId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DetalleIngresoActivo>()
                .HasOne(d => d.ingresoActivo)
                .WithMany(i => i.DetalleIngresoActivos)
                .HasForeignKey(d => d.IngresoActivoId);

            modelBuilder.Entity<DetalleIngresoActivo>()
                .HasOne(d => d.inventarioActivo)
                .WithMany(i => i.DetalleIngresoActivos)
                .HasForeignKey(d => d.InventarioActivoId);
        }
    }
}
