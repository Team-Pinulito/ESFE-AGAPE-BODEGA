using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE_AGAPE_BODEGA.DTOs.RolDTOs
{
    public class CrearRolDto
    {
        [Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Solo se permiten letras")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener mas de 100 caracteres")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "La descripcion no puede tener mas de 250 caracteres")]
        public string Descripcion { get; set; }
    }
}
