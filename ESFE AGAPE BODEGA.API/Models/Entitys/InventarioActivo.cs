using Bodega_Api_Esfe_Agape.Models.EN;

namespace ESFE_AGAPE_BODEGA.API.Models.Entitys
{
    public class InventarioActivo
    {
        public int Id { get; init; }
        public Activo ActivoId { get; init; }
        public Estante EstanteId { get; init; }
        public int Existencia { get; init; }

        public List<DetalleIngresoActivo> DetalleIngresoActivos { get; set; }

        //  public List<KardexActivo> KardexActivos { get; set; }

        public List<AjusteInventario> AjuesteInventarios { get; set; }
    }
}
