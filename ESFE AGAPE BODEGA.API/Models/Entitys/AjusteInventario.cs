namespace ESFE_AGAPE_BODEGA.API.Models.Entitys
{
    public class AjusteInventario
    {
        public int Id { get; set; }
        public Usuario UsuarioId { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int Correlativo { get; set; }
        public int Cantidad { get; set; }
        public int TipoMantenimiento { get; set; }
        public string Comentario { get; set; }

        public List<InventarioActivo> InventarioActivos { get; set; }

    }
}
