using Microsoft.AspNetCore.Mvc;
using ESFE_AGAPE_BODEGA.API.Models.DAL;
using ESFE_AGAPE_BODEGA.DTOs.InventarioActivoDTOs;
using ESFE_AGAPE_BODEGA.API.Models.Entitys;
using System.Threading.Tasks;

namespace ESFE_AGAPE_BODEGA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioActivoController : ControllerBase
    {
        private readonly InventarioActivoDAL _inventarioActivoDAL;

        public InventarioActivoController(InventarioActivoDAL inventarioActivoDAL)
        {
            _inventarioActivoDAL = inventarioActivoDAL;
        }

        [HttpGet]
        public async Task<List<GetIdResultInventarioActivoDTO.InventarioActivoDTO>> ObtenerTodos()
        {
            var inventarios = await _inventarioActivoDAL.ObtenerInventariosActivos();

            var inventarioDto = inventarios.Select(r => new GetIdResultInventarioActivoDTO.InventarioActivoDTO
            {
                Id = r.Id,
                ActivoId = r.ActivoId,
                EstanteId = r.EstanteId,
                Existencia = r.Existencia
            }).ToList();

            return inventarioDto;
        }

        

        [HttpGet("{id}")]
        public async Task<ActionResult<GetIdResultInventarioActivoDTO.InventarioActivoDTO>> ObtenerInventarioActivoId(int id)
        {
            var inventario = await _inventarioActivoDAL.ObtenerInventarioActivoId(id);

            if (inventario == null)
            {
                return NotFound();
            }

            var inventarioDto = new GetIdResultInventarioActivoDTO.InventarioActivoDTO
            {
                Id = inventario.Id,
                ActivoId = inventario.ActivoId,
                EstanteId = inventario.EstanteId,
                Existencia = inventario.Existencia
            };

            return inventarioDto;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CreateInventarioActivoDTO crearInventarioActivoDTO)
        {
            var inventario = new InventarioActivo
            {
                ActivoId = crearInventarioActivoDTO.ActivoId,
                EstanteId = crearInventarioActivoDTO.EstanteId,
                Existencia = crearInventarioActivoDTO.Existencia
            };

            var result = await _inventarioActivoDAL.CrearInventarioActivo(inventario);

            if (result > 0)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] EditInventarioActivoDTO editInventarioActivoDTO)
        {
            if (id != editInventarioActivoDTO.Id)
            {
                return BadRequest();
            }

            var inventario = new InventarioActivo
            {
                Id = editInventarioActivoDTO.Id,
                ActivoId = editInventarioActivoDTO.ActivoId,
                EstanteId = editInventarioActivoDTO.EstanteId,
                Existencia = editInventarioActivoDTO.Existencia
            };

            var result = await _inventarioActivoDAL.ActualizarInventarioActivo(inventario);
            if (result > 0)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _inventarioActivoDAL.EliminarInventarioActivo(id);
            if (result > 0)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(500);
            }
        }
    }
}
