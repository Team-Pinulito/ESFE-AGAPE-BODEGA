using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ESFE_AGAPE_BODEGA.DTOs.RolDTOs.BuscarRolResultadosDto;

namespace ESFE_AGAPE_BODEGA.DTOs.BodegaDTOs
{
    
    public class SearchResultBodegaDTO
    {
        public int CountRow { get; set; }

        public List<BodegaDTO> Data { get; set; }
        public class BodegaDTO
        {
            public int Id { get; set; }

            [Display(Name = "Nombre")]
            public string Nombre { get; set; }

            [Display(Name = "Descripcion")]
            public string Descripcion { get; set; }
        }
       
    }
}
