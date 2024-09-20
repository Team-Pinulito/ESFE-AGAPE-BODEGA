using Bodega_Api_Esfe_Agape.Models.EN;
using ESFE_AGAPE_BODEGA.API.Models.DAL;
using ESFE_AGAPE_BODEGA.DTOs.ActivoDTOs;
using Microsoft.AspNetCore.Mvc;
using static ESFE_AGAPE_BODEGA.DTOs.ActivoDTOs.SearchResultActivoDTO;

namespace ESFE_AGAPE_BODEGA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivoController : ControllerBase
    {

        private readonly ActivoDAL _activoDAL;

        public ActivoController(ActivoDAL activoDAL)
        {
            _activoDAL = activoDAL;
        }

        // GET: api/Activo
        [HttpGet]
        public async Task<ActionResult<List<ActivoDTO>>> ObtenerTodos()
        {
            var activos = await _activoDAL.ObtenerActivos();

            var activoDto = activos.Select(r => new ActivoDTO
            {
                Id = r.Id,
                Nombre = r.Nombre,
                Descripcion = r.Descripcion,
                EstanteId = r.EstanteId,
                TipoActivoId = r.TipoActivoId,
                Codigo = r.Codigo,
                CodigoBarra = r.CodigoBarra
            }).ToList();

            return Ok(activoDto);
        }

        // POST: api/Activo/buscar
        [HttpPost("buscar")]
        public async Task<ActionResult<SearchResultActivoDTO>> Buscar(SearchQueryActivoDTO activoDto)
        {
            var activo = new Activo
            {
                Nombre = activoDto.Nombre ?? string.Empty,
            };

            var activos = await _activoDAL.BuscarPaginado(activo, activoDto.Take, activoDto.Skip);
            var countRow = activoDto.SendRowCount == 2 ? await _activoDAL.ContarResultActivo(activo) : 0;

            var activoResult = new SearchResultActivoDTO
            {
                Data = activos.Select(a => new ActivoDTO
                {
                    Id = a.Id,
                    Nombre = a.Nombre,
                    Descripcion = a.Descripcion,
                    EstanteId = a.EstanteId,
                    TipoActivoId = a.TipoActivoId,
                    Codigo = a.Codigo,
                    CodigoBarra = a.CodigoBarra
                }).ToList(),
                CountRow = countRow
            };

            return Ok(activoResult);
        }

        // GET: api/Activo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActivoDTO>> ObtenerActivoId(int id)
        {
            var activo = await _activoDAL.ObtenerActivoPorId(id);

            if (activo == null)
            {
                return NotFound();
            }

            var activoDto = new ActivoDTO
            {
                Id = activo.Id,
                Nombre = activo.Nombre,
                Descripcion = activo.Descripcion,
                EstanteId = activo.EstanteId,
                TipoActivoId = activo.TipoActivoId,
                Codigo = activo.Codigo,
                CodigoBarra = activo.CodigoBarra
            };

            return Ok(activoDto);
        }

        // POST: api/Activo
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearActivoDTO crearActivoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var activo = new Activo
            {
                Nombre = crearActivoDTO.Nombre,
                Descripcion = crearActivoDTO.Descripcion,
                EstanteId = crearActivoDTO.EstanteId,
                TipoActivoId = crearActivoDTO.TipoActivoId,
                Codigo = crearActivoDTO.Codigo,
                CodigoBarra = crearActivoDTO.CodigoBarra
            };

            var result = await _activoDAL.CrearActivo(activo);

            if (result > 0)
            {
                return CreatedAtAction(nameof(ObtenerActivoId), new { id = activo.Id }, activo);
            }
            else
            {
                return StatusCode(500, "Error al crear el activo.");
            }
        }

        // PUT: api/Activo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] EditActivoDTO editActivoDTO)
        {
            if (!ModelState.IsValid || id != editActivoDTO.Id)
            {
                return BadRequest(ModelState);
            }

            var activo = new Activo
            {
                Id = editActivoDTO.Id,
                Nombre = editActivoDTO.Nombre,
                Descripcion = editActivoDTO.Descripcion,
                EstanteId = editActivoDTO.EstanteId,
                TipoActivoId = editActivoDTO.TipoActivoId,
                Codigo = editActivoDTO.Codigo,
                CodigoBarra = editActivoDTO.CodigoBarra
            };

            var result = await _activoDAL.ActualizarActivo(activo);
            if (result > 0)
            {
                return Ok("Activo actualizado correctamente.");
            }
            else
            {
                return StatusCode(500, "Error al actualizar el activo.");
            }
        }

        // DELETE: api/Activo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _activoDAL.EliminarActivo(id);
            if (result > 0)
            {
                return Ok("Activo eliminado correctamente.");
            }
            else
            {
                return StatusCode(500, "Error al eliminar el activo.");
            }
        }
    }
}
