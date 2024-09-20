using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ESFE_AGAPE_BODEGA.DTOs.RolDTOs.BuscarRolResultadosDto;

namespace ESFE_AGAPE_BODEGA.DTOs.UsuarioDTOs
{
	public class GetIdResultUsuarioDTO
	{

        public int CountRow { get; set; }

        public List<UsuarioDTO> Data { get; set; }

        public class UsuarioDTO
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Email { get; set; }
            public string Telefono { get; set; }
            public string DUI { get; set; }
            public string Password { get; set; }
            public string Codigo { get; set; }
            public string Direccion { get; set; }
            [Display(Name = "Rol")]
            public int RolId { get; set; }
        }
    }
}
