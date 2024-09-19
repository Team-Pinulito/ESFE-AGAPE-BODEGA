using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE_AGAPE_BODEGA.DTOs.EstanteDTOs
{
	public class GetIdResultEstanteDTO
	{
		public int Id { get; set; }

		public string Nombre { get; set; }

		public string Descripcion { get; set; }

		[Display(Name = "Bodega")]
		public int BodegaId { get; set; }
	}
}
