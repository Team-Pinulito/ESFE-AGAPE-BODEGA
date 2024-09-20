using ESFE_AGAPE_BODEGA.API.Models.Entitys;

namespace Bodega_Api_Esfe_Agape.Models.EN
{
    public class Activo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int EstanteId { get; set; }
        public int TipoActivoId { get; set; }
        public string Codigo { get; set; }
        public string CodigoBarra { get; set; }

        public Estante estante { get; set; }

        public TipoActivo tipoactivo { get; set; }

        public List<DetallePaqueteActivo> detallePaqueteActivos { get; set; }

        public List<DetalleSolicitudActivo> detalleSolicitudActivos { get; set; }

        public List<InventarioActivo> InventarioActivos { get; set; }
    }
}
