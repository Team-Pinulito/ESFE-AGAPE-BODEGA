using ESFE_AGAPE_BODEGA.DTOs.DetalleInresoActivoDTOs;
using System.ComponentModel.DataAnnotations;

namespace ESFE_AGAPE_BODEGA.DTOs.IngresoActivoDTOs
{
	public class CrearIngresoActivoDTO
	{
		public CrearIngresoActivoDTO()
		{
			CrearDetalleIngresoActivos = new List<CrearDetalleIngresoActivoDTO>();
			Total = 0;
		}

		[Required(ErrorMessage = "El campo Correlativo es obligatorio.")]
		[MaxLength(50, ErrorMessage = "El campo Correlativo no puede tener más de 50 caracteres.")]
		public string Correlativo { get; set; }

		[Required(ErrorMessage = "El campo UsuarioId es obligatorio.")]
		public int UsuarioId { get; set; }

		[Required(ErrorMessage = "El campo FechaIngreso es obligatorio.")]
		public DateTime FechaIngreso { get; set; }

		[Required(ErrorMessage = "El campo NumeroDocRelacionado es obligatorio.")]
		public string NumeroDocRelacionado { get; set; }

		[Required(ErrorMessage = "El campo Total es obligatorio.")]
		public decimal Total { get; set; }

		// Método para validar que existan detalles
		public bool TieneDetalles()
		{
			return CrearDetalleIngresoActivos != null && CrearDetalleIngresoActivos.Any();
		}
		public List<CrearDetalleIngresoActivoDTO> CrearDetalleIngresoActivos { get; set; }

	}
}
