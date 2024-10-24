﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE_AGAPE_BODEGA.DTOs.IngresoActivoDTOs
{
    public class SearchQueryIngresoActivoDTO
    {

        [Display(Name = "Correlativo")]
        public string? Correlativo_Like { get; set; }
        [Display(Name = "Fecha Ingreso")]
        public DateTime? Fecha_Like { get; set; }
        
        [Display(Name = "NumeroDocRelacionado")]
        public string? NumeroDocRelacionado_Like { get; set; }

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
}
