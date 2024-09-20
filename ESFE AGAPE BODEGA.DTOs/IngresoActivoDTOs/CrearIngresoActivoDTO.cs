using ESFE_AGAPE_BODEGA.DTOs.DetalleIngresoActivo;
using ESFE_AGAPE_BODEGA.DTOs.DetallePaqueteActivoDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE_AGAPE_BODEGA.DTOs.IngresoActivoDTOs
{
    public class CrearIngresoActivoDTO
    {
        public CrearIngresoActivoDTO()
        {
           CrearDetalleIngresoActivoDTOs = new List<CrearDetalleIngresoActivoDTO>();
        }

        [Required(ErrorMessage = "El campo Correlativo es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo Correlativo no puede tener más de 50 caracteres.")]
        public string Correlativo { get; set; }
        [Required(ErrorMessage = "El campo Correlativo es obligatorio.")]
        public int UsuarioId { get; set; }
        [Required(ErrorMessage = "El campo Correlativo es obligatorio.")]
        public DateTime FechaIngreso { get; set; }
        [Required(ErrorMessage = "El campo Correlativo es obligatorio.")]
        public string NumeroDocRelacionado { get; set; }
        [Required(ErrorMessage = "El campo Correlativo es obligatorio.")]
        public decimal Total { get; set; }


        public List<CrearDetalleIngresoActivoDTO> CrearDetalleIngresoActivoDTOs { get; set; }
    }
}
