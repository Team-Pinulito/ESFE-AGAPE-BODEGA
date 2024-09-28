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
        public string? Nombre_Like { get; set; }

        [Display(Name = "Pagina")]
        public int Skip { get; set; }

        [Display(Name = "Cantidad Reg.")]
        public int Take { get; set; }
        /// <summary>
        /// 1 = No se cuenta los resultados de la busqueda
        /// 2= Cuenta los resultados de la busqueda
        /// </summary>
        public byte SendRowCount { get; set; }
    }
