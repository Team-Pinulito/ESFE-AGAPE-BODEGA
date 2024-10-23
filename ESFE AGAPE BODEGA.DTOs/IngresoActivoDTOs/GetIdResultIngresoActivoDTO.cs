using ESFE_AGAPE_BODEGA.DTOs.DetalleInresoActivoDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ESFE_AGAPE_BODEGA.DTOs.UsuarioDTOs.GetIdResultUsuarioDTO;

namespace ESFE_AGAPE_BODEGA.DTOs.IngresoActivoDTOs
{
    public class GetIdResultIngresoActivoDTO
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Correlativo { get; set; }
        public string NumeroDocRelacionado { get; set; }
        public decimal Total { get; set; }



		public List<DetalleIngresoActivoDTO> DetalleIngresoActivos { get; set; }
    }
}
