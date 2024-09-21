using ESFE_AGAPE_BODEGA.API.Models.Entitys;

namespace Bodega_Api_Esfe_Agape.Models.EN
{
    public class DetalleIngresoActivo
    {
        public int Id { get; set; }
        public int IngresoActivoId { get; set; }
        public int InventarioActivoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public IngresoActivo ingresoActivo { get; set; }
        public  InventarioActivo inventarioActivo { get; set; }


    }
}
