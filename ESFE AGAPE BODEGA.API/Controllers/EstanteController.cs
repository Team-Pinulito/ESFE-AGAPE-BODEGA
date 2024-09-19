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
	public class EstanteController : Controller
	{
		private readonly EstanteDAL _estanteDAL;
		public EstanteController(EstanteDAL estanteDAL)
		{
			_estanteDAL = estanteDAL;
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
	}
}
