using ESFE_AGAPE_BODEGA.API.Models.DAL;
using ESFE_AGAPE_BODEGA.API.Models.Entitys;
using ESFE_AGAPE_BODEGA.DTOs.DetallePaqueteActivoDTOs;
using ESFE_AGAPE_BODEGA.DTOs.PaqueteActivoDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESFE_AGAPE_BODEGA.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PaqueteActivoController : ControllerBase
	{


		private readonly PaqueteActivoDAL _paqueteActivoDAL;
		public PaqueteActivoController(PaqueteActivoDAL paqueteActivoDAL)
		{
			_paqueteActivoDAL = paqueteActivoDAL;
		}


		[HttpGet]
		public async Task<List<GetIdResultPaqueteActivoDTO>> ObtenerTodos()
		{
			// Obtener la lista de PaqueteActivo desde el DAL
			var paquetesActivos = await _paqueteActivoDAL.ObtenerPaqueteActivos();

			// Mapear la lista de PaqueteActivo a GetIdResultPaqueteActivoDTO
			var paqueteActivoDto = paquetesActivos.Select(paquete => new GetIdResultPaqueteActivoDTO
			{
				Id = paquete.Id,
				Correlativo = paquete.Correlativo,
				Nombre = paquete.Nombre,
				DetallePaqueteActivos = paquete.DetallePaqueteActivos.Select(detalle => new DetallePaqueteActivoDTO
				{
					Id = detalle.Id,
					ActivoId = detalle.ActivoId,
					Cantidad = detalle.Cantidad
				}).ToList() // Mapeo de cada DetallePaqueteActivo a su DTO
			}).ToList();

			return paqueteActivoDto;
		}

		[HttpPost]
		public async Task<IActionResult> Crear([FromBody] CrearPaqueteActivoDTO paqueteActivoDTO)
		{
			var paqueteActivo = new PaqueteActivo
			{
				Correlativo = paqueteActivoDTO.Correlativo,
				Nombre = paqueteActivoDTO.Nombre,
				DetallePaqueteActivos = paqueteActivoDTO.DetallePaqueteActivos.Select(detalle => new DetallePaqueteActivo
				{
					ActivoId = detalle.ActivoId,
					Cantidad = detalle.Cantidad
				}).ToList()
			};

			int result = await _paqueteActivoDAL.CrearPaqueteActivo(paqueteActivo);

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
		public async Task<SearchResultPaqueteActivoDTO> Buscar(SearchQueryPaqueteActivoDTO paqueteActivoDTO)
		{
			// Crear el objeto PaqueteActivo con los filtros recibidos en el DTO
			var paqueteActivo = new PaqueteActivo
			{
				Nombre = paqueteActivoDTO.Nombre_Like != null ? paqueteActivoDTO.Nombre_Like : string.Empty,
				Correlativo = paqueteActivoDTO.Correlativo_Like != null ? paqueteActivoDTO.Correlativo_Like : string.Empty
			};

			var paquetesActivos = new List<PaqueteActivo>();
			var countRow = 0;

			// Verificar si se debe contar los resultados
			if (paqueteActivoDTO.SendRowCount == 2)
			{
				// Buscar paginados y contar el total de registros
				paquetesActivos = await _paqueteActivoDAL.BuscarPaginado(paqueteActivo, skip: paqueteActivoDTO.Skip, take: paqueteActivoDTO.Take);
				if (paquetesActivos.Count > 0)
				{
					countRow = await _paqueteActivoDAL.ContarResultPaqueteActivo(paqueteActivo);
				}
			}
			else
			{
				// Buscar paginados sin contar
				paquetesActivos = await _paqueteActivoDAL.BuscarPaginado(paqueteActivo, skip: paqueteActivoDTO.Skip, take: paqueteActivoDTO.Take);
			}

			// Mapear los resultados a DTOs
			var paqueteActivoResult = new SearchResultPaqueteActivoDTO
			{
				Data = new List<SearchResultPaqueteActivoDTO.PaqueteActivoDTO>(),
				CountRow = countRow
			};

			// Rellenar la lista de resultados con el mapeo de PaqueteActivo y sus Detalles
			foreach (var item in paquetesActivos)
			{
				paqueteActivoResult.Data.Add(new SearchResultPaqueteActivoDTO.PaqueteActivoDTO
				{
					Id = item.Id,
					Correlativo = item.Correlativo,
					Nombre = item.Nombre,
					DetallePaqueteActivos = item.DetallePaqueteActivos.Select(detalle => new DetallePaqueteActivoDTO
					{
						Id = detalle.Id,
						ActivoId = detalle.ActivoId,
						Cantidad = detalle.Cantidad
					}).ToList() // Mapeo de DetallePaqueteActivo a DetallePaqueteActivoDTO
				});
			}

			return paqueteActivoResult;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<GetIdResultPaqueteActivoDTO>> ObtenerPaqueteActivoId(int id)
		{
			// Llamar al método del DAL para obtener el PaqueteActivo por su ID
			var paqueteActivo = await _paqueteActivoDAL.ObtenerPaqueteActivoId(id);

			// Verificar si el PaqueteActivo existe
			if (paqueteActivo == null)
			{
				return NotFound();
			}

			// Mapear el PaqueteActivo a su DTO, incluyendo los DetallePaqueteActivos
			var paqueteActivoDTO = new GetIdResultPaqueteActivoDTO
			{
				Id = paqueteActivo.Id,
				Correlativo = paqueteActivo.Correlativo,
				Nombre = paqueteActivo.Nombre,
				DetallePaqueteActivos = paqueteActivo.DetallePaqueteActivos.Select(detalle => new DetallePaqueteActivoDTO
				{
					Id = detalle.Id,
					ActivoId = detalle.ActivoId,
					Cantidad = detalle.Cantidad
				}).ToList() // Mapear los detalles a DetallePaqueteActivoDTO
			};

			return paqueteActivoDTO;
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Actualizar(int id, [FromBody] EditPaqueteActivoDTO editPaqueteActivoDTO)
		{
			// Obtener el PaqueteActivo existente por ID a través del DAL
			var updatePaqueteActivo = await _paqueteActivoDAL.ObtenerPaqueteActivoId(id);

			// Verificar si el PaqueteActivo existe
			if (updatePaqueteActivo == null)
			{
				return NotFound();
			}

			// Actualizar los campos del PaqueteActivo
			updatePaqueteActivo.Correlativo = editPaqueteActivoDTO.Correlativo;
			updatePaqueteActivo.Nombre = editPaqueteActivoDTO.Nombre;

			// Actualizar los DetallePaqueteActivos
			foreach (var detalle in editPaqueteActivoDTO.DetallePaqueteActivos)
			{
				var existingDetalle = updatePaqueteActivo.DetallePaqueteActivos
					.FirstOrDefault(d => d.Id == detalle.Id);

				if (existingDetalle != null)
				{
					// Si el detalle existe, actualizar sus valores
					existingDetalle.ActivoId = detalle.ActivoId;
					existingDetalle.Cantidad = detalle.Cantidad;
				}
				else
				{
					// Si el detalle no existe, agregarlo al PaqueteActivo
					updatePaqueteActivo.DetallePaqueteActivos.Add(new DetallePaqueteActivo
					{
						ActivoId = detalle.ActivoId,
						Cantidad = detalle.Cantidad
					});
				}
			}

			// Eliminar detalles que ya no están en la nueva lista
			foreach (var existingDetalle in updatePaqueteActivo.DetallePaqueteActivos.ToList())
			{
				if (!editPaqueteActivoDTO.DetallePaqueteActivos.Any(d => d.Id == existingDetalle.Id))
				{
					// Remover el detalle a través del DAL si es necesario
					updatePaqueteActivo.DetallePaqueteActivos.Remove(existingDetalle);
				}
			}

			// Guardar los cambios usando el DAL
			int result = await _paqueteActivoDAL.ActualizarPaqueteActivo(updatePaqueteActivo);

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
			var result = await _paqueteActivoDAL.EliminarPaqueteActivo(id);

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
