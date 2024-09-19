using ESFE_AGAPE_BODEGA.API.Models.DAL;
using ESFE_AGAPE_BODEGA.API.Models.Entitys;
using ESFE_AGAPE_BODEGA.DTOs.EstanteDTOs;
using ESFE_AGAPE_BODEGA.DTOs.RolDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESFE_AGAPE_BODEGA.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EstanteController : ControllerBase
	{
		private readonly EstanteDAL _estanteDAL;
		public EstanteController(EstanteDAL estanteDAL)
		{
			_estanteDAL = estanteDAL;
		}

		//obtener todos
		[HttpGet]
		public async Task<List<SearchResultEstanteDTO.EstanteDTO>> ObtenerTodos()
		{
			var roles = await _estanteDAL.ObtenerEstantes();

			var rolesDto = roles.Select(r => new SearchResultEstanteDTO.EstanteDTO
			{
				Id = r.Id,
				Nombre = r.Nombre,
				Descripcion = r.Descripcion,
				BodegaId = r.BodegaId
			}).ToList();

			return rolesDto;
		}


		//obtener todos paginados
		[HttpPost("buscar")]
		public async Task<SearchResultEstanteDTO> Buscar(SearchQueryEstanteDTO estanteDTO)
		{

			var estante = new Estante
			{
				Nombre = estanteDTO.Nombre_Like != null ? estanteDTO.Nombre_Like : string.Empty,
			};

			var estantes = new List<Estante>();
			var countRow = 0;

			if (estanteDTO.SendRowCount == 2)
			{
				estantes = await _estanteDAL.BuscarPaginado(estante, skip: estanteDTO.Skip, take: estanteDTO.Take);
				if (estantes.Count > 0)
				{
					countRow = await _estanteDAL.ContarResultEstante(estante);
				}
			}
			else
			{
				estantes = await _estanteDAL.BuscarPaginado(estante, skip: estanteDTO.Skip, take: estanteDTO.Take);
			}

			var estanteResult = new SearchResultEstanteDTO
			{
				Data = new List<SearchResultEstanteDTO.EstanteDTO>(),
				CountRow = countRow
			};

			foreach (var item in estantes)
			{
				estanteResult.Data.Add(new SearchResultEstanteDTO.EstanteDTO
				{
					Id = item.Id,
					Nombre = item.Nombre,
					Descripcion = item.Descripcion,
					BodegaId = item.BodegaId
				});
			}

			return estanteResult;

		}

		[HttpGet("{id}")]
		public async Task<ActionResult<GetIdResultEstanteDTO>> ObtenerEstanteId(int id)
		{
			var estante = await _estanteDAL.ObtenerEstanteId(id);

			if (estante == null)
			{
				return NotFound(); 
			}

			var estanteDTO = new GetIdResultEstanteDTO
			{
				Id = estante.Id,
				Nombre = estante.Nombre,
				Descripcion = estante.Descripcion,
				BodegaId = estante.BodegaId
			};

			return estanteDTO;
		}



		[HttpPost]
		public async Task<IActionResult> Crear([FromBody] CrearEstanteDTO estanteDTO)
		{
			var estante = new Estante
			{
				Nombre = estanteDTO.Nombre,
				Descripcion = estanteDTO.Descripcion,
				BodegaId = estanteDTO.BodegaId
			};

			int result = await _estanteDAL.CrearEstante(estante);

			if (result > 0)
			{
				return Ok(result);
			}
			else
			{
				return StatusCode(500);
			}


		}

		//actualizar
		[HttpPut("{id}")]
		public async Task<IActionResult> Actualizar(int id, [FromBody] EditEstanteDTO editEstanteDTO)
		{
			var updateEstante = await _estanteDAL.ObtenerEstanteId(id);

			if (updateEstante == null)
			{
				return NotFound();
			}

			updateEstante.Nombre = editEstanteDTO.Nombre;
			updateEstante.Descripcion = editEstanteDTO.Descripcion;
			updateEstante.BodegaId = editEstanteDTO.BodegaId;

			int result = await _estanteDAL.ActualizarEstante(updateEstante);

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
			var result = await _estanteDAL.EliminarEstante(id);

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
