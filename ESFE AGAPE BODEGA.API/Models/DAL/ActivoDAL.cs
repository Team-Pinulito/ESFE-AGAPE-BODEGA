using Bodega_Api_Esfe_Agape.Models.EN;
using Microsoft.EntityFrameworkCore;

namespace ESFE_AGAPE_BODEGA.API.Models.DAL
{
    public class ActivoDAL
    {
        private readonly ApplicationDbContext _context;

        public ActivoDAL(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Activo>> ObtenerActivos()
        {
            return await _context.activos.ToListAsync();
        }

        public async Task<Activo> ObtenerActivoPorId(int id)
        {
            return await _context.activos
                .Include(a => a.estante)
                .Include(a => a.tipoactivo)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<int> CrearActivo(Activo activo)
        {
            _context.activos.Add(activo);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> ActualizarActivo(Activo activo)
        {
            var existingActivo = await ObtenerActivoPorId(activo.Id);

            if (existingActivo != null)
            {
                _context.Entry(existingActivo).CurrentValues.SetValues(activo);
                return await _context.SaveChangesAsync();
            }

            return 0;
        }

        public async Task<int> EliminarActivo(int id)
        {
            var activo = await ObtenerActivoPorId(id);
            if (activo != null)
            {
                _context.activos.Remove(activo);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public IQueryable<Activo> BuscarActivo(Activo activo)
        {
            var query = _context.activos.AsQueryable();

            if (!string.IsNullOrEmpty(activo.Nombre))
            {
                query = query.Where(a => a.Nombre.Contains(activo.Nombre));
            }

            return query;
        }

        public async Task<int> ContarResultActivo(Activo activo)
        {
            return await BuscarActivo(activo).CountAsync();
        }

        public async Task<List<Activo>> BuscarPaginado(Activo activo, int take = 10, int skip = 0)
        {
            var query = BuscarActivo(activo);
            query = query.OrderByDescending(a => a.Id).Skip(skip).Take(take);
            return await query.ToListAsync();
        }

    }
}
