﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE_AGAPE_BODEGA.DTOs.DetalleInresoActivoDTOs
{
    public class CrearDetalleIngresoActivoDTO
    {
        public CrearDetalleIngresoActivoDTO()
        {
            Cantidad = 0;
            Precio = 0m;
        }

        [Required(ErrorMessage = "El campo Cantidad es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor que cero.")]
        public int Cantidad { get; set; }


        [Required(ErrorMessage = "El campo Precio es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero.")]
        public decimal Precio { get; set; }


        [Display(Name = "Activo")]
        [Required(ErrorMessage = "El campo Activo es obligatorio.")]
        public int ActivoId { get; set; }

        [Display(Name = "Estante")]

        [Required(ErrorMessage = "El campo Estante es obligatorio.")]
        public int EstanteId { get; set; }

        [Display(Name = "Bodega")]
        [Required(ErrorMessage = "El campo Bodega es obligatorio.")]
        public int BodegaId { get; set; }
    }
}
