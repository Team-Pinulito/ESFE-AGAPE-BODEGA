using ESFE_AGAPE_BODEGA.API.Models.Entitys;
using ESFE_AGAPE_BODEGA.DTOs.KardexActivoDTOs;
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
                    FechaMovimiento = DateTime.Now, // Cambia esto según tus necesidades
                    Cantidad = ia.Existencia,
                    TipoMovimiento = 1, // Cambia esto según tus necesidades
                    Saldo = DateTime.Now // Cambia esto según tus necesidades
                })
                .ToListAsync();
        }

        public async Task AgregarKardexActivo(CreateKardexActivoDTO dto)
        {
            var kardexActivo = new KardexActivo
            {
                InventarioActivoId = dto.InventarioActivoId,
                FechaMovimiento = dto.FechaMovimiento,
                Cantidad = dto.Cantidad,
                TipoMovimiento = dto.TipoMovimiento,
                Saldo = dto.Saldo
            };

            _context.kardexActivos.Add(kardexActivo);
            await _context.SaveChangesAsync();
        }
    }
}
