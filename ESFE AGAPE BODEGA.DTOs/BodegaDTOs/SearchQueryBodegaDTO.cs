using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE_AGAPE_BODEGA.DTOs.BodegaDTOs
{
    public class SearchQueryBodegaDTO
    {
        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }

        [Display(Name = "Descripcion")]
        public string? Descripcion { get; set; }

        [Display(Name = "Pagina")]
        public int Skip { get; set; }

        [Display(Name = "Cantidad")]
        public int Take { get; set; }

        public byte SendRowCount { get; set; }
    }
}
