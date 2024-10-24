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

		public ICollection<Activo> Activos { get; set; }

		public ICollection<InventarioActivo> InventarioActivos { get; set; }

        public ICollection<DetalleIngresoActivo> detalleIngresoActivos { get; set; }


        public Bodega Bodega { get; set; } 
	}
}
