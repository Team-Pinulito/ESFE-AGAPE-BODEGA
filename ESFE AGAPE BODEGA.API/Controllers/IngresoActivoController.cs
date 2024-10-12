using AutoMapper;
using Bodega_Api_Esfe_Agape.Models.EN;
using ESFE_AGAPE_BODEGA.API.Models.DAL;
using ESFE_AGAPE_BODEGA.DTOs.DetalleInresoActivoDTOs;
using ESFE_AGAPE_BODEGA.DTOs.IngresoActivoDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ESFE_AGAPE_BODEGA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IngresoActivoController : ControllerBase
    {

        private IngresoAtivoDAL _ativoDAL;
        private IMapper mapper;

        public IngresoActivoController(IngresoAtivoDAL ativoDAL, IMapper mapper)
        {
            _ativoDAL = ativoDAL;
            this.mapper = mapper;
        }



        [HttpGet]
        public async Task<List<GetIdResultIngresoActivoDTO>> ObtenerTodos()
        {
            // Obtener la lista de PaqueteActivo desde el DAL
            var ingresoActivos = await _ativoDAL.ObtenerIngresoActivo();

            if (ingresoActivos == null)
            {
                // Manejo del caso cuando la lista es nula
                return new List<GetIdResultIngresoActivoDTO>();
            }
            var ingresoActivoDto = mapper.Map<List<GetIdResultIngresoActivoDTO>>(ingresoActivos);

            return ingresoActivoDto;
        }

        [HttpPost]
        public async Task<IActionResult> CrearIngresoActivo([FromBody] CrearIngresoActivoDTO crearIngresoActivoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nuevoIngresoActivo = new IngresoActivo
            {
                Correlativo = crearIngresoActivoDTO.Correlativo,
                UsuarioId = crearIngresoActivoDTO.UsuarioId,
                FechaIngreso = crearIngresoActivoDTO.FechaIngreso,
                NumeroDocRelacionado = crearIngresoActivoDTO.NumeroDocRelacionado,
                Total = crearIngresoActivoDTO.Total,
                DetalleIngresoActivos = crearIngresoActivoDTO.CrearDetalleIngresoActivos.Select(detalle => new DetalleIngresoActivo
                {
                    Cantidad = detalle.Cantidad,
                    Precio = detalle.Precio
                }).ToList()
            };

			int result = await _ativoDAL.CrearIngresoActivo(nuevoIngresoActivo);

			if (result > 0)
			{
				return Ok(result);
			}
			else
			{
				return StatusCode(500);
			}
		}


        [HttpPost("buscar")]
        public async Task<SearchResultIngresoActivoDTO> Buscar(SearchQueryIngresoActivoDTO ingresoActivoDTO)
        {
            var ingreso = new IngresoActivo
            {
                
                Correlativo = ingresoActivoDTO.Correlativo_Like ?? string.Empty
            };

            var ingresos = new List<IngresoActivo>();
            var countRow = 0;

            if (ingresoActivoDTO.SendRowCount == 2)
            {
                ingresos = await _ativoDAL.BuscarPaginado(ingreso, skip: ingresoActivoDTO.Skip, take: ingresoActivoDTO.Take);
                if (ingresos.Count > 0)
                {
                    countRow = await _ativoDAL.ContarResultIngresoActivo(ingreso);
                }
            }
            else
            {
                ingresos = await _ativoDAL.BuscarPaginado(ingreso, skip: ingresoActivoDTO.Skip, take: ingresoActivoDTO.Take);
            }

            var ingresoActivoResult = new SearchResultIngresoActivoDTO
            {
                Data = new List<SearchResultIngresoActivoDTO.IngresoActivoDTO>(),
                CountRow = countRow
            };

            foreach (var item in ingresos)
            {
                ingresoActivoResult.Data.Add(new SearchResultIngresoActivoDTO.IngresoActivoDTO
                {
                    Id = item.Id,
                    Correlativo = item.Correlativo,            
                    DetalleIngresoActivoDTO = item.DetalleIngresoActivos?.Select(detalle => new DetalleIngresoActivoDTO
                    {
                        Id = detalle.Id,
                        Cantidad = detalle.Cantidad,
                        Precio = detalle.Precio,
                    }).ToList() ?? new List<DetalleIngresoActivoDTO>() // Manejo de nulidad
                });
            }

            return ingresoActivoResult;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetIdResultIngresoActivoDTO>> ObtenerIngresoActivoId(int id)
        {
            // Llamar al método del DAL para obtener el PaqueteActivo por su ID
            var ingresoActivo = await _ativoDAL.ObtenerIngresoActivoId(id);

            // Verificar si el PaqueteActivo existe
            if (ingresoActivo == null)
            {
                return NotFound();
            }

            // Mapear el PaqueteActivo a su DTO, incluyendo los DetallePaqueteActivos
            var ingresoActivoDTO = new GetIdResultIngresoActivoDTO
            {
                Id = ingresoActivo.Id,
                Correlativo = ingresoActivo.Correlativo,
                UsuarioId = ingresoActivo.UsuarioId,
                FechaIngreso = ingresoActivo.FechaIngreso,
                NumeroDocRelacionado = ingresoActivo.NumeroDocRelacionado,
                Total = ingresoActivo.Total,
                DetalleIngresoActivos = ingresoActivo.DetalleIngresoActivos.Select(detalle => new DetalleIngresoActivoDTO
                {
                    Id = detalle.Id,
                    Cantidad = detalle.Cantidad,
                    Precio = detalle.Precio,
                }).ToList() // Mapear los detalles a DetallePaqueteActivoDTO
            };

            return ingresoActivoDTO;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] EditIngresoActivoDTO editIngresoActivoDTO)
        {
            var existingIngresoActivo = await _ativoDAL.ObtenerIngresoActivoId(id);
            if (existingIngresoActivo == null)
            {
                return NotFound();
            }

            existingIngresoActivo.Correlativo = editIngresoActivoDTO.Correlativo;
            existingIngresoActivo.UsuarioId = editIngresoActivoDTO.UsuarioId;
            existingIngresoActivo.FechaIngreso = editIngresoActivoDTO.FechaIngreso;
            existingIngresoActivo.NumeroDocRelacionado = editIngresoActivoDTO.NumeroDocRelacionado;
            existingIngresoActivo.Total = editIngresoActivoDTO.Total;

            foreach (var detalle in editIngresoActivoDTO.DetalleIngresoActivos)
            {
                var existingDetalle = existingIngresoActivo.DetalleIngresoActivos
                    .FirstOrDefault(d => d.Id == detalle.Id);

                if (existingDetalle != null)
                {
                    existingDetalle.Cantidad = detalle.Cantidad;
                    existingDetalle.Precio = detalle.Precio;
                }
                else
                {
                    existingIngresoActivo.DetalleIngresoActivos.Add(new DetalleIngresoActivo
                    {
                        Cantidad = detalle.Cantidad,
                        Precio = detalle.Precio
                    });
                }
            }

            foreach (var existingDetalle in existingIngresoActivo.DetalleIngresoActivos.ToList())
            {
                if (!editIngresoActivoDTO.DetalleIngresoActivos.Any(d => d.Id == existingDetalle.Id))
                {
                    existingIngresoActivo.DetalleIngresoActivos.Remove(existingDetalle);
                }
            }

            var result = await _ativoDAL.ActualizaringresoActivo(existingIngresoActivo);

            if (result == 0)
            {
                return StatusCode(500);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _ativoDAL.EliminarIngresoActivo(id);

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
