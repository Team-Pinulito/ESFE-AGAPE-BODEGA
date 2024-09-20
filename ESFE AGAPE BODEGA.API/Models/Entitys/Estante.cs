using System.ComponentModel.DataAnnotations;
using Bodega_Api_Esfe_Agape.Models.EN;

namespace ESFE_AGAPE_BODEGA.API.Models.Entitys
{
	public class Estante
	{
	
		public int Id { get; set; }

		public int BodegaId { get; set; }

		public string Nombre { get; set; }

		public string Descripcion { get; set; }

		public List<Activo> Activos { get; set; }

		//public List<InventarioActivo> InventarioActivos { get; set; }

		public Bodega Bodega { get; set; } 
	}
}
