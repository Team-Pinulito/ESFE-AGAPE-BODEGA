using System.ComponentModel.DataAnnotations;

namespace ESFE_AGAPE_BODEGA.API.Models.Entitys
{
	public class Estante
	{
	
		public int Id { get; set; }

		public int BodegaId { get; set; }

		public string Nombre { get; set; }

		public string Descripcion { get; set; }


		public  Bodega Bodega { get; set; } 
	}
}
