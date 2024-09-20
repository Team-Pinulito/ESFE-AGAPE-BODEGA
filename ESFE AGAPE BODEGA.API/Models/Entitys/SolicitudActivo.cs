namespace ESFE_AGAPE_BODEGA.API.Models.Entitys
{
    public class SolicitudActivo
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int UsuarioIdBodegueroEntregaId { get; set; }
        public int UsuarioIdBodegueroRecibeId { get; set; }
        public string Correlativo { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaEntrega { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public DateTime FechaEntregaEsperada { get; set; }
        public DateTime FechaRecepcionEsperada { get; set; }
        public string Comentario { get; set; }

        //para UsuarioId
        public Usuario Usuario { get; set; }

        //para UsuarioIdBodegueroEntregaId
        public Usuario UsuarioBodegueroEntrega { get; set; }

        //para UsuarioIdBodegueroRecibeId
        public Usuario UsuarioBodegueroRecibe { get; set; }

        public ICollection<DetalleSolicitudActivo> DetalleSolicitudActivos { get; set; }
    }
}
