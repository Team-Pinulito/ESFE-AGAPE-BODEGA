using Bodega_Api_Esfe_Agape.Models.EN;
using ESFE_AGAPE_BODEGA.API.Models.DAL;
using ESFE_AGAPE_BODEGA.API.Models.Entitys;
using ESFE_AGAPE_BODEGA.DTOs.DetalleInresoActivoDTOs;
using ESFE_AGAPE_BODEGA.DTOs.IngresoActivoDTOs;
using ESFE_AGAPE_BODEGA.DTOs.PaqueteActivoDTOs;
using Microsoft.AspNetCore.Mvc;
using static ESFE_AGAPE_BODEGA.DTOs.IngresoActivoDTOs.SearchResultIngresoActivoDTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ESFE_AGAPE_BODEGA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngresoActivoController : ControllerBase
    {

        private IngresoAtivoDAL _ativoDAL;

        public IngresoActivoController(IngresoAtivoDAL ativoDAL)
        {
            _ativoDAL = ativoDAL;
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

            // Mapear la lista de PaqueteActivo a GetIdResultPaqueteActivoDTO
            var ingresoActivoDTO = ingresoActivos.Select(ingreso => new GetIdResultIngresoActivoDTO
            {
                Id = ingreso.Id,
                Correlativo = ingreso.Correlativo,
                UsuarioId = ingreso.UsuarioId,
                FechaIngreso = ingreso.FechaIngreso,
                NumeroDocRelacionado = ingreso.NumeroDocRelacionado,
                Total = ingreso.Total,
                DetalleIngresoActivos = ingreso.detalleIngresoActivos?.Select(detalle => new DetalleIngresoActivoDTO
                {
                    Id = detalle.Id,
                    InventarioActivoId = detalle.InventarioActivoId,
                    Cantidad = detalle.Cantidad,
                    Precio = detalle.Precio
                }).ToList() ?? new List<DetalleIngresoActivoDTO>() // Manejo de nulidad
            }).ToList();

            return ingresoActivoDTO;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearIngresoActivoDTO crearIngresoActivoDTO)
        {
            var ingreso = new IngresoActivo
            {

                Correlativo = crearIngresoActivoDTO.Correlativo,
                UsuarioId = crearIngresoActivoDTO.UsuarioId,
                FechaIngreso = crearIngresoActivoDTO.FechaIngreso,
                NumeroDocRelacionado = crearIngresoActivoDTO.NumeroDocRelacionado,
                Total = crearIngresoActivoDTO.Total,
                detalleIngresoActivos = crearIngresoActivoDTO.CrearDetalleIngresoActivoDTOs.Select(detalle => new DetalleIngresoActivo
                {
                    IngresoActivoId = detalle.InventarioActivoId,
                    Cantidad = detalle.Cantidad,
                    Precio = detalle.Precio,
                }).ToList()
            };

            int result = await _ativoDAL.CrearIngresoActivo(ingreso);

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
                    DetalleIngresoActivoDTO = item.detalleIngresoActivos?.Select(detalle => new DetalleIngresoActivoDTO
                    {
                        Id = detalle.Id,
                        InventarioActivoId = detalle.InventarioActivoId,
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
                DetalleIngresoActivos = ingresoActivo.detalleIngresoActivos.Select(detalle => new DetalleIngresoActivoDTO
                {
                    Id = detalle.Id,
                    InventarioActivoId = detalle.InventarioActivoId,
                    Cantidad = detalle.Cantidad,
                    Precio = detalle.Precio,
                }).ToList() // Mapear los detalles a DetallePaqueteActivoDTO
            };

            return ingresoActivoDTO;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] EditIngresoActivoDTO editIngresoActivoDTO)
        {
            // Obtener el PaqueteActivo existente por ID a través del DAL
            var updateingresoActivo = await _ativoDAL.ObtenerIngresoActivoId(id);

            // Verificar si el PaqueteActivo existe
            if (updateingresoActivo == null)
            {
                return NotFound();
            }

            // Actualizar los campos del PaqueteActivo
            updateingresoActivo.Correlativo = editIngresoActivoDTO.Correlativo;
            updateingresoActivo.UsuarioId = editIngresoActivoDTO.UsuarioId;
            updateingresoActivo.FechaIngreso = editIngresoActivoDTO.FechaIngreso;
            updateingresoActivo.NumeroDocRelacionado = editIngresoActivoDTO.NumeroDocRelacionado;
            updateingresoActivo.Total = editIngresoActivoDTO.Total;

            // Actualizar los DetallePaqueteActivos
            foreach (var detalle in editIngresoActivoDTO.DetalleIngresoActivos)
            {
                var existingDetalle = updateingresoActivo.detalleIngresoActivos
                    .FirstOrDefault(d => d.Id == detalle.Id);

                if (existingDetalle != null)
                {
                    // Si el detalle existe, actualizar sus valores
                    existingDetalle.IngresoActivoId = detalle.InventarioActivoId;
                    existingDetalle.Cantidad = detalle.Cantidad;
                    existingDetalle.Precio = detalle.Precio;
                }
                else
                {
                    // Si el detalle no existe, agregarlo al PaqueteActivo
                    updateingresoActivo.detalleIngresoActivos.Add(new DetalleIngresoActivo
                    {
                        IngresoActivoId = detalle.InventarioActivoId,
                        Cantidad = detalle.Cantidad,
                        Precio = detalle.Precio
                    });
                }
            }

            // Eliminar detalles que ya no están en la nueva lista
            foreach (var existingDetalle in updateingresoActivo.detalleIngresoActivos.ToList())
            {
                if (!editIngresoActivoDTO.DetalleIngresoActivos.Any(d => d.Id == existingDetalle.Id))
                {
                    // Remover el detalle a través del DAL si es necesario
                    updateingresoActivo.detalleIngresoActivos.Remove(existingDetalle);
                }
            }

            // Guardar los cambios usando el DAL
            int result = await _ativoDAL.ActualizaringresoActivo(updateingresoActivo);

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
