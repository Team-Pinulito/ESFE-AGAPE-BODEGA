namespace Bodega_Api_Esfe_Agape.Models.EN
{
    public class IngresoActivo
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Correlativo { get; set; }
        public string NumeroDocRelacionado { get; set; }
        public decimal Total { get; set; }

        //public Usuario usuario { get; set; }

    }
}
