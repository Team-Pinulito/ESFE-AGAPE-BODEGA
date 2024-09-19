using System.ComponentModel.DataAnnotations;

namespace ESFE_AGAPE_BODEGA.DTOs.TipoActivoDTOs
{
    public class CrearTipoActivoDTO
    {
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo Nombre no puede tener más de 50 caracteres.")]
        public string Nombre { get; set; }

        [MaxLength(255, ErrorMessage = "El campo Descripción no puede tener más de 255 caracteres.")]
        [Required(ErrorMessage = "La descripcion es obligatoria.")]
        public string Descripcion { get; set; }
    }
}
