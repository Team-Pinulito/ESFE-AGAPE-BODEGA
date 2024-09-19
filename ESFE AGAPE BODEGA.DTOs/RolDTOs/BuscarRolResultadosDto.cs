using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE_AGAPE_BODEGA.DTOs.RolDTOs
{
    public class BuscarRolResultadosDto
    {

        public int CountRow { get; set; }

        public List<RolDto> Data { get; set; }

        public class RolDto
        {
            public int Id { get; set; }

            [Display(Name = "Nombre")]
            public string Nombre { get; set; }

            [Display(Name = "Descripcion")]
            public string Descripcion { get; set; }
        }
    }
}
