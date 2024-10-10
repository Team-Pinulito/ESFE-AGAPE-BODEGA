using ESFE_AGAPE_BODEGA.API.Models.Entitys;
using Microsoft.EntityFrameworkCore;

namespace ESFE_AGAPE_BODEGA.API.Models.DAL
{
    public class SolicitudActivoDAL
    {
        private readonly ApplicationDbContext applicationDbContext;

        public SolicitudActivoDAL(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }


        public async Task<List<SolicitudActivo>> ObtenerSolicitudActivos()
        {
            return await applicationDbContext.solicitudActivos.Include(e => e.DetalleSolicitudActivos).ToListAsync();
        }

        public async Task<SolicitudActivo> ObtenerSolicitudActivoId(int id)
        {
            return await applicationDbContext.solicitudActivos.Include(e => e.DetalleSolicitudActivos).FirstOrDefaultAsync(x => x.Id == id);
        }

        //crear SolicitudActivo
        public async Task<int> CrearSolicitudActivo(SolicitudActivo solicitudActivo)
        {
            applicationDbContext.solicitudActivos.Add(solicitudActivo);
            var result = await applicationDbContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> ActualizarSolicitudActivo(SolicitudActivo solicitudActivo)
        {
            // Buscar el PaqueteActivo existente con sus DetallePaqueteActivos
            var existingSolicitudActivo = await applicationDbContext.solicitudActivos
                .Include(p => p.DetalleSolicitudActivos)
                .FirstOrDefaultAsync(p => p.Id == solicitudActivo.Id);

            if (existingSolicitudActivo != null)
            {
                // Actualizar los campos del PaqueteActivo
                applicationDbContext.Entry(existingSolicitudActivo).CurrentValues.SetValues(solicitudActivo);

                // Gestionar los DetallePaqueteActivos

                // Actualizar o añadir nuevos detalles
                foreach (var detalle in solicitudActivo.DetalleSolicitudActivos)
                {
                    var existingDetalle = existingSolicitudActivo.DetalleSolicitudActivos
                        .FirstOrDefault(d => d.Id == detalle.Id);

                    if (existingDetalle != null)
                    {
                        // Si el detalle existe, actualizar sus valores
                        applicationDbContext.Entry(existingDetalle).CurrentValues.SetValues(detalle);
                    }
                    else
                    {
                        // Si el detalle no existe, agregarlo al PaqueteActivo
                        existingSolicitudActivo.DetalleSolicitudActivos.Add(detalle);
                    }
                }

                // Eliminar detalles que ya no están en la nueva lista
                foreach (var existingDetalle in existingSolicitudActivo.DetalleSolicitudActivos.ToList())
                {
                    if (!solicitudActivo.DetalleSolicitudActivos.Any(d => d.Id == existingDetalle.Id))
                    {
                        applicationDbContext.detalleSolicitudActivos.Remove(existingDetalle);
                    }
                }

                // Guardar los cambios en la base de datos
                return await applicationDbContext.SaveChangesAsync();
            }

            // Si no se encuentra el PaqueteActivo, devolver 0 o lanzar una excepción
            return 0;
        }

        public async Task<int> EliminarSolicitudActivo(int id)
        {
            var solicitudActivo = await ObtenerSolicitudActivoId(id);
            if (solicitudActivo == null)
            {
                return 0;
            }

            applicationDbContext.solicitudActivos.Remove(solicitudActivo);
            var result = await applicationDbContext.SaveChangesAsync();
            return result;
        }

        public IQueryable<SolicitudActivo> BuscarSolicitudActivo(SolicitudActivo solicitudActivo)
        {
            var query = applicationDbContext.solicitudActivos.AsQueryable();
            if (!string.IsNullOrEmpty(solicitudActivo.Correlativo))
            {
                query = query.Where(x => x.Correlativo.Contains(solicitudActivo.Correlativo));
            }
            if (solicitudActivo.UsuarioId != 0)
            {
                query = query.Where(x => x.UsuarioId == solicitudActivo.UsuarioId);
            }

            return query;
        }

        public async Task<int> ContarResultSolicitudActivo(SolicitudActivo solicitudActivo)
        {
            return await BuscarSolicitudActivo(solicitudActivo).CountAsync();
        }

        public async Task<List<SolicitudActivo>> BuscarPaginado(SolicitudActivo solicitudActivo, int take = 10, int skip = 0)
        {
            take = take == 0 ? 10 : take;
            var query = BuscarSolicitudActivo(solicitudActivo);
            query = query.OrderByDescending(x => x.Id).Skip(skip).Take(take);
            return await query.ToListAsync();
        }
    }
}
