﻿using System.ComponentModel.DataAnnotations;

namespace ESFE_AGAPE_BODEGA.DTOs.ActivoDTOs
{
    public class SearchQueryActivoDTO
    {
        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }

     
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
