using ESFE_AGAPE_BODEGA.API.Models.DAL;
using ESFE_AGAPE_BODEGA.API.Models.Entitys;
using ESFE_AGAPE_BODEGA.DTOs.BodegaDTOs;
using ESFE_AGAPE_BODEGA.DTOs.RolDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ESFE_AGAPE_BODEGA.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class BodegaController : ControllerBase
    {
        private readonly BodegaDAL _dal;

        public BodegaController(BodegaDAL dal)
        {
            _dal = dal;
        }

        //obtener todos
        [HttpGet]
        
        public async Task<List<GetIdResultBodegaDTO.BodegaDTO>> ObtenerTodos()
        {
            var bodegas = await _dal.ObtenerBodega();

            var bodegaDto = bodegas.Select(r => new GetIdResultBodegaDTO.BodegaDTO
            {
                Id = r.Id,
                Nombre = r.Nombre,
                Descripcion = r.Descripcion
            }).ToList();

            return bodegaDto;
        }

        [HttpPost]
        
        public async Task<IActionResult> Crear([FromBody] CrearBodegaDTO crearBodegaDTO)
        {
            var bodega = new Bodega
            {
                Nombre = crearBodegaDTO.Nombre,
                Descripcion = crearBodegaDTO.Descripcion
            };

            int result = await _dal.CrearBodega(bodega);

            if (result > 0)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(500);
            }
        }

        //obtener todos paginados
        [HttpPost("buscar")]
        public async Task<GetIdResultBodegaDTO> Buscar(SearchQueryBodegaDTO searchbodega)
        {

            var bodega = new Bodega
            {
                Nombre = searchbodega.Nombre != null ? searchbodega.Nombre : string.Empty,
                Descripcion = searchbodega.Descripcion != null ? searchbodega.Descripcion : string.Empty
            };

            var bodegas = new List<Bodega>();
            var countRow = 0;

            if (searchbodega.SendRowCount == 2)
            {
                bodegas = await _dal.BuscarPaginado(bodega, skip: searchbodega.Skip, take: searchbodega.Take);
                if (bodegas.Count > 0)
                {
                    countRow = await _dal.ContarResultRol(bodega);
                }
            }
            else
            {
                bodegas = await _dal.BuscarPaginado(bodega, skip: searchbodega.Skip, take: searchbodega.Take);
            }

            var bodegaResult = new GetIdResultBodegaDTO
            {
                Data = new List<GetIdResultBodegaDTO.BodegaDTO>(),
                CountRow = countRow
            };

            foreach (var item in bodegas)
            {
                bodegaResult.Data.Add(new GetIdResultBodegaDTO.BodegaDTO
                {
                    Id = item.Id,
                    Nombre = item.Nombre,
                    Descripcion = item.Descripcion
                });
            }

            return bodegaResult;

        }

        //obtener por id
        [HttpGet("{id}")]
        public async Task<Bodega> ObtenerRolId(int id)
        {
            return await _dal.ObtenerBodegaId(id);
        }

        //actualizar
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] EditBodegaDTO editBodegaDTO)
        {
            var updateBodega = await _dal.ObtenerBodegaId(id);

            if (updateBodega == null)
            {
                return NotFound();
            }

            updateBodega.Nombre = editBodegaDTO.Nombre;
            updateBodega.Descripcion = editBodegaDTO.Descripcion;

            int result = await _dal.ActualizarBodega(updateBodega);

            if (result > 0)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(500);
            }
        }

        //eliminar
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _dal.EliminarBodega(id);

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
