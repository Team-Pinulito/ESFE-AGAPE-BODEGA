using static ESFE_AGAPE_BODEGA.DTOs.InventarioActivoDTOs.GetIdResultInventarioActivoDTO;


namespace ESFE_AGAPE_BODEGA.DTOs.KardexActivoDTOs
{
    public class GetIdResultKardexActivoDTO
    {
        public int Id { get; set; }
        public int InventarioActivoId { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public int Cantidad { get; set; }
        public byte TipoMovimiento { get; set; }
        public DateTime Saldo { get; set; }

        public InventarioActivoDTO InventarioActivo { get; set; }
        public List<InventarioActivoDTO> InventarioActivos { get; set; }
    }
}
