using System.ComponentModel.DataAnnotations;

namespace ESFE_AGAPE_BODEGA.DTOs.ActivoDTOs
{
    public class SearchResultActivoDTO
    {

        public int CountRow { get; set; }
        public List<ActivoDTO> Data { get; set; }

        public class ActivoDTO
        {
            public int Id { get; set; }

            [Display(Name = "Nombre")]
            public string Nombre { get; set; }

            [Display(Name = "Descripción")]
            public string Descripcion { get; set; }

            [Display(Name = "Estante")]
            public int EstanteId { get; set; }

            [Display(Name = "Tipo Activo")]
            public int TipoActivoId { get; set; }

            [Display(Name = "Código")]
            public string Codigo { get; set; }

			[Display(Name = "Código de Barra")]

			public string CodigoBarra { get; set; }


		}
	}
}
