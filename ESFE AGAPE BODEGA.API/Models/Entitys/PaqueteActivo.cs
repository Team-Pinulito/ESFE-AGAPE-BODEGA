namespace ESFE_AGAPE_BODEGA.API.Models.Entitys
{
	public class PaqueteActivo
	{
		public int Id { get; set; }

		public string Correlativo { get; set; }
		
		public string Nombre { get; set; }

		public IList<DetallePaqueteActivo> DetallePaqueteActivos { get; set; }

		public ICollection<DetalleSolicitudActivo> DetalleSolicitudActivos { get; set; }

	}
}
