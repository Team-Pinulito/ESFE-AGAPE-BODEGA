using ESFE_AGAPE_BODEGA.API.Models.Entitys;
using Microsoft.EntityFrameworkCore;

namespace ESFE_AGAPE_BODEGA.API.Models.DAL
{
    public class BodegaDAL
    {
        //injeccion de dependencia de el contexto de la base de datos
        private readonly ApplicationDbContext applicationDbContext;

        //constructor
        public BodegaDAL(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        //obtener roles
        public async Task<List<Bodega>> ObtenerBodega()
        {
            return await applicationDbContext.bodegas.ToListAsync();
        }

        //buscar rol por id
        public async Task<Bodega> ObtenerBodegaId(int id)
        {
            return await applicationDbContext.bodegas.FirstOrDefaultAsync(x => x.Id == id);
        }

        //crear rol
        public async Task<int> CrearBodega(Bodega bodega)
        {
            applicationDbContext.bodegas.Add(bodega);
            var result = await applicationDbContext.SaveChangesAsync();
            return result;
        }

        //actualizar rol
        public async Task<int> ActualizarBodega(Bodega bodega)
        {
            applicationDbContext.bodegas.Update(bodega);
            var result = await applicationDbContext.SaveChangesAsync();
            return result;
        }

        //eliminar rol
        public async Task<int> EliminarBodega(int id)
        {
            var bodega = await ObtenerBodegaId(id);
            applicationDbContext.bodegas.Remove(bodega);
            var result = await applicationDbContext.SaveChangesAsync();
            return result;
        }

        //buscar rol con filtros
        public IQueryable<Bodega> BuscarBodega(Bodega bodega)
        {
            var query = applicationDbContext.bodegas.AsQueryable();
            if (!string.IsNullOrEmpty(bodega.Nombre))
            {
                query = query.Where(x => x.Nombre.Contains(bodega.Nombre));
            }
            if (!string.IsNullOrEmpty(bodega.Descripcion))
            {
                query = query.Where(x => x.Descripcion.Contains(bodega.Descripcion));
            }

            return query;
        }

        //cantidad de resultados de la busqueda
        public async Task<int> ContarResultRol(Bodega bodega)
        {
            return await BuscarBodega(bodega).CountAsync();
        }

        //paginacion de resultados
        public async Task<List<Bodega>> BuscarPaginado(Bodega bodega, int take = 10, int skip = 0)
        {
            take = take == 0 ? 10 : take;
            var query = BuscarBodega(bodega);
            query = query.OrderByDescending(x => x.Id).Skip(skip).Take(take);
            return await query.ToListAsync();
        }
    }
}
