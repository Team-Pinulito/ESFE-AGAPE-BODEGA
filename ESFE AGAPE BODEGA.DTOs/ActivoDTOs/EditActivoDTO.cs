using System.ComponentModel.DataAnnotations;

namespace ESFE_AGAPE_BODEGA.DTOs.ActivoDTOs
{
    public class EditActivoDTO
    {
        public EditActivoDTO(GetIdResultActivoDTO.ActivoDTO GetIdResultActivoDTO)
        {
            Id = GetIdResultActivoDTO.Id;
            Nombre = GetIdResultActivoDTO.Nombre;
            Descripcion = GetIdResultActivoDTO.Descripcion;
            EstanteId = GetIdResultActivoDTO.EstanteId;
            TipoActivoId = GetIdResultActivoDTO.TipoActivoId;
            Codigo = GetIdResultActivoDTO.Codigo;
            CodigoBarra = GetIdResultActivoDTO.CodigoBarra;
        }

        public EditActivoDTO()
        {
            Nombre = string.Empty;
            Descripcion = string.Empty;
            Codigo = string.Empty;
            CodigoBarra = string.Empty;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo Nombre no puede tener más de 50 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Descripción es obligatorio.")]
        [MaxLength(255, ErrorMessage = "El campo Descripción no puede tener más de 255 caracteres.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo EstanteId es obligatorio.")]
        public int EstanteId { get; set; }

        [Required(ErrorMessage = "El campo TipoActivoId es obligatorio.")]
        public int TipoActivoId { get; set; }

        [MaxLength(50, ErrorMessage = "El campo Código no puede tener más de 50 caracteres.")]
        public string Codigo { get; set; }

        [MaxLength(50, ErrorMessage = "El campo Código de Barra no puede tener más de 50 caracteres.")]
        public string CodigoBarra { get; set; }
    }
}
