using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE_AGAPE_BODEGA.DTOs.UsuarioDTOs
{
    public class LoginUsuarioDTO
    {
        [Required(ErrorMessage = "El campo DUI es obligatorio")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "El DUI debe tener exactamente 9 dígitos.")]
        public string DUI { get; set; }
        [Required(ErrorMessage = "El campo Password es obligatorio")]
        public string Password { get; set; }
    }
}
