using ESFE_AGAPE_BODEGA.DTOs.DetalleSolicitudActivoDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE_AGAPE_BODEGA.DTOs.SolicitudActivoDTOs
{
    public class CrearSolicitudActivoDTO
    {
        public CrearSolicitudActivoDTO()
        {
            CrearDetalleSolicitudActivos = new List<CrearDetalleSolicitudActivoDTO>();
        }
        public int UsuarioId { get; set; }
        public int BodegueroEntregaId { get; set; }
        public int BodegueroRecibeId { get; set; }
        public string Correlativo { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaEntrega { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public DateTime FechaEntregaEsperada { get; set; }
        public DateTime FechaRecepcionEsperada { get; set; }
        public string Comentario { get; set; }

        public List<CrearDetalleSolicitudActivoDTO> CrearDetalleSolicitudActivos { get; set; }
    }
}
