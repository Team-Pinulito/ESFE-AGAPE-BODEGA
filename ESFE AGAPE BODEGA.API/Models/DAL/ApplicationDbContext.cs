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
    }
}
