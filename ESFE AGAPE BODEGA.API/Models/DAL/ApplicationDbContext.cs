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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<PaqueteActivo>()
			.HasMany(p => p.DetallePaqueteActivos)
			.WithOne(d => d.PaqueteActivo)
			.HasForeignKey(d => d.PaqueteActivoId)
			.OnDelete(DeleteBehavior.Cascade); // Aquí habilitas la eliminación en cascada
		}
	}
}
