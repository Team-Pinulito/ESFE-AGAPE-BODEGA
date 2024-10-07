using Bodega_Api_Esfe_Agape.Models.EN;
using ESFE_AGAPE_BODEGA.API.Models.DAL;
using ESFE_AGAPE_BODEGA.DTOs.ActivoDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ESFE_AGAPE_BODEGA.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ActivoController : ControllerBase
    {
        private readonly ActivoDAL _activoDAL;

        public ActivoController(ActivoDAL activoDAL)
        {
            _activoDAL = activoDAL;
        }

        [HttpGet]
        public async Task<List<GetIdResultActivoDTO>> ObtenerTodos()
        {
            var activos = await _activoDAL.ObtenerActivos();
            return activos.Select(a => new GetIdResultActivoDTO
            {
                Id = a.Id,
                Nombre = a.Nombre,
                Descripcion = a.Descripcion,
                EstanteId = a.EstanteId,
                TipoActivoId = a.TipoActivoId,
                Codigo = a.Codigo,
                CodigoBarra = a.CodigoBarra
            }).ToList();
        }

        [HttpPost("buscar")]
        public async Task<SearchResultActivoDTO> Buscar(SearchQueryActivoDTO activoDTO)
        {
            var activo = new Activo
            {
                Nombre = activoDTO.Nombre ?? string.Empty
            };

            var activos = await _activoDAL.BuscarPaginado(activo, activoDTO.Take, activoDTO.Skip);
            var countRow = await _activoDAL.ContarResultActivo(activo);

            return new SearchResultActivoDTO
            {
                Data = activos.Select(a => new SearchResultActivoDTO.ActivoDTO
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
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetIdResultActivoDTO>> ObtenerActivoId(int id)
        {
            var activo = await _activoDAL.ObtenerActivoPorId(id);
            if (activo == null)
            {
                return NotFound();
            }

            return new GetIdResultActivoDTO
            {
                Id = activo.Id,
                Nombre = activo.Nombre,
                Descripcion = activo.Descripcion,
                EstanteId = activo.EstanteId,
                TipoActivoId = activo.TipoActivoId,
                Codigo = activo.Codigo,
                CodigoBarra = activo.CodigoBarra
            };
        }

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
                CodigoBarra = string.IsNullOrEmpty(crearActivoDTO.CodigoBarra)
                      ? _activoDAL.GenerarCodigoBarra()
                      : crearActivoDTO.CodigoBarra
            };

            int result = await _activoDAL.CrearActivo(activo);

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
        public async Task<IActionResult> Actualizar(int id, [FromBody] EditActivoDTO editActivoDTO)
        {
            var updateActivo = await _activoDAL.ObtenerActivoPorId(id);

            if (updateActivo == null)
            {
                return NotFound();
            }

            updateActivo.Nombre = editActivoDTO.Nombre;
            updateActivo.Descripcion = editActivoDTO.Descripcion;
            updateActivo.EstanteId = editActivoDTO.EstanteId;
            updateActivo.TipoActivoId = editActivoDTO.TipoActivoId;
            updateActivo.Codigo = editActivoDTO.Codigo;
            updateActivo.CodigoBarra = editActivoDTO.CodigoBarra;

            int result = await _activoDAL.ActualizarActivo(updateActivo);

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
            int result = await _activoDAL.EliminarActivo(id);

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

