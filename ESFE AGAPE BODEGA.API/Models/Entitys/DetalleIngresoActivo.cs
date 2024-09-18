namespace Bodega_Api_Esfe_Agape.Models.EN
{
    public class DetalleIngresoActivo
    {
        public int Id { get; set; }
        public int ingresoActivoId { get; set; }
        public int inventarioActivoId { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }

        public IngresoActivo ingresoActivo { get; set; }
        //public InventarioActivo inventarioactivo { get; set; }
    }
}
