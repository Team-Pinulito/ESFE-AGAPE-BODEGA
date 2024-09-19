using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE_AGAPE_BODEGA.DTOs.EstanteDTOs
{
	public class CrearEstanteDTO
	{
		[Required(ErrorMessage = "El campo Nombre es obligatorio.")]
		[MaxLength(50, ErrorMessage = "El campo Nombre no puede tener más de 50 caracteres.")]
		public string Nombre { get; set; }

		[MaxLength(255, ErrorMessage = "El campo Descripción no puede tener más de 255 caracteres.")]
		[Required(ErrorMessage = "La descripcion es obligatoria.")]
		public string Descripcion { get; set; }

	}
}
