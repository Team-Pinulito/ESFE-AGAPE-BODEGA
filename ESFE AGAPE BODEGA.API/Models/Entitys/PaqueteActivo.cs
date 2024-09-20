namespace ESFE_AGAPE_BODEGA.API.Models.Entitys
{
	public class PaqueteActivo
	{
		public int Id { get; set; }

		public string Correlativo { get; set; }
		
		public string Nombre { get; set; }

		public List<DetallePaqueteActivo> DetallePaqueteActivos { get; set; }

		//public List<DetalleSolicitudActivo> DetalleSolicitudActivos { get; set; }

	}
}
