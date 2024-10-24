using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE_AGAPE_BODEGA.DTOs.DetallePaqueteActivoDTOs
{
	public class CrearDetallePaqueteActivoDTO
	{

		[Display(Name = "Activo")]
		[Required(ErrorMessage = "El campo Activo es obligatorio.")]
		public int ActivoId { get; set; }

		[Required(ErrorMessage = "El campo Cantidad es obligatorio.")]
		public int Cantidad { get; set; }
	}
}
