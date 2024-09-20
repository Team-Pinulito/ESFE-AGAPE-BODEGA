using Bodega_Api_Esfe_Agape.Models.EN;

namespace ESFE_AGAPE_BODEGA.API.Models.Entitys
{
    public class DetalleSolicitudActivo
    {
        public int Id { get; set; }
        public int SolicitudActivoId { get; set; }
        public int ActivoId { get; set; }

        public int PaqueteActivoId { get; set; }
        public int Cantidad { get; set; }
        public byte Status { get; set; }

        public Activo Activo { get; set; }
        public PaqueteActivo PaqueteActivo { get; set; }
        //public SolicitudActivo SolicitudActivo { get; set; }

    }
}
