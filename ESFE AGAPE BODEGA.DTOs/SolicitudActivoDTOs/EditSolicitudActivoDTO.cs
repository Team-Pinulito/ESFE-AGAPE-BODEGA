using ESFE_AGAPE_BODEGA.DTOs.DetallePaqueteActivoDTOs;
using ESFE_AGAPE_BODEGA.DTOs.DetalleSolicitudActivoDTOs;
using ESFE_AGAPE_BODEGA.DTOs.PaqueteActivoDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE_AGAPE_BODEGA.DTOs.SolicitudActivoDTOs
{
    public class EditSolicitudActivoDTO
    {
        // Constructor que acepta un DTO resultado de obtener por ID
        public EditSolicitudActivoDTO(GetIdResultSolicitudActivoDTO getIdResultSolicitudActivoDTO)
        {
            Id = getIdResultSolicitudActivoDTO.Id;
            UsuarioId = getIdResultSolicitudActivoDTO.UsuarioId;
            BodegueroEntregaId = getIdResultSolicitudActivoDTO.BodegueroEntregaId;
            BodegueroRecibeId = getIdResultSolicitudActivoDTO.BodegueroRecibeId;
            Correlativo = getIdResultSolicitudActivoDTO.Correlativo;
            Fecha = getIdResultSolicitudActivoDTO.Fecha;
            FechaEntrega = getIdResultSolicitudActivoDTO.FechaEntrega;
            FechaRecepcion = getIdResultSolicitudActivoDTO.FechaRecepcion;
            FechaEntregaEsperada = getIdResultSolicitudActivoDTO.FechaEntregaEsperada;
            FechaRecepcionEsperada = getIdResultSolicitudActivoDTO.FechaRecepcionEsperada;
            Comentario = getIdResultSolicitudActivoDTO.Comentario;
            DetalleSolicitudActivoDTOs = getIdResultSolicitudActivoDTO.DetalleSolicitudActivoDTOs;
        }

        // Constructor por defecto
        public EditSolicitudActivoDTO()
        {

        }

        public int Id { get; set; }
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

        public List<DetalleSolicitudActivoDTO> DetalleSolicitudActivoDTOs { get; set; }
    }
}
