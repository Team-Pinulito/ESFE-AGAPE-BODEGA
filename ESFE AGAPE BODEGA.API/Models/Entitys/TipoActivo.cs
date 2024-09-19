using Bodega_Api_Esfe_Agape.Models.EN;
using System.ComponentModel.DataAnnotations;

namespace ESFE_AGAPE_BODEGA.API.Models.Entitys
{
    public class TipoActivo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public Activo activo { get; set; }

    }
}
