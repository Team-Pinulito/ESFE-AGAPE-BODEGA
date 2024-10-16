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
        [Required(ErrorMessage = "El campo Cantidad es obligatorio.")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El campo Cantidad es obligatorio.")]
        public decimal Precio { get; set; }
    }
}
