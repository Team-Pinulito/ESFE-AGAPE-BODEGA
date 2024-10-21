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


		public async Task<Correlativo> ObtenerCorrelativoPorId(int id)
		{
			return await applicationDbContext.correlativos.FindAsync(id);
		}



		public async Task<Correlativo> CrearCorrelativo(Correlativo nuevoCorrelativo)
		{
			applicationDbContext.correlativos.Add(nuevoCorrelativo);
			await applicationDbContext.SaveChangesAsync();
			return nuevoCorrelativo;
		}

	

		public async Task EliminarCorrelativo(int id)
		{
			var correlativo = await applicationDbContext.correlativos.FindAsync(id);
			if (correlativo != null)
			{
				applicationDbContext.correlativos.Remove(correlativo);
				await applicationDbContext.SaveChangesAsync();
			}
		}
	}
}

