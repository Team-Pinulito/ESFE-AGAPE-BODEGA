using ESFE_AGAPE_BODEGA.API.Models.Entitys;
using Microsoft.EntityFrameworkCore;

namespace ESFE_AGAPE_BODEGA.API.Models.DAL
{
    public class InventarioActivoDAL
    {
        private readonly ApplicationDbContext applicationDbContext;

        public InventarioActivoDAL(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<List<InventarioActivo>> ObtenerInventariosActivos()
        {
            return await applicationDbContext.inventarioActivos.ToListAsync();
        }

        public async Task<InventarioActivo> ObtenerInventarioActivoId(int id)
        {
            return await applicationDbContext.inventarioActivos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> CrearInventarioActivo(InventarioActivo inventarioActivo)
        {
            applicationDbContext.inventarioActivos.Add(inventarioActivo);
            return await applicationDbContext.SaveChangesAsync();
        }

        public async Task<int> ActualizarInventarioActivo(InventarioActivo inventarioActivo)
        {
            applicationDbContext.inventarioActivos.Update(inventarioActivo);
            return await applicationDbContext.SaveChangesAsync();
        }

        public async Task<int> EliminarInventarioActivo(int id)
        {
            var inventarioActivo = await ObtenerInventarioActivoId(id);
            applicationDbContext.inventarioActivos.Remove(inventarioActivo);
            return await applicationDbContext.SaveChangesAsync();
        }

        public async Task<List<InventarioActivo>> BuscarPaginado(int take = 10, int skip = 0)
        {
            take = take == 0 ? 10 : take;
            var query = applicationDbContext.inventarioActivos.AsQueryable();
            query = query.OrderByDescending(x => x.Id).Skip(skip).Take(take);
            return await query.ToListAsync();
        }

        public async Task<int> ContarTotalInventarioActivo()
        {
            return await applicationDbContext.inventarioActivos.CountAsync();
        }
    }
}
