using ESFE_AGAPE_BODEGA.API.Models.Entitys;
using Microsoft.EntityFrameworkCore;

namespace ESFE_AGAPE_BODEGA.API.Models.DAL
{
	public class EstanteDAL
	{
		//injeccion de dependencia de el contexto de la base de datos
		private readonly ApplicationDbContext applicationDbContext;

		//constructor
		public EstanteDAL(ApplicationDbContext applicationDbContext)
		{
			this.applicationDbContext = applicationDbContext;
		}

		//obtener estante
		public async Task<List<Estante>> ObtenerEstantes()
		{
			return await applicationDbContext.estantes
				 .Include(e => e.Bodega) // Incluir la entidad relacionada Bodega
				.ToListAsync();
		}

		//buscar estante por id
		public async Task<Estante> ObtenerEstanteId(int id)
		{
			return await applicationDbContext.estantes.Include(e => e.Bodega).FirstOrDefaultAsync(x => x.Id == id);
		}

		//crear estante
		public async Task<int> CrearEstante(Estante estante)
		{
			applicationDbContext.estantes.Add(estante);
			var result = await applicationDbContext.SaveChangesAsync();
			return result;
		}

		//actualizar estante
		public async Task<int> ActualizarEstante(Estante estante)
		{
			applicationDbContext.estantes.Update(estante);
			var result = await applicationDbContext.SaveChangesAsync();
			return result;
		}

		//eliminar estante
		public async Task<int> EliminarEstante(int id)
		{
			var estante = await ObtenerEstanteId(id);
			applicationDbContext.estantes.Remove(estante);
			var result = await applicationDbContext.SaveChangesAsync();
			return result;
		}

		//buscar estante con filtros
		public IQueryable<Estante> BuscarEstante(Estante estante )
		{
			var query = applicationDbContext.estantes.AsQueryable();
			if (!string.IsNullOrEmpty(estante.Nombre))
			{
				query = query.Where(x => x.Nombre.Contains(estante.Nombre));
			}
			

			return query;
		}

		//cantidad de resultados de la busqueda
		public async Task<int> ContarResultEstante(Estante estante)
		{
			return await BuscarEstante(estante).CountAsync();
		}

		//paginacion de resultados
		public async Task<List<Estante>> BuscarPaginado(Estante estante, int take = 10, int skip = 0)
		{
			take = take == 0 ? 10 : take;
			var query = BuscarEstante(estante);
			query = query.OrderByDescending(x => x.Id).Skip(skip).Take(take);
			return await query.ToListAsync();
		}

	}
}
