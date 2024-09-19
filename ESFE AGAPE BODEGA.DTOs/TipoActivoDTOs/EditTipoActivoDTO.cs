using System.ComponentModel.DataAnnotations;

namespace ESFE_AGAPE_BODEGA.DTOs.TipoActivoDTOs
{
    public class EditTipoActivoDTO
    {
        public EditTipoActivoDTO(GetIdResultTipoActivoDTO getIdResultTipoActivo)
        {
            Id = getIdResultTipoActivo.Id;
            Nombre = getIdResultTipoActivo.Nombre;
            Descripcion = getIdResultTipoActivo.Descripcion;
        }

        public EditTipoActivoDTO()
        {
            Nombre = string.Empty;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo Nombre no puede tener más de 100 caracteres.")]
        public string Nombre { get; set; }

        [MaxLength(255, ErrorMessage = "El campo Descripción no puede tener más de 255 caracteres.")]
        [Required(ErrorMessage = "La descripcion es obligatoria.")]
        public string Descripcion { get; set; }
    }
}
