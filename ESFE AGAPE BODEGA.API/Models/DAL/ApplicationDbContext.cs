using Bodega_Api_Esfe_Agape.Models.EN;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
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
        public DbSet<IngresoActivo> ingresoactivos { get; set; }
        public DbSet<DetalleIngresoActivo> detalleIngresos { get; set; }
    }
}
