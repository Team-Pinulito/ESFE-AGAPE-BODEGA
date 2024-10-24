﻿using ESFE_AGAPE_BODEGA.API.Models.Entitys;

namespace Bodega_Api_Esfe_Agape.Models.EN
{
    public class DetalleIngresoActivo
    {
        public int Id { get; set; }
        public int ActivoId { get; set; }
        public int EstanteId { get; set; }
        public int BodegaId { get; set; }
        public int IngresoActivoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
		public virtual Estante Estante { get; set; }
		public Bodega Bodega { get; set; }
		public Activo Activo { get; set; }

		public virtual IngresoActivo ingresoActivo { get; set; }

	}
}
