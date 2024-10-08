﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE_AGAPE_BODEGA.DTOs.AjustesInventarioDTOs
{
    public class SearchQueryAjusteInvetarioDTO
    {
        [Display(Name = "Fecha de Ingreso")]
        public DateTime? FechaIngreso { get; set; }

        [Display(Name = "Pagina")]
        public int Skip { get; set; }

        [Display(Name = "Cantidad Reg.")]
        public int Take { get; set; }
        /// <summary>
        /// 1 = No se cuenta los resultados de la busqueda
        /// 2= Cuenta los resultados de la busqueda
        /// </summary>
        public int SendRowCount { get; set; }
    }
}
