using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFE_AGAPE_BODEGA.DTOs.DetallePaqueteActivoDTOs;

namespace ESFE_AGAPE_BODEGA.DTOs.PaqueteActivoDTOs
{
	public class EditPaqueteActivoDTO
	{
		// Constructor que acepta un DTO resultado de obtener por ID
		public EditPaqueteActivoDTO(GetIdResultPaqueteActivoDTO getIdResultPaqueteActivoDTO)
		{
			Id = getIdResultPaqueteActivoDTO.Id;
			Correlativo = getIdResultPaqueteActivoDTO.Correlativo;
			Nombre = getIdResultPaqueteActivoDTO.Nombre;
			DetallePaqueteActivos = getIdResultPaqueteActivoDTO.DetallePaqueteActivos;
		}

		// Constructor por defecto
		public EditPaqueteActivoDTO()
		{
			Correlativo = string.Empty;
			Nombre = string.Empty;
		}

		public int Id { get; set; }

		[Required(ErrorMessage = "El campo Correlativo es obligatorio.")]
		[MaxLength(50, ErrorMessage = "El campo Correlativo no puede tener más de 50 caracteres.")]
		public string Correlativo { get; set; }

		[Required(ErrorMessage = "El campo Nombre es obligatorio.")]
		[MaxLength(100, ErrorMessage = "El campo Nombre no puede tener más de 100 caracteres.")]
		public string Nombre { get; set; }

		// Lista de detalles del paquete activo
		public List<DetallePaqueteActivoDTO> DetallePaqueteActivos { get; set; }
	}
}
