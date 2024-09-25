using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ESFE_AGAPE_BODEGA.DTOs.KardexActivoDTOs
{
    public class CreateKardexActivoDTO
    {
        [DisplayName("Usuario")]
        [Required(ErrorMessage = "El campo InventarioActivoId es obligatorio.")]
        public int InventarioActivoId { get; set; }
        [DisplayName("Fecha de Movimiento")]
        [Required(ErrorMessage = "El campo Fecha de Movimiento es obligatorio.")]
        public DateTime FechaMovimiento { get; set; }
        [Required(ErrorMessage = "El campo Cantidad es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El Cantidad debe ser mayor que cero.")]
        public int Cantidad { get; set; }
        [Required(ErrorMessage = "El campo TipoMovimiento es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "La TipoMovimiento debe ser mayor que cero.")]
        public byte TipoMovimiento { get; set; }
        [Required(ErrorMessage = "El campo Saldo es obligatorio.")]
        public DateTime Saldo { get; set; }
    }
}
