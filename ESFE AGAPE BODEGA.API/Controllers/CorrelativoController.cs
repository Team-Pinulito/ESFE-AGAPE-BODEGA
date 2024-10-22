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

		

		//obtener por id
		[HttpGet("{id}")]
		public async Task<ActionResult<CorrelativoDTO>> ObtenerCorrelativo(int id)
		{
			var correlativo = await _correlativoDAL.ObtenerCorrelativoPorId(id);

			if (correlativo == null)
			{
				return NotFound();  // Devuelve un NotFoundResult
			}

			var bodegaDTO = new CorrelativoDTO
			{
				Id = correlativo.Id,
				Valor = correlativo.Valor,
				AliasInicial = correlativo.AliasInicial,
				AliasFinal = correlativo.AliasFinal,
				Entidad = correlativo.Entidad
			};

			return Ok(bodegaDTO);  // Devuelve el objeto envuelto en un OkResult
		}



		

		[HttpPost]
		public async Task<ActionResult<CorrelativoDTO>> CrearCorrelativo(CrearCorrelativoDTO crearCorrelativoDTO)
		{
			var nuevoCorrelativo = new Correlativo
			{
				Valor = crearCorrelativoDTO.Valor,
				AliasInicial = crearCorrelativoDTO.AliasInicial,
				AliasFinal = crearCorrelativoDTO.AliasFinal,
				Entidad = crearCorrelativoDTO.Entidad
			};

			var correlativoCreado = await _correlativoDAL.CrearCorrelativo(nuevoCorrelativo);

			var correlativoDTO = new CorrelativoDTO
			{
				Id = correlativoCreado.Id,
				Valor = correlativoCreado.Valor,
				AliasInicial = correlativoCreado.AliasInicial,
				AliasFinal = correlativoCreado.AliasFinal,
				Entidad = correlativoCreado.Entidad
			};

			return CreatedAtAction(nameof(ObtenerCorrelativo), new { id = correlativoDTO.Id }, correlativoDTO);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> EliminarCorrelativo(int id)
		{
			await _correlativoDAL.EliminarCorrelativo(id);
			return NoContent();
		}

		[HttpGet("ultimo/{entidad}")]
		public async Task<ActionResult<CorrelativoDTO>> ObtenerUltimoCorrelativo(string entidad)
		{
			var correlativo = await _correlativoDAL.ObtenerUltimoCorrelativoPorEntidad(entidad);

			if (correlativo == null)
			{
				return NotFound();
			}

			var correlativoDTO = new CorrelativoDTO
			{
				Id = correlativo.Id,
				Valor = correlativo.Valor,
				AliasInicial = correlativo.AliasInicial,
				AliasFinal = correlativo.AliasFinal,
				Entidad = correlativo.Entidad
			};

			return Ok(correlativoDTO);
		}

	}
}
