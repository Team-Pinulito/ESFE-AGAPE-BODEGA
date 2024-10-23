using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE_AGAPE_BODEGA.DTOs.EstanteDTOs
{
	public class SearchResultEstanteDTO
	{
		public int CountRow { get; set; }
		public List<EstanteDTO> Data { get; set; }
		public class EstanteDTO
		{
			public int Id { get; set; }

			[Display(Name = "Nombre")]
			public string Nombre { get; set; }

			[Display(Name = "Descripción")]
			public string Descripcion { get; set; }

			[Display(Name = "Bodega")]
			public int BodegaId { get; set; }

			public string BodegaNombre { get; set; }

		}
	}
}
