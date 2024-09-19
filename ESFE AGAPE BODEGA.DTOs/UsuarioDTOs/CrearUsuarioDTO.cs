using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE_AGAPE_BODEGA.DTOs.UsuarioDTOs
{
	public class CrearUsuarioDTO
	{
            [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
            [MaxLength(50, ErrorMessage = "El campo Nombre no puede tener más de 50 caracteres.")]
            public string Nombre { get; set; }

            [Required(ErrorMessage = "El campo Apellido es obligatorio.")]
            [MaxLength(50, ErrorMessage = "El campo Apellido no puede tener más de 50 caracteres.")]
            public string Apellido { get; set; }

            [Required(ErrorMessage = "El campo Email es obligatorio.")]
            [MaxLength(50, ErrorMessage = "El campo Email no puede tener más de 50 caracteres.")]
            public string Email { get; set; }

            [Required(ErrorMessage = "El campo Telefono es obligatorio.")]
            [MaxLength(50, ErrorMessage = "El campo Telefono no puede tener más de 50 caracteres.")]
            public string Telefono { get; set; }

            [Required(ErrorMessage = "El campo DUI es obligatorio.")]
            [MaxLength(50, ErrorMessage = "El campo DUI no puede tener más de 50 caracteres.")]
            public string DUI { get; set; }

            [Required(ErrorMessage = "El campo Password es obligatorio.")]
            [MaxLength(50, ErrorMessage = "El campo Password no puede tener más de 50 caracteres.")]
            public string Password { get; set; }

            [Required(ErrorMessage = "El campo Codigo es obligatorio.")]
            [MaxLength(50, ErrorMessage = "El campo Codigo no puede tener más de 50 caracteres.")]
            public string Codigo { get; set; }

            [Required(ErrorMessage = "El campo Direccion es obligatorio.")]
            [MaxLength(50, ErrorMessage = "El campo Direccion no puede tener más de 50 caracteres.")]
            public string Direccion { get; set; }

            [Required(ErrorMessage = "El campo RolId es obligatorio.")]
            public int RolId { get; set; }
        
    }
}
