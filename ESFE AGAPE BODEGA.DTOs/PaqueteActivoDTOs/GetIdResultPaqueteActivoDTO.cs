using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFE_AGAPE_BODEGA.DTOs.DetallePaqueteActivoDTOs;

namespace ESFE_AGAPE_BODEGA.DTOs.PaqueteActivoDTOs
{
	public class GetIdResultPaqueteActivoDTO
	{
		public int Id { get; set; }

		public string Correlativo { get; set; }

		public string Nombre { get; set; }

		public List<DetallePaqueteActivoDTO> DetallePaqueteActivos { get; set; }
	}
}
