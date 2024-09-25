using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE_AGAPE_BODEGA.DTOs.DetalleSolicitudActivoDTOs
{
    public class CrearDetalleSolicitudActivoDTO
    {
        [Display(Name = "Activo")]
        public int ActivoId { get; set; }

        [Display(Name = "Paquete Activo")]
        public int PaqueteActivoId { get; set; }

        [Required(ErrorMessage = "El campo Cantidad es obligatorio.")]
        public int Cantidad { get; set; }

        [Display(Name = "Estado")]
        public byte Status { get; set; }
    }
}
