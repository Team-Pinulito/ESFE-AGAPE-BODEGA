using ESFE_AGAPE_BODEGA.API.Models.DAL;
using ESFE_AGAPE_BODEGA.API.Models.Entitys;
using ESFE_AGAPE_BODEGA.DTOs.BodegaDTOs;
using ESFE_AGAPE_BODEGA.DTOs.CorrelativoDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ESFE_AGAPE_BODEGA.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class CorrelativoController : ControllerBase
	{
		private readonly CorrelativoDAL _correlativoDAL;

		public CorrelativoController(CorrelativoDAL correlativoDAL)
		{
			_correlativoDAL = correlativoDAL;
		}




		[HttpGet("siguiente/{entidad}")]
		public async Task<ActionResult<string>> ObtenerSiguienteCorrelativo(string entidad)
		{
			try
			{
				var correlativo = await _correlativoDAL.ObtenerSiguienteCorrelativo(entidad);

				if (correlativo == null)
					return NotFound($"No se pudo generar el correlativo para la entidad: {entidad}");

				return Ok(correlativo);
			}
			catch (Exception ex)
			{
				return BadRequest($"Error al obtener el correlativo: {ex.Message}");
			}
		}

	}
}
