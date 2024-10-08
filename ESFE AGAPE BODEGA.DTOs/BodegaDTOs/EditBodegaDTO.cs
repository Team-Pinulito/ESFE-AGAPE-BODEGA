﻿
using System.ComponentModel.DataAnnotations;

namespace ESFE_AGAPE_BODEGA.DTOs.BodegaDTOs
{
    public class EditBodegaDTO
    {
        public EditBodegaDTO(GetIdResultBodegaDTO bodegaDTO)
        {
            Id = bodegaDTO.Id;
            Nombre = bodegaDTO.Nombre;
            Descripcion = bodegaDTO.Descripcion;
        }

        public EditBodegaDTO()
        {
            Nombre = string.Empty;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo Nombre no puede tener más de 100 caracteres.")]
        public string Nombre { get; set; }

        [MaxLength(255, ErrorMessage = "El campo Descripción no puede tener más de 255 caracteres.")]
        [Required(ErrorMessage = "La descripcion es obligatoria.")]
        public string Descripcion { get; set; }
    }
}
