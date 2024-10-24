using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE_AGAPE_BODEGA.DTOs.DetalleInresoActivoDTOs
{
    public class DetalleIngresoActivoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Cantidad es obligatorio.")]
        public int Cantidad { get; set; }
        [Required(ErrorMessage = "El campo Cantidad es obligatorio.")]
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
