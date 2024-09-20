using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFE_AGAPE_BODEGA.DTOs.DetallePaqueteActivoDTOs;

namespace ESFE_AGAPE_BODEGA.DTOs.PaqueteActivoDTOs
{
	public class CrearPaqueteActivoDTO
	{
		public CrearPaqueteActivoDTO()
		{
			DetallePaqueteActivos = new List<DetallePaqueteActivoDTO>();
		}

		[Required(ErrorMessage = "El campo Correlativo es obligatorio.")]
		[MaxLength(50, ErrorMessage = "El campo Correlativo no puede tener más de 50 caracteres.")]
		public string Correlativo { get; set; }

		[Required(ErrorMessage = "El campo Nombre es obligatorio.")]
		[MaxLength(100, ErrorMessage = "El campo Nombre no puede tener más de 100 caracteres.")]
		public string Nombre { get; set; }

		public List<DetallePaqueteActivoDTO> DetallePaqueteActivos { get; set; }

	}

	
		
}
