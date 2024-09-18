using System.ComponentModel.DataAnnotations;

namespace Bodega_Api_Esfe_Agape.Models.EN
{
    public class Activo
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int EstanteId { get; set; }
        public int TipoActivoId { get; set; }
        public string Codigo { get; set; }
        public string CodigoBarra { get; set; }

        //public estante estantes { get; set; }
        //public tipoActivo tipoactivo { get; set; }
    }
}
