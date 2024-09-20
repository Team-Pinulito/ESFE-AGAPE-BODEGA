using ESFE_AGAPE_BODEGA.API.Models.Entitys;
using Microsoft.EntityFrameworkCore;

namespace ESFE_AGAPE_BODEGA.API.Models.DAL
{
    public class AjusteInventarioDAL
    {
        private readonly ApplicationDbContext applicationDbContext;

        public AjusteInventarioDAL(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<List<AjusteInventario>> ObtenerAjustesInventario()
        {
            return await applicationDbContext.ajusteInventarios.ToListAsync();
        }

        public async Task<AjusteInventario> ObtenerAjusteInventarioId(int id)
        {
            return await applicationDbContext.ajusteInventarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> CrearAjusteInventario(AjusteInventario ajusteInventario)
        {
            applicationDbContext.ajusteInventarios.Add(ajusteInventario);
            return await applicationDbContext.SaveChangesAsync();
        }

        public async Task<int> ActualizarAjusteInventario(AjusteInventario ajusteInventario)
        {
            applicationDbContext.ajusteInventarios.Update(ajusteInventario);
            return await applicationDbContext.SaveChangesAsync();
        }

        public async Task<int> EliminarAjusteInventario(int id)
        {
            var ajusteInventario = await ObtenerAjusteInventarioId(id);
            applicationDbContext.ajusteInventarios.Remove(ajusteInventario);
            return await applicationDbContext.SaveChangesAsync();
        }

        public IQueryable<AjusteInventario> BuscarAjusteInventario(AjusteInventario ajusteInventario)
        {
            var query = applicationDbContext.ajusteInventarios.AsQueryable();
            // Ajusta este filtro según las propiedades relevantes de AjusteInventario
            if (ajusteInventario.FechaIngreso != default)
            {
                query = query.Where(x => x.FechaIngreso == ajusteInventario.FechaIngreso);
            }
            return query;
        }

        public async Task<int> ContarResultAjusteInventario(AjusteInventario ajusteInventario)
        {
            return await BuscarAjusteInventario(ajusteInventario).CountAsync();
        }

        public async Task<List<AjusteInventario>> BuscarPaginado(AjusteInventario ajusteInventario, int take = 10, int skip = 0)
        {
            take = take == 0 ? 10 : take;
            var query = BuscarAjusteInventario(ajusteInventario);
            query = query.OrderByDescending(x => x.Id).Skip(skip).Take(take);
            return await query.ToListAsync();
        }
    }
}
