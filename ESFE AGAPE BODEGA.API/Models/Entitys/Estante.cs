using System.ComponentModel.DataAnnotations;

namespace ESFE_AGAPE_BODEGA.API.Models.Entitys
{
	public class Estante
	{
	
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Bodega es obligatorio")]
		[Display(Name = "Bodega")]
		public int BodegaId { get; set; }

		[Required(ErrorMessage = "El nombre es obligatorio.")]
		public string Nombre { get; set; }

		[Required(ErrorMessage = "La descripcion es obligatoria.")]
		public string Descripcion { get; set; }


		public virtual Bodega Bodega { get; set; } = null!;
	}
}
