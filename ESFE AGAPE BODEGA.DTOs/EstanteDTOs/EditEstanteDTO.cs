using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE_AGAPE_BODEGA.DTOs.EstanteDTOs
{
	public class EditEstanteDTO
	{
		public EditEstanteDTO(GetIdResultEstanteDTO getIdResultEstanteDTO)
		{
			Id = getIdResultEstanteDTO.Id;
			Nombre = getIdResultEstanteDTO.Nombre;
			Descripcion = getIdResultEstanteDTO.Descripcion;
			BodegaId = getIdResultEstanteDTO.BodegaId;
		}
		public EditEstanteDTO()
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

		[Display(Name = "Bodega")]
		public int BodegaId { get; set; }
	}
}
