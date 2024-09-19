using ESFE_AGAPE_BODEGA.API.Models.Entitys;
using Microsoft.EntityFrameworkCore;

namespace ESFE_AGAPE_BODEGA.API.Models.DAL
{
    public class TipoActivoDAL

    {
        private readonly ApplicationDbContext applicationDbContext;


        public TipoActivoDAL(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        // Obtener todos los TipoActivo
        public async Task<List<TipoActivo>> ObtenerTipoActivos()
        {
            return await applicationDbContext.tipoActivos.ToListAsync();
        }

        // Buscar TipoActivo por ID
        public async Task<TipoActivo> ObtenerTipoActivoId(int id)
        {
            return await applicationDbContext.tipoActivos.FirstOrDefaultAsync(x => x.Id == id);
        }

        // Crear un nuevo TipoActivo
        public async Task<int> CrearTipoActivo(TipoActivo tipoActivo)
        {
            applicationDbContext.tipoActivos.Add(tipoActivo);
            var result = await applicationDbContext.SaveChangesAsync();
            return result;
        }

        // Actualizar un TipoActivo existente
        public async Task<int> ActualizarTipoActivo(TipoActivo tipoActivo)
        {
            applicationDbContext.tipoActivos.Update(tipoActivo);
            var result = await applicationDbContext.SaveChangesAsync();
            return result;
        }

        // Eliminar un TipoActivo
        public async Task<int> EliminarTipoActivo(int id)
        {
            var tipoActivo = await ObtenerTipoActivoId(id);
            applicationDbContext.tipoActivos.Remove(tipoActivo);
            var result = await applicationDbContext.SaveChangesAsync();
            return result;
        }

        // Buscar TipoActivo con filtros
        public IQueryable<TipoActivo> BuscarTipoActivo(TipoActivo tipoActivo)
        {
            var query = applicationDbContext.tipoActivos.AsQueryable();
            if (!string.IsNullOrEmpty(tipoActivo.Nombre))
            {
                query = query.Where(x => x.Nombre.Contains(tipoActivo.Nombre));
            }
            if (!string.IsNullOrEmpty(tipoActivo.Descripcion))
            {
                query = query.Where(x => x.Descripcion.Contains(tipoActivo.Descripcion));
            }

            return query;
        }

        // Contar resultados de la búsqueda
        public async Task<int> ContarResultTipoActivo(TipoActivo tipoActivo)
        {
            return await BuscarTipoActivo(tipoActivo).CountAsync();
        }

        // Paginación de resultados
        public async Task<List<TipoActivo>> BuscarPaginado(TipoActivo tipoActivo, int take = 10, int skip = 0)
        {
            take = take == 0 ? 10 : take;
            var query = BuscarTipoActivo(tipoActivo);
            query = query.OrderByDescending(x => x.Id).Skip(skip).Take(take);
            return await query.ToListAsync();
        }
    }
}
