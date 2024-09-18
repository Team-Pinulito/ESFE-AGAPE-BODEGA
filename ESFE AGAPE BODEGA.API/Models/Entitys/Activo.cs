namespace Bodega_Api_Esfe_Agape.Models.EN
{
    public class Activo
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int estanteId { get; set; }
        public int tipoActivoId { get; set; }
        public string codigo { get; set; }
        public string codigoBarra { get; set; }

        //public estante estantes { get; set; }
        //public tipoActivo tipoactivo { get; set; }
    }
}
