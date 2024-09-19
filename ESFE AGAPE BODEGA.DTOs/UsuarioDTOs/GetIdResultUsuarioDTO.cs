using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE_AGAPE_BODEGA.DTOs.UsuarioDTOs
{
	public class GetIdResultUsuarioDTO
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

        public int RolId { get; set; }
    }
}
