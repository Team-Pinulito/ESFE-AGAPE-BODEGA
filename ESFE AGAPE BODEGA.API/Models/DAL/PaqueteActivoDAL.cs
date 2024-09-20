using ESFE_AGAPE_BODEGA.API.Models.Entitys;
using Microsoft.EntityFrameworkCore;

namespace ESFE_AGAPE_BODEGA.API.Models.DAL
{
	public class PaqueteActivoDAL
	{
		private readonly ApplicationDbContext applicationDbContext;

		public PaqueteActivoDAL(ApplicationDbContext applicationDbContext)
		{
			this.applicationDbContext = applicationDbContext;
		}

		public async Task<List<PaqueteActivo>> ObtenerPaqueteActivos()
		{
			return await applicationDbContext.paqueteActivos.ToListAsync();
		}

		public async Task<PaqueteActivo> ObtenerPaqueteActivoId(int id)
		{
			return await applicationDbContext.paqueteActivos.Include(e => e.DetallePaqueteActivos).FirstOrDefaultAsync(x => x.Id == id);
		}

		//crear PaqueteActivo
		public async Task<int> CrearPaqueteActivo(PaqueteActivo paqueteActivo)
		{
			applicationDbContext.paqueteActivos.Add(paqueteActivo);
			var result = await applicationDbContext.SaveChangesAsync();
			return result;
		}

		public async Task<int> ActualizarPaqueteActivo(PaqueteActivo paqueteActivo)
		{
			// Buscar el PaqueteActivo existente con sus DetallePaqueteActivos
			var existingPaqueteActivo = await applicationDbContext.paqueteActivos
				.Include(p => p.DetallePaqueteActivos)
				.FirstOrDefaultAsync(p => p.Id == paqueteActivo.Id);

			if (existingPaqueteActivo != null)
			{
				// Actualizar los campos del PaqueteActivo
				applicationDbContext.Entry(existingPaqueteActivo).CurrentValues.SetValues(paqueteActivo);

				// Gestionar los DetallePaqueteActivos

				// Actualizar o añadir nuevos detalles
				foreach (var detalle in paqueteActivo.DetallePaqueteActivos)
				{
					var existingDetalle = existingPaqueteActivo.DetallePaqueteActivos
						.FirstOrDefault(d => d.Id == detalle.Id);

					if (existingDetalle != null)
					{
						// Si el detalle existe, actualizar sus valores
						applicationDbContext.Entry(existingDetalle).CurrentValues.SetValues(detalle);
					}
					else
					{
						// Si el detalle no existe, agregarlo al PaqueteActivo
						existingPaqueteActivo.DetallePaqueteActivos.Add(detalle);
					}
				}

				// Eliminar detalles que ya no están en la nueva lista
				foreach (var existingDetalle in existingPaqueteActivo.DetallePaqueteActivos.ToList())
				{
					if (!paqueteActivo.DetallePaqueteActivos.Any(d => d.Id == existingDetalle.Id))
					{
						applicationDbContext.detallePaqueteActivos.Remove(existingDetalle);
					}
				}

				// Guardar los cambios en la base de datos
				return await applicationDbContext.SaveChangesAsync();
			}

			// Si no se encuentra el PaqueteActivo, devolver 0 o lanzar una excepción
			return 0;
		}

		public async Task<int> EliminarPaqueteActivo(int id)
		{
			var paqueteActivo = await ObtenerPaqueteActivoId(id);
			applicationDbContext.paqueteActivos.Remove(paqueteActivo);
			var result = await applicationDbContext.SaveChangesAsync();
			return result;
		}

		public IQueryable<PaqueteActivo> BuscarPaqueteActivo(PaqueteActivo paqueteActivo)
		{
			var query = applicationDbContext.paqueteActivos.AsQueryable();
			if (!string.IsNullOrEmpty(paqueteActivo.Nombre))
			{
				query = query.Where(x => x.Nombre.Contains(paqueteActivo.Nombre));
			}
			if (!string.IsNullOrEmpty(paqueteActivo.Correlativo))
			{
				query = query.Where(x => x.Correlativo.Contains(paqueteActivo.Correlativo));
			}

			return query;
		}

		public async Task<int> ContarResultPaqueteActivo(PaqueteActivo paqueteActivo)
		{
			return await BuscarPaqueteActivo(paqueteActivo).CountAsync();
		}

		public async Task<List<PaqueteActivo>> BuscarPaginado(PaqueteActivo paqueteActivo, int take = 10, int skip = 0)
		{
			take = take == 0 ? 10 : take;
			var query = BuscarPaqueteActivo(paqueteActivo);
			query = query.OrderByDescending(x => x.Id).Skip(skip).Take(take);
			return await query.ToListAsync();
		}

	}
}
