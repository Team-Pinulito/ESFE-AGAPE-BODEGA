using ESFE_AGAPE_BODEGA.DTOs.DetalleInresoActivoDTOs;
using System.ComponentModel.DataAnnotations;


namespace ESFE_AGAPE_BODEGA.DTOs.IngresoActivoDTOs
{
	public class SearchResultIngresoActivoDTO
	{
		public int CountRow { get; set; }
		public List<IngresoActivoDTO> Data { get; set; }

		public class IngresoActivoDTO
		{
			public int Id { get; set; }

			[Display(Name = "Correlativo")]
			public string Correlativo { get; set; }

			[Display(Name = "Fecha de Ingreso")]
			public DateTime FechaIngreso { get; set; }


			public List<DetalleIngresoActivoDTO> DetalleIngresoActivoDTO { get; set; }
		}
	}
}
