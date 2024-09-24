namespace ESFE_AGAPE_BODEGA.DTOs.KardexActivoDTOs
{
    public class SearchResultKardexActivoDTO
    {
        public int CountRow { get; set; }
        public List<KardexActivoDTO> Data { get; set; }

        public class KardexActivoDTO
        {
            public int Ids { get; set; }
            public int InventarioActivo { get; set; }
            public DateTime FechaMovimiento { get; set; }
            public int Cantidad { get; set; }
            public byte TipoMovimiento { get; set; }
            public DateTime Saldo { get; set; }
        }

    }
}
