using ESFE_AGAPE_BODEGA.API.Models.Entitys;
using Microsoft.EntityFrameworkCore;

namespace ESFE_AGAPE_BODEGA.API.Models.DAL
{
	public class CorrelativoDAL
	{
		//injeccion de dependencia de el contexto de la base de datos
		private readonly ApplicationDbContext applicationDbContext;

		//constructor
		public CorrelativoDAL(ApplicationDbContext applicationDbContext)
		{
			this.applicationDbContext = applicationDbContext;
		}

		public async Task<string> ObtenerSiguienteCorrelativo(string entidad)
		{
			try
			{
				// Obtener el máximo valor actual para la entidad
				var ultimoCorrelativo = await applicationDbContext.correlativos
					.Where(c => c.Entidad == entidad)
					.OrderByDescending(c => c.Valor)
					.FirstOrDefaultAsync();

				// Obtener el máximo valor de todas las entidades
				var maximoValorGlobal = await applicationDbContext.correlativos
					.MaxAsync(c => (int?)c.Valor) ?? 0;

				if (ultimoCorrelativo == null)
				{
					// Si no existe correlativo para esta entidad, usar el siguiente al máximo global
					ultimoCorrelativo = new Correlativo
					{
						Valor = maximoValorGlobal + 1,
						AliasInicial = "ESFE",
						AliasFinal = "000",
						Entidad = entidad
					};
					applicationDbContext.correlativos.Add(ultimoCorrelativo);
				}
				else
				{
					// Si existe, incrementar el valor máximo actual
					ultimoCorrelativo.Valor = Math.Max(maximoValorGlobal + 1, ultimoCorrelativo.Valor + 1);
				}

				await applicationDbContext.SaveChangesAsync();
				return $"{ultimoCorrelativo.AliasInicial}-{ultimoCorrelativo.Valor:D3}";
			}
			catch
			{
				return "ESFE-001";
			}
		}

	}
}

