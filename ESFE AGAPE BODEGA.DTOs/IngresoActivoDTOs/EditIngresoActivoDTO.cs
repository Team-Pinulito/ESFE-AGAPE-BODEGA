using ESFE_AGAPE_BODEGA.DTOs.DetalleInresoActivoDTOs;
using System.ComponentModel.DataAnnotations;

namespace ESFE_AGAPE_BODEGA.DTOs.IngresoActivoDTOs
{
	public class EditIngresoActivoDTO
	{
		public EditIngresoActivoDTO(GetIdResultIngresoActivoDTO getIdResultIngresoActivoDTO)
		{
			if (getIdResultIngresoActivoDTO == null)
				throw new ArgumentNullException(nameof(getIdResultIngresoActivoDTO));

			Id = getIdResultIngresoActivoDTO.Id;
			Correlativo = getIdResultIngresoActivoDTO.Correlativo;
			UsuarioId = getIdResultIngresoActivoDTO.UsuarioId;
			FechaIngreso = getIdResultIngresoActivoDTO.FechaIngreso;
			NumeroDocRelacionado = getIdResultIngresoActivoDTO.NumeroDocRelacionado;
			Total = getIdResultIngresoActivoDTO.Total;
			DetalleIngresoActivos = getIdResultIngresoActivoDTO.DetalleIngresoActivos ?? new List<DetalleIngresoActivoDTO>();
		}

		public EditIngresoActivoDTO()
		{
			Correlativo = string.Empty;
            NumeroDocRelacionado = string.Empty;

        }

		public int Id { get; set; }

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

		public bool TieneDetalles()
		{
			return DetalleIngresoActivos != null && DetalleIngresoActivos.Any();
		}

		public List<DetalleIngresoActivoDTO> DetalleIngresoActivos { get; set; }
	}
}