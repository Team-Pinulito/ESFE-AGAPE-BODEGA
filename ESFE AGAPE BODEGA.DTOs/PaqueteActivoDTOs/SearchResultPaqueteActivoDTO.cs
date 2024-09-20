using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFE_AGAPE_BODEGA.DTOs.DetallePaqueteActivoDTOs;

namespace ESFE_AGAPE_BODEGA.DTOs.PaqueteActivoDTOs
{
	public class SearchResultPaqueteActivoDTO
	{
		public int CountRow { get; set; }
		public List<PaqueteActivoDTO> Data { get; set; }

		public class PaqueteActivoDTO
		{
			public int Id { get; set; }

			[Display(Name = "Correlativo")]
			public string Correlativo { get; set; }

			[Display(Name = "Nombre")]
			public string Nombre { get; set; }

			public List<DetallePaqueteActivoDTO> DetallePaqueteActivos { get; set; }
		}
	}
}
