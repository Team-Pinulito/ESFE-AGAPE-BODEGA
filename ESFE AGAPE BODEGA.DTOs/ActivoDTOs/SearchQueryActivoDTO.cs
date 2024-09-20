using System.ComponentModel.DataAnnotations;

namespace ESFE_AGAPE_BODEGA.DTOs.ActivoDTOs
{
    public class SearchQueryActivoDTO
    {
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Página")]
        public int Skip { get; set; }

        [Display(Name = "Cantidad")]
        public int Take { get; set; }

        public byte SendRowCount { get; set; }
    }
}
