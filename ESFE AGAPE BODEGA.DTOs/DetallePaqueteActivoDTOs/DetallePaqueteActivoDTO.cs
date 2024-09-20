using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE_AGAPE_BODEGA.DTOs.DetallePaqueteActivoDTOs
{
	public class DetallePaqueteActivoDTO
	{

		public int Id { get; set; }

		[Display(Name = "Activo")]
		[Required(ErrorMessage = "El campo ActivoId es obligatorio.")]
		public int ActivoId { get; set; }

		[Required(ErrorMessage = "El campo Cantidad es obligatorio.")]
		public int Cantidad { get; set; }
	}
}
}
