using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ESFE_AGAPE_BODEGA.DTOs.KardexActivoDTOs
{
    public class CreateKardexActivoDTO
    {
        [DisplayName("Usuario")]
        [Required(ErrorMessage = "El campo Usuario es obligatorio.")]
        public int InventarioActivoId { get; set; }
        [DisplayName("Fecha de Ingreso")]
        [Required(ErrorMessage = "El campo Fecha de Ingreso es obligatorio.")]
        public DateTime FechaMovimiento { get; set; }
        [Required(ErrorMessage = "El campo Correlativo es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El Correlativo debe ser mayor que cero.")]
        public int Cantidad { get; set; }
        [Required(ErrorMessage = "El campo Cantidad es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "La Cantidad debe ser mayor que cero.")]
        public byte TipoMovimiento { get; set; }
        [Required(ErrorMessage = "El campo TipoMantenimiento es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El TipoMantenimiento debe ser mayor que cero.")]
        public DateTime Saldo { get; set; }
    }
}
