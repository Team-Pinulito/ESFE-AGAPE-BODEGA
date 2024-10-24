

using Bodega_Api_Esfe_Agape.Models.EN;

namespace ESFE_AGAPE_BODEGA.API.Models.Entitys
{
    public class Bodega
    {
        
        public int Id { get; set; }

        
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public List<DetalleIngresoActivo> detalleIngresoActivos { get; set; }



        public List<Estante> estante { get; set; }
    }
}
