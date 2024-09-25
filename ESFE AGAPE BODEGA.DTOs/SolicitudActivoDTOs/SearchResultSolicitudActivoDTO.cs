using ESFE_AGAPE_BODEGA.DTOs.DetalleSolicitudActivoDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE_AGAPE_BODEGA.DTOs.SolicitudActivoDTOs
{
    public class SearchResultSolicitudActivoDTO
    {
        public int CountRow { get; set; }
        public List<SolicitudActivoDTO> Data { get; set; }

        public class SolicitudActivoDTO
        {
            public int Id { get; set; }

            [Display(Name = "Usuario")]
            public int UsuarioId { get; set; }

            [Display(Name = "Bodeguero Entrega")]
            public int BodegueroEntregaId { get; set; }

            [Display(Name = "Bodeguero Recibe")]
            public int BodegueroRecibeId { get; set; }

            [Display(Name = "Correlativo")]
            public string Correlativo { get; set; }

            [Display(Name = "Fecha")]
            public DateTime Fecha { get; set; }

            [Display(Name = "Fecha Entrega")]
            public DateTime FechaEntrega { get; set; }

            [Display(Name = "Fecha Recepcion")]
            public DateTime FechaRecepcion { get; set; }

            [Display(Name = "Fecha Entrega Esperada")]
            public DateTime FechaEntregaEsperada { get; set; }

            [Display(Name = "Fecha Recepcion Esperada")]
            public DateTime FechaRecepcionEsperada { get; set; }

            [Display(Name = "Comentario")]
            public string Comentario { get; set; }

            public List<DetalleSolicitudActivoDTO> DetalleSolicitudActivoDTOs { get; set; }
        }
    }
}
