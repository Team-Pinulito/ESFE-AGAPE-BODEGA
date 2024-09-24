using Microsoft.EntityFrameworkCore;
using static ESFE_AGAPE_BODEGA.DTOs.KardexActivoDTOs.SearchResultKardexActivoDTO;

namespace ESFE_AGAPE_BODEGA.API.Models.DAL
{
    public class KardexActivoDAL
    {
        private readonly ApplicationDbContext _context;

        public KardexActivoDAL(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<KardexActivoDTO>> ObtenerKardexActivos()
        {
            return await _context.inventarioActivos
                .Select(ia => new KardexActivoDTO
                {
                    InventarioActivo = ia.Id,
                    FechaMovimiento = DateTime.Now, // Ejemplo
                    Cantidad = ia.Existencia,
                    TipoMovimiento = 1, // Ejemplo
                    Saldo = DateTime.Now // Ejemplo
                })
                .ToListAsync();
        }
    }
}
