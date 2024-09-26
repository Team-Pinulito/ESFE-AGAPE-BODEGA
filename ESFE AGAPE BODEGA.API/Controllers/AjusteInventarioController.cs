using Microsoft.AspNetCore.Mvc;
using ESFE_AGAPE_BODEGA.API.Models.DAL;
using ESFE_AGAPE_BODEGA.DTOs.AjustesInventarioDTOs;
using ESFE_AGAPE_BODEGA.API.Models.Entitys;
using System.Threading.Tasks;
using ESFE_AGAPE_BODEGA.DTOs.AjustesInventarioDTOs;
using static ESFE_AGAPE_BODEGA.DTOs.UsuarioDTOs.GetIdResultUsuarioDTO;
using Microsoft.AspNetCore.Authorization;

namespace ESFE_AGAPE_BODEGA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AjusteInventarioController : ControllerBase
    {
        private readonly AjusteInventarioDAL _ajusteInventarioDAL;

        public AjusteInventarioController(AjusteInventarioDAL ajusteInventarioDAL)
        {
            _ajusteInventarioDAL = ajusteInventarioDAL;
        }

        [HttpGet]
        public async Task<List<GetIdResultAjusteInvetarioDTO.AjusteInventarioDTO>> ObtenerTodos()
        {
            var ajustes = await _ajusteInventarioDAL.ObtenerAjustesInventario();

            var ajustesDto = ajustes.Select(a => new GetIdResultAjusteInvetarioDTO.AjusteInventarioDTO
            {
                Id = a.Id,
                UsuarioId = a.UsuarioId,
                FechaIngreso = a.FechaIngreso,
                Correlativo = a.Correlativo,
                Cantidad = a.Cantidad,
                TipoMantenimiento = a.TipoMantenimiento,
                Comentario = a.Comentario
            }).ToList();

            return ajustesDto;
        }

        [HttpPost("buscar")]
        public async Task<GetIdResultAjusteInvetarioDTO> Buscar(SearchQueryAjusteInvetarioDTO ajusteDto)
        {
            var ajuste = new AjusteInventario
            {
                FechaIngreso = ajusteDto.FechaIngreso ?? DateTime.MinValue,
            };

            var ajustes = new List<AjusteInventario>();
            var countRow = 0;

            if (ajusteDto.SendRowCount == 2)
            {
                ajustes = await _ajusteInventarioDAL.BuscarPaginado(ajuste, skip: ajusteDto.Skip, take: ajusteDto.Take);
                if (ajustes.Count > 0)
                {
                    countRow = await _ajusteInventarioDAL.ContarResultAjusteInventario(ajuste);
                }
            }
            else
            {
                ajustes = await _ajusteInventarioDAL.BuscarPaginado(ajuste, skip: ajusteDto.Skip, take: ajusteDto.Take);
            }

            var ajusteResult = new GetIdResultAjusteInvetarioDTO
            {
                Data = new List<GetIdResultAjusteInvetarioDTO.AjusteInventarioDTO>(),
                CountRow = countRow
            };

            foreach (var item in ajustes)
            {
                ajusteResult.Data.Add(new GetIdResultAjusteInvetarioDTO.AjusteInventarioDTO
                {
                    Id = item.Id,
                    UsuarioId = item.UsuarioId,
                    FechaIngreso = item.FechaIngreso,
                    Correlativo = item.Correlativo,
                    Cantidad = item.Cantidad,
                    TipoMantenimiento = item.TipoMantenimiento,
                    Comentario = item.Comentario
                });
            }

            return ajusteResult;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetIdResultAjusteInvetarioDTO.AjusteInventarioDTO>> ObtenerAjusteInventarioId(int id)
        {
            var ajuste = await _ajusteInventarioDAL.ObtenerAjusteInventarioId(id);

            if (ajuste == null)
            {
                return NotFound();
            }

            var ajusteDto = new GetIdResultAjusteInvetarioDTO.AjusteInventarioDTO
            {
                Id = ajuste.Id,
                UsuarioId = ajuste.UsuarioId,
                FechaIngreso = ajuste.FechaIngreso,
                Correlativo = ajuste.Correlativo,
                Cantidad = ajuste.Cantidad,
                TipoMantenimiento = ajuste.TipoMantenimiento,
                Comentario = ajuste.Comentario
            };

            return ajusteDto;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CreateAjusteInvetarioDTO crearAjusteInventarioDTO)
        {
            var ajuste = new AjusteInventario
            {
                UsuarioId = crearAjusteInventarioDTO.UsuarioId,
                FechaIngreso = crearAjusteInventarioDTO.FechaIngreso,
                Correlativo = crearAjusteInventarioDTO.Correlativo,
                Cantidad = crearAjusteInventarioDTO.Cantidad,
                TipoMantenimiento = crearAjusteInventarioDTO.TipoMantenimiento,
                Comentario = crearAjusteInventarioDTO.Comentario
            };

            var result = await _ajusteInventarioDAL.CrearAjusteInventario(ajuste);

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
        public async Task<IActionResult> Actualizar(int id, [FromBody] EditAjusteInvetarioDTO editAjusteInventarioDTO)
        {
            if (id != editAjusteInventarioDTO.Id)
            {
                return BadRequest();
            }

            var ajuste = new AjusteInventario
            {
                Id = editAjusteInventarioDTO.Id,
                UsuarioId = editAjusteInventarioDTO.UsuarioId,
                FechaIngreso = editAjusteInventarioDTO.FechaIngreso,
                Correlativo = editAjusteInventarioDTO.Correlativo,
                Cantidad = editAjusteInventarioDTO.Cantidad,
                TipoMantenimiento = editAjusteInventarioDTO.TipoMantenimiento,
                Comentario = editAjusteInventarioDTO.Comentario
            };

            var result = await _ajusteInventarioDAL.ActualizarAjusteInventario(ajuste);
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
            var result = await _ajusteInventarioDAL.EliminarAjusteInventario(id);
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
