using System.ComponentModel;

namespace ESFE_AGAPE_BODEGA.API.Models.Entitys
{
    public class AjusteInventario
    {
        public int Id { get; set; }
        [DisplayName("Usuario")]
        public int UsuarioId { get; set; }
        [DisplayName("Fecha de Ingreso")]
        public DateTime FechaIngreso { get; set; }
        public int Correlativo { get; set; }
        public int Cantidad { get; set; }
        public int TipoMantenimiento { get; set; }
        public string Comentario { get; set; }

        public Usuario Usuario { get; set; }

        public List<InventarioActivo> InventarioActivos { get; set; }

    }
}
