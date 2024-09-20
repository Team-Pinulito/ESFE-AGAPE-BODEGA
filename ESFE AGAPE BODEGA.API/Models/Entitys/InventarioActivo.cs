using Bodega_Api_Esfe_Agape.Models.EN;
using System.ComponentModel.DataAnnotations;

namespace ESFE_AGAPE_BODEGA.API.Models.Entitys
{
    public class InventarioActivo
    {
        public int Id { get; init; }
        [Display(Name = "Activo")]
        public int ActivoId { get; init; }
        [Display(Name = "Estante")]
        public int EstanteId { get; init; }
        public int Existencia { get; init; }

        public Activo Activo { get; set; }

        public Estante Estante { get; set; }

        public List<DetalleIngresoActivo> DetalleIngresoActivos { get; set; }

        //  public List<KardexActivo> KardexActivos { get; set; }

        public List<AjusteInventario> AjuesteInventarios { get; set; }
    }
}
