using System.ComponentModel.DataAnnotations;

namespace ESFE_AGAPE_BODEGA.DTOs.KardexActivoDTOs
{
    public class SearchQueryKardexActivoDTO
    {
        [Display(Name = "Inventario Activo")]
        public int? InventarioActivoId { get; set; }

        [Display(Name = "Fecha Movimiento")]
        public DateTime? FechaMovimiento { get; set; }

        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
