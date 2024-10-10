using AutoMapper;
using ESFE_AGAPE_BODEGA.API.Models.DAL;
using ESFE_AGAPE_BODEGA.API.Models.Entitys;
using ESFE_AGAPE_BODEGA.DTOs.DetalleSolicitudActivoDTOs;
using ESFE_AGAPE_BODEGA.DTOs.SolicitudActivoDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static ESFE_AGAPE_BODEGA.DTOs.PaqueteActivoDTOs.SearchResultPaqueteActivoDTO;

namespace ESFE_AGAPE_BODEGA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SolicitudActivoController : ControllerBase
    {
        private readonly SolicitudActivoDAL _solicitudActivoDAL;
        private readonly IMapper mapper;

        public SolicitudActivoController(SolicitudActivoDAL solicitudActivoDAL, IMapper mapper)
        {
            _solicitudActivoDAL = solicitudActivoDAL;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<List<GetIdResultSolicitudActivoDTO>> ObtenerTodos()
        {
            // Obtener la lista de SolicitudActivo desde el DAL
            var solicitudesActivos = await _solicitudActivoDAL.ObtenerSolicitudActivos();

            if (solicitudesActivos == null)
            {
                // Manejo del caso cuando la lista es nula
                return new List<GetIdResultSolicitudActivoDTO>();
            }
            var solicitudActivoDto = mapper.Map<List<GetIdResultSolicitudActivoDTO>>(solicitudesActivos);

            return solicitudActivoDto;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearSolicitudActivoDTO solicitudActivoDTO)
        {
            var solicitudActivo = new SolicitudActivo
            {
                UsuarioId = solicitudActivoDTO.UsuarioId,
                UsuarioIdBodegueroEntregaId = solicitudActivoDTO.BodegueroEntregaId,
                UsuarioIdBodegueroRecibeId = solicitudActivoDTO.BodegueroRecibeId,
                Correlativo = solicitudActivoDTO.Correlativo,
                Fecha = solicitudActivoDTO.Fecha,
                FechaEntrega = solicitudActivoDTO.FechaEntrega,
                FechaRecepcion = solicitudActivoDTO.FechaRecepcion,
                FechaEntregaEsperada = solicitudActivoDTO.FechaEntregaEsperada,
                FechaRecepcionEsperada = solicitudActivoDTO.FechaRecepcionEsperada,
                Comentario = solicitudActivoDTO.Comentario,
                DetalleSolicitudActivos = solicitudActivoDTO.CrearDetalleSolicitudActivos.Select(detalle => new DetalleSolicitudActivo
                {
                    ActivoId = detalle.ActivoId,
                    PaqueteActivoId = detalle.PaqueteActivoId,
                    Cantidad = detalle.Cantidad,
                    Status = detalle.Status
                }).ToList()
            };

            var result = await _solicitudActivoDAL.CrearSolicitudActivo(solicitudActivo);

            if (result == 0)
            {
                return StatusCode(500);
            }

            return Ok(result);
        }

        [HttpPost("buscar")]
        public async Task<SearchResultSolicitudActivoDTO> Buscar(SearchQuerySolicitudActivoDTO solicitudActivoDTO)
        {
            var solicitudActivo = new SolicitudActivo
            {
                Correlativo = solicitudActivoDTO.Correlativo_Like ?? string.Empty,
                UsuarioId = solicitudActivoDTO.UsuarioId_Like ?? 0
            };

            var solicitudesActivos = new List<SolicitudActivo>();
            var countRow = 0;

            if (solicitudActivoDTO.SendRowCount == 2)
            {
                solicitudesActivos = await _solicitudActivoDAL.BuscarPaginado(solicitudActivo, skip: solicitudActivoDTO.Skip, take: solicitudActivoDTO.Take);
                if (solicitudesActivos.Count > 0)
                {
                    countRow = await _solicitudActivoDAL.ContarResultSolicitudActivo(solicitudActivo);
                }
            }
            else
            {
                solicitudesActivos = await _solicitudActivoDAL.BuscarPaginado(solicitudActivo, skip: solicitudActivoDTO.Skip, take: solicitudActivoDTO.Take);
            }

            var solicitudActivoResult = new SearchResultSolicitudActivoDTO
            {
                Data = new List<SearchResultSolicitudActivoDTO.SolicitudActivoDTO>(),
                CountRow = countRow
            };

            foreach (var item in solicitudesActivos)
            {
                solicitudActivoResult.Data.Add(new SearchResultSolicitudActivoDTO.SolicitudActivoDTO
                {
                    Id = item.Id,
                    UsuarioId = item.UsuarioId,
                    BodegueroEntregaId = item.UsuarioIdBodegueroEntregaId,
                    BodegueroRecibeId = item.UsuarioIdBodegueroRecibeId,
                    Correlativo = item.Correlativo,
                    Fecha = item.Fecha,
                    FechaEntrega = item.FechaEntrega,
                    FechaRecepcion = item.FechaRecepcion,
                    FechaEntregaEsperada = item.FechaEntregaEsperada,
                    FechaRecepcionEsperada = item.FechaRecepcionEsperada,
                    Comentario = item.Comentario,
                    DetalleSolicitudActivoDTOs = item.DetalleSolicitudActivos?.Select(detalle => new DetalleSolicitudActivoDTO
                    {
                        Id = detalle.Id,
                        ActivoId = detalle.ActivoId,
                        PaqueteActivoId = detalle.PaqueteActivoId,
                        Cantidad = detalle.Cantidad,
                        Status = detalle.Status
                    }).ToList() ?? new List<DetalleSolicitudActivoDTO>()
                });
            }

            return solicitudActivoResult;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetIdResultSolicitudActivoDTO>> ObtenerSolicitudActivoId(int id)
        {
            var solicitudActivo = await _solicitudActivoDAL.ObtenerSolicitudActivoId(id);

            if (solicitudActivo == null)
            {
                return NotFound();
            }

            var solicitudActivoDto = new GetIdResultSolicitudActivoDTO
            {
                Id = solicitudActivo.Id,
                UsuarioId = solicitudActivo.UsuarioId,
                BodegueroEntregaId = solicitudActivo.UsuarioIdBodegueroEntregaId,
                BodegueroRecibeId = solicitudActivo.UsuarioIdBodegueroRecibeId,
                Correlativo = solicitudActivo.Correlativo,
                Fecha = solicitudActivo.Fecha,
                FechaEntrega = solicitudActivo.FechaEntrega,
                FechaRecepcion = solicitudActivo.FechaRecepcion,
                FechaEntregaEsperada = solicitudActivo.FechaEntregaEsperada,
                FechaRecepcionEsperada = solicitudActivo.FechaRecepcionEsperada,
                Comentario = solicitudActivo.Comentario,
                DetalleSolicitudActivoDTOs = solicitudActivo.DetalleSolicitudActivos?.Select(detalle => new DetalleSolicitudActivoDTO
                {
                    Id = detalle.Id,
                    ActivoId = detalle.ActivoId,
                    PaqueteActivoId = detalle.PaqueteActivoId,
                    Cantidad = detalle.Cantidad,
                    Status = detalle.Status
                }).ToList() ?? new List<DetalleSolicitudActivoDTO>()
            };

            return solicitudActivoDto;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] EditSolicitudActivoDTO editSolicitudActivoDTO)
        {
            var updateSolicitudActivo = await _solicitudActivoDAL.ObtenerSolicitudActivoId(id);

            if(updateSolicitudActivo == null)
            {
                return NotFound();
            }

            updateSolicitudActivo.UsuarioId = editSolicitudActivoDTO.UsuarioId;
            updateSolicitudActivo.UsuarioIdBodegueroEntregaId = editSolicitudActivoDTO.BodegueroEntregaId;
            updateSolicitudActivo.UsuarioIdBodegueroRecibeId = editSolicitudActivoDTO.BodegueroRecibeId;
            updateSolicitudActivo.Correlativo = editSolicitudActivoDTO.Correlativo;
            updateSolicitudActivo.Fecha = editSolicitudActivoDTO.Fecha;
            updateSolicitudActivo.FechaEntrega = editSolicitudActivoDTO.FechaEntrega;
            updateSolicitudActivo.FechaRecepcion = editSolicitudActivoDTO.FechaRecepcion;
            updateSolicitudActivo.FechaEntregaEsperada = editSolicitudActivoDTO.FechaEntregaEsperada;
            updateSolicitudActivo.FechaRecepcionEsperada = editSolicitudActivoDTO.FechaRecepcionEsperada;
            updateSolicitudActivo.Comentario = editSolicitudActivoDTO.Comentario;

            foreach (var detalle in editSolicitudActivoDTO.DetalleSolicitudActivoDTOs)
            {
                var existingDetalle = updateSolicitudActivo.DetalleSolicitudActivos.FirstOrDefault(d => d.Id == detalle.Id);
                if (existingDetalle != null)
                {
                    existingDetalle.ActivoId = detalle.ActivoId;
                    existingDetalle.PaqueteActivoId = detalle.PaqueteActivoId;
                    existingDetalle.Cantidad = detalle.Cantidad;
                    existingDetalle.Status = detalle.Status;
                }
                else
                {
                    updateSolicitudActivo.DetalleSolicitudActivos.Add(new DetalleSolicitudActivo
                    {
                        ActivoId = detalle.ActivoId,
                        PaqueteActivoId = detalle.PaqueteActivoId,
                        Cantidad = detalle.Cantidad,
                        Status = detalle.Status
                    });
                }
            }

            foreach (var existingDetalle in updateSolicitudActivo.DetalleSolicitudActivos.ToList())
            {
                if (!editSolicitudActivoDTO.DetalleSolicitudActivoDTOs.Any(d => d.Id == existingDetalle.Id))
                {
                    updateSolicitudActivo.DetalleSolicitudActivos.Remove(existingDetalle);
                }
            }

            var result = await _solicitudActivoDAL.ActualizarSolicitudActivo(updateSolicitudActivo);

            if (result == 0)
            {
                return StatusCode(500);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _solicitudActivoDAL.EliminarSolicitudActivo(id);

            if (result == 0)
            {
                return StatusCode(500);
            }

            return Ok(result);
        }
    }

   
}
