using ESFE_AGAPE_BODEGA.DTOs.DetalleInresoActivoDTOs;
using ESFE_AGAPE_BODEGA.DTOs.DetallePaqueteActivoDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ESFE_AGAPE_BODEGA.DTOs.IngresoActivoDTOs
{
    public class SearchResultIngresoActivoDTO
    {
        public int CountRow { get; set; }
        public List<IngresoActivoDTO> Data { get; set; }

        public class IngresoActivoDTO
        {
            public int Id { get; set; }

            [Display(Name = "Correlativo")]
            public string Correlativo { get; set; }


            public List<DetalleIngresoActivoDTO> DetalleIngresoActivoDTO { get; set; }
        }
    }
}
