using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE_AGAPE_BODEGA.DTOs.AjustesInventarioDTOs
{
    public class CreateAjusteInvetarioDTO
    {
        [DisplayName("Usuario")]
        [Required(ErrorMessage = "El campo Usuario es obligatorio.")]
        public int UsuarioId { get; set; }
        [DisplayName("Fecha de Ingreso")]
        [Required(ErrorMessage = "El campo Fecha de Ingreso es obligatorio.")]
        public DateTime FechaIngreso { get; set; }
        [Required(ErrorMessage = "El campo Correlativo es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El Correlativo debe ser mayor que cero.")]
        public int Correlativo { get; set; }
        [Required(ErrorMessage = "El campo Cantidad es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "La Cantidad debe ser mayor que cero.")]
        public int Cantidad { get; set; }
        [Required(ErrorMessage = "El campo TipoMantenimiento es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El TipoMantenimiento debe ser mayor que cero.")]
        public int TipoMantenimiento { get; set; }
        [MaxLength(50, ErrorMessage = "El campo Comentario no puede tener más de 50 caracteres.")]
        [Required(ErrorMessage = "El campo Comentario es obligatorio.")]
        public string Comentario { get; set; }
    }
}
