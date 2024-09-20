using ESFE_AGAPE_BODEGA.DTOs.IngresoActivoDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE_AGAPE_BODEGA.DTOs.IngresoActivoDTOs
{
    public class EditIngresoActivoDTO
    {
        public EditIngresoActivoDTO(GetIdResultIngresoActivoDTO getIdResultIngresoActivoDTO)
        {
            Id = getIdResultIngresoActivoDTO.Id;
            Correlativo = getIdResultIngresoActivoDTO.Correlativo;
            Nombre = getIdResultPaqueteActivoDTO.Nombre;
            DetallePaqueteActivos = getIdResultPaqueteActivoDTO.DetallePaqueteActivos;
        }
    }
}
