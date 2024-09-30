using ESFE_AGAPE_BODEGA.API.Models.DAL;
using ESFE_AGAPE_BODEGA.API.Models.Entitys;
using ESFE_AGAPE_BODEGA.DTOs.TipoActivoDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ESFE_AGAPE_BODEGA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TipoActivoController : ControllerBase
    {
        private readonly TipoActivoDAL _tipoActivoDAL;

        public TipoActivoController(TipoActivoDAL tipoActivoDAL)
        {
            _tipoActivoDAL = tipoActivoDAL;
        }

        // Obtener todos
        [HttpGet]
        public async Task<List<GetIdResultTipoActivoDTO>> ObtenerTodos()
        {
            var tipoActivos = await _tipoActivoDAL.ObtenerTipoActivos();

            return tipoActivos.Select(t => new GetIdResultTipoActivoDTO
            {
                Id = t.Id,
                Nombre = t.Nombre,
                Descripcion = t.Descripcion
            }).ToList();
        }

        // Obtener todos paginados
        [HttpPost("buscar")]
        public async Task<IActionResult> Buscar(SearchQueryTipoActivoDTO tipoActivoDto)
        {

            var tipoActivo = new TipoActivo
            {
                Nombre = tipoActivoDto.Nombre_Like ?? string.Empty
            };

            var tipoActivos = await _tipoActivoDAL.BuscarPaginado(tipoActivo, tipoActivoDto.Skip, tipoActivoDto.Take);
            var countRow = tipoActivoDto.SendRowCount == 2 ? await _tipoActivoDAL.ContarResultTipoActivo(tipoActivo) : 0;

            var tipoActivoResult = new
            {
                Data = tipoActivos.Select(item => new GetIdResultTipoActivoDTO
                {
                    Id = item.Id,
                    Nombre = item.Nombre,
                    Descripcion = item.Descripcion
                }).ToList(),
                CountRow = countRow
            };

            return Ok(tipoActivoResult);
        }

        // Obtener por id
        [HttpGet("{id}")]
        public async Task<ActionResult<GetIdResultTipoActivoDTO>> ObtenerPorId(int id)
        {
            var tipoActivo = await _tipoActivoDAL.ObtenerTipoActivoId(id);

            if (tipoActivo == null)
            {
                return NotFound();
            }

            return new GetIdResultTipoActivoDTO
            {
                Id = tipoActivo.Id,
                Nombre = tipoActivo.Nombre,
                Descripcion = tipoActivo.Descripcion
            };
        }

        // Crear 
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearTipoActivoDTO crearTipoActivoDto)
        {
            var tipoActivo = new TipoActivo
            {
                Nombre = crearTipoActivoDto.Nombre,
                Descripcion = crearTipoActivoDto.Descripcion
            };

            int result = await _tipoActivoDAL.CrearTipoActivo(tipoActivo);

            if (result > 0)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(500);
            }
        }

        // Actualizar
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] EditTipoActivoDTO editarTipoActivoDto)
        {
            var tipoActivoExistente = await _tipoActivoDAL.ObtenerTipoActivoId(id);

            if (tipoActivoExistente == null)
            {
                return NotFound();
            }

            tipoActivoExistente.Nombre = editarTipoActivoDto.Nombre;
            tipoActivoExistente.Descripcion = editarTipoActivoDto.Descripcion;

            int result = await _tipoActivoDAL.ActualizarTipoActivo(tipoActivoExistente);

            if (result > 0)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(500);
            }
        }

        // Eliminar
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _tipoActivoDAL.EliminarTipoActivo(id);

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
