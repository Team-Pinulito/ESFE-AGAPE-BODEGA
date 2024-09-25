using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE_AGAPE_BODEGA.DTOs.SolicitudActivoDTOs
{
    public class SearchQuerySolicitudActivoDTO
    {
        [Display(Name = "Correlativo")]
        public string? Correlativo_Like { get; set; }

        [Display(Name = "Usuario")]
        public int? UsuarioId_Like { get; set; }

        [Display(Name = "Pagina")]
        public int Skip { get; set; }

        [Display(Name = "Cantidad Reg.")]
        public int Take { get; set; }

        public byte SendRowCount { get; set; }
    }
}
