using Bodega_Api_Esfe_Agape.Models.EN;
using ESFE_AGAPE_BODEGA.API.Models.Entitys;
using Microsoft.EntityFrameworkCore;

namespace ESFE_AGAPE_BODEGA.API.Models.DAL
{
    public class IngresoAtivoDAL
    {
        private readonly ApplicationDbContext applicationDbContext;

        public IngresoAtivoDAL(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<List<IngresoActivo>> ObtenerIngresoActivo()
        {
            return await applicationDbContext.ingresoactivos.ToListAsync();
        }

        public async Task<IngresoActivo> ObtenerIngresoActivoId(int id)
        {
            return await applicationDbContext.ingresoactivos.Include(e => e.detalleIngresoActivos).FirstOrDefaultAsync(x => x.Id == id);
        }

        //crear PaqueteActivo
        public async Task<int> CrearIngresoActivo(IngresoActivo ingresoActivo)
        {
            applicationDbContext.ingresoactivos.Add(ingresoActivo);
            var result = await applicationDbContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> ActualizaringresoActivo(IngresoActivo ingresoActivo)
        {
            // Buscar el PaqueteActivo existente con sus DetallePaqueteActivos
            var existingIngresoActivo = await applicationDbContext.ingresoactivos
                .Include(p => p.detalleIngresoActivos)
                .FirstOrDefaultAsync(p => p.Id == ingresoActivo.Id);

            if (existingIngresoActivo != null)
            {
                // Actualizar los campos del PaqueteActivo
                applicationDbContext.Entry(existingIngresoActivo).CurrentValues.SetValues(ingresoActivo);

                // Gestionar los DetallePaqueteActivos

                // Actualizar o añadir nuevos detalles
                foreach (var detalle in ingresoActivo.detalleIngresoActivos)
                {
                    var existingDetalle = existingIngresoActivo.detalleIngresoActivos
                        .FirstOrDefault(d => d.Id == detalle.Id);

                    if (existingDetalle != null)
                    {
                        // Si el detalle existe, actualizar sus valores
                        applicationDbContext.Entry(existingDetalle).CurrentValues.SetValues(detalle);
                    }
                    else
                    {
                        // Si el detalle no existe, agregarlo al PaqueteActivo
                        existingIngresoActivo.detalleIngresoActivos.Add(detalle);
                    }
                }

                // Eliminar detalles que ya no están en la nueva lista
                foreach (var existingDetalle in existingIngresoActivo.detalleIngresoActivos.ToList())
                {
                    if (!ingresoActivo.detalleIngresoActivos.Any(d => d.Id == existingDetalle.Id))
                    {
                        applicationDbContext.detalleIngresos.Remove(existingDetalle);
                    }
                }

                // Guardar los cambios en la base de datos
                return await applicationDbContext.SaveChangesAsync();
            }

            // Si no se encuentra el PaqueteActivo, devolver 0 o lanzar una excepción
            return 0;
        }

        public async Task<int> EliminarIngresoActivo(int id)
        {
            var ingresoactivo = await ObtenerIngresoActivoId(id);
            applicationDbContext.ingresoactivos.Remove(ingresoactivo);
            var result = await applicationDbContext.SaveChangesAsync();
            return result;
        }

        public IQueryable<IngresoActivo> BuscaringresoActivo(IngresoActivo ingresoActivo)
        {
            var query = applicationDbContext.ingresoactivos.AsQueryable();
            if (!string.IsNullOrEmpty(ingresoActivo.Correlativo))
            {
                query = query.Where(x => x.Correlativo.Contains(ingresoActivo.Correlativo));
            }
           

            return query;
        }

        public async Task<int> ContarResultPaqueteActivo(IngresoActivo ingresoActivo)
        {
            return await BuscaringresoActivo(ingresoActivo).CountAsync();
        }
    }
}
