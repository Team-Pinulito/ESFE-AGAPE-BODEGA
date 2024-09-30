using System.ComponentModel.DataAnnotations;

namespace ESFE_AGAPE_BODEGA.DTOs.TipoActivoDTOs
{
    public class SearchResultTipoActivoDTO
    {
        public int CountRow { get; set; }
        public List<TipoActivoDTO> Data { get; set; }
        public class TipoActivoDTO
        {
            public int Id { get; set; }

            [Display(Name = "Nombre")]
            public string Nombre { get; set; }

            [Display(Name = "Descripcion")]
            public string Descripcion { get; set; }
        }
    }
}
