using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE_AGAPE_BODEGA.DTOs.CorrelativoDTOs
{
	public class CrearCorrelativoDTO
	{
		public int Valor { get; set; }
		public string AliasInicial { get; set; }
		public string AliasFinal { get; set; }
		public string Entidad { get; set; }
	}
}
