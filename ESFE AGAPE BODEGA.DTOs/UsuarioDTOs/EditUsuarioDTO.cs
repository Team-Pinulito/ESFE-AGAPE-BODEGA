using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE_AGAPE_BODEGA.DTOs.UsuarioDTOs
{
	public class EditUsuarioDTO
	{
		public EditUsuarioDTO(GetIdResultUsuarioDTO.UsuarioDTO getIdResultUsuarioDTO)
		{
			Id = getIdResultUsuarioDTO.Id;
            Nombre = getIdResultUsuarioDTO.Nombre;
            Apellido = getIdResultUsuarioDTO.Apellido;
            Email = getIdResultUsuarioDTO.Email;
            Telefono = getIdResultUsuarioDTO.Telefono;
            DUI = getIdResultUsuarioDTO.DUI;
            Password = getIdResultUsuarioDTO.Password;
            Codigo = getIdResultUsuarioDTO.Codigo;
            Direccion = getIdResultUsuarioDTO.Direccion;
            RolId = getIdResultUsuarioDTO.RolId;
        }
		public EditUsuarioDTO()
		{
			Nombre = string.Empty;
            Apellido = string.Empty;
            Email = string.Empty;
            Telefono = string.Empty;
            DUI = string.Empty;
            Password = string.Empty;
            Codigo = string.Empty;
            Direccion = string.Empty;
            RolId = 0;
        }

		public int Id { get; set; }

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
        public string Password { get; set; }

        [Required(ErrorMessage = "El campo Codigo es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo Codigo no puede tener más de 50 caracteres.")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El campo Direccion es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo Direccion no puede tener más de 50 caracteres.")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo RolId es obligatorio.")]
        [Display(Name = "Rol")]
        public int RolId { get; set; }
    }
}
