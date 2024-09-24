using ESFE_AGAPE_BODEGA.API.Models.Entitys;

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

        public virtual Usuario usuario {  get; set; }

        public virtual ICollection<DetalleIngresoActivo> DetalleIngresoActivos { get; set; }

    }
}
