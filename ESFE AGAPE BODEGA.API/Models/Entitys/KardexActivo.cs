namespace ESFE_AGAPE_BODEGA.API.Models.Entitys
{
    public class KardexActivo
    {
        public int Id { get; set; }
        public int InventarioActivoId { get; set; }
        public DateTime FechaMovimiento { get; set; } // Usa DateTime en lugar de LocalDateTime
        public int Cantidad { get; set; }
        public byte TipoMovimiento { get; set; }
        public DateTime Saldo { get; set; } // Usa DateTime en lugar de LocalDate

        // Relación con InventarioActivo
        public InventarioActivo InventarioActivo { get; set; }
    }
}
