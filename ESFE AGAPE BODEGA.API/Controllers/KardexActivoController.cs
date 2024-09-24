using ESFE_AGAPE_BODEGA.API.Models.DAL;
using ESFE_AGAPE_BODEGA.DTOs.KardexActivoDTOs;
using Microsoft.AspNetCore.Mvc;

namespace ESFE_AGAPE_BODEGA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KardexActivoController : ControllerBase
    {
        private readonly KardexActivoDAL _kardexActivoDAL;

        public KardexActivoController(KardexActivoDAL kardexActivoDAL)
        {
            _kardexActivoDAL = kardexActivoDAL;
        }

        [HttpGet]
        public async Task<ActionResult<SearchResultKardexActivoDTO>> GetKardexActivos([FromQuery] SearchQueryKardexActivoDTO query)
        {
            var kardexActivos = await _kardexActivoDAL.ObtenerKardexActivos();

            // Aplicar filtros si es necesario
            if (query.InventarioActivoId.HasValue)
            {
                kardexActivos = kardexActivos
                    .FindAll(k => k.InventarioActivo == query.InventarioActivoId.Value);
            }

            if (query.FechaMovimiento.HasValue)
            {
                kardexActivos = kardexActivos
                    .FindAll(k => k.FechaMovimiento.Date == query.FechaMovimiento.Value.Date);
            }

            // Paginación
            var result = new SearchResultKardexActivoDTO
            {
                CountRow = kardexActivos.Count,
                Data = kardexActivos
                    .Skip(query.Skip)
                    .Take(query.Take)
                    .ToList()
            };

            return Ok(result);
        }
    }
}
