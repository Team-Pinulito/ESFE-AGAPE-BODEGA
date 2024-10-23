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

				Correlativo nuevoCorrelativo;

				if (ultimoCorrelativo == null)
				{
					// Si no existe correlativo para esta entidad, usar el siguiente al máximo global
					nuevoCorrelativo = new Correlativo
					{
						Valor = maximoValorGlobal + 1,
						AliasInicial = "ESFE",
						AliasFinal = "000",
						Entidad = entidad
					};
				}
				else
				{
					// Verificar si existe un registro con el mismo valor de correlativo pero con una entidad diferente
					bool existeCorrelativoDuplicado = await applicationDbContext.correlativos
						.AnyAsync(c => c.Valor == ultimoCorrelativo.Valor && c.Entidad != entidad);

					if (existeCorrelativoDuplicado)
					{
						// Si existe un duplicado, usar el siguiente al máximo global
						nuevoCorrelativo = new Correlativo
						{
							Valor = maximoValorGlobal + 1,
							AliasInicial = "ESFE",
							AliasFinal = "000",
							Entidad = entidad
						};
					}
					else
					{
						// Si no hay duplicado, incrementar el valor máximo actual
						nuevoCorrelativo = new Correlativo
						{
							Valor = Math.Max(maximoValorGlobal + 1, ultimoCorrelativo.Valor + 1),
							AliasInicial = "ESFE",
							AliasFinal = "000",
							Entidad = entidad
						};
					}
				}

				var correlativo = $"{nuevoCorrelativo.AliasInicial}-{nuevoCorrelativo.Valor:D3}";
				return correlativo.Replace("--", "-");
			}
			catch
			{
				return "ESFE-001";
			}
		}

	}
}

