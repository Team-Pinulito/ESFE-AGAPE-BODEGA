﻿namespace ESFE_AGAPE_BODEGA.DTOs.ActivoDTOs
{
    public class GetIdResultActivoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int EstanteId { get; set; }
        public int TipoActivoId { get; set; }
        public string Codigo { get; set; }

		public string CodigoBarra { get; set; }


	}
}
