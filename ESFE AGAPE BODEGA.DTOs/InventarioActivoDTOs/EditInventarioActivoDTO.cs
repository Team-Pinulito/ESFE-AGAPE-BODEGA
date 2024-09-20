using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE_AGAPE_BODEGA.DTOs.InventarioActivoDTOs
{
    public class EditInventarioActivoDTO
    {
        public EditInventarioActivoDTO(GetIdResultInventarioActivoDTO.InventarioActivoDTO getIdResultInventarioActivoDTO)
        {
            Id = getIdResultInventarioActivoDTO.Id;
            ActivoId = getIdResultInventarioActivoDTO.ActivoId;
            EstanteId = getIdResultInventarioActivoDTO.EstanteId;
            Existencia = getIdResultInventarioActivoDTO.Existencia;
        }

        public EditInventarioActivoDTO()
        {
            ActivoId = 0;
            EstanteId = 0;
            Existencia = 0;
        }

        public int Id { get; set; }
        [Display(Name = "Activo")]
        [Required(ErrorMessage = "El campo Activo es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El Activo debe ser mayor que cero.")]
        public int ActivoId { get; init; }

        [Display(Name = "Estante")]
        [Required(ErrorMessage = "El campo Estante es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El Estante debe ser mayor que cero.")]
        public int EstanteId { get; init; }

        [Required(ErrorMessage = "El campo Existencia es obligatorio.")]
        [Range(0, int.MaxValue, ErrorMessage = "La Existencia no puede ser negativa.")]
        public int Existencia { get; init; }


    }
}
