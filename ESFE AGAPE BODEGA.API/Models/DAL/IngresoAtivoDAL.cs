﻿using Bodega_Api_Esfe_Agape.Models.EN;
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
            return await applicationDbContext.ingresoactivos.Include(e => e.DetalleIngresoActivos).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> CrearIngresoActivo(IngresoActivo ingresoActivo)
        {
           
            // Agrega el IngresoActivo y sus detalles
            applicationDbContext.ingresoactivos.Add(ingresoActivo);
            var result = await applicationDbContext.SaveChangesAsync();
            return result;
        }


        public async Task<int> ActualizaringresoActivo(IngresoActivo ingresoActivo)
        {      
            // Buscar el IngresoActivo existente con sus DetalleIngresoActivos
            var existingIngresoActivo = await applicationDbContext.ingresoactivos
                .Include(p => p.DetalleIngresoActivos)
                .FirstOrDefaultAsync(p => p.Id == ingresoActivo.Id);

            if (existingIngresoActivo != null)
            {
                // Actualizar los campos del IngresoActivo
                applicationDbContext.Entry(existingIngresoActivo).CurrentValues.SetValues(ingresoActivo);

                // Gestionar los DetalleIngresoActivos

                // Actualizar o añadir nuevos detalles
                foreach (var detalle in ingresoActivo.DetalleIngresoActivos)
                {
                    var existingDetalle = existingIngresoActivo.DetalleIngresoActivos
                        .FirstOrDefault(d => d.Id == detalle.Id);

                    if (existingDetalle != null)
                    {
                        // Si el detalle existe, actualizar sus valores
                        applicationDbContext.Entry(existingDetalle).CurrentValues.SetValues(detalle);
                    }
                    else
                    {
                        // Si el detalle no existe, agregarlo al IngresoActivo
                        existingIngresoActivo.DetalleIngresoActivos.Add(detalle);
                    }
                }

                // Eliminar detalles que ya no están en la nueva lista
                foreach (var existingDetalle in existingIngresoActivo.DetalleIngresoActivos.ToList())
                {
                    if (!ingresoActivo.DetalleIngresoActivos.Any(d => d.Id == existingDetalle.Id))
                    {
                        applicationDbContext.detalleIngresos.Remove(existingDetalle);
                    }
                }

				


				return await applicationDbContext.SaveChangesAsync();
            }

            // Si no se encuentra el IngresoActivo, devolver 0
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

            // Búsqueda por fecha (si está presente)
            if (ingresoActivo.FechaIngreso != default(DateTime))
            {
                // Comparar solo la parte de la fecha, ignorando la hora
                query = query.Where(x => x.FechaIngreso.Date == ingresoActivo.FechaIngreso.Date);
            }
            // Comparar solo la parte de la fecha, ignorando la hora


            return query;
        }

        public async Task<int> ContarResultIngresoActivo(IngresoActivo ingresoActivo)
        {
            return await BuscaringresoActivo(ingresoActivo).CountAsync();
        }

        public async Task<List<IngresoActivo>> BuscarPaginado(IngresoActivo ingresoActivo, int take = 10, int skip = 0)
        {
            take = take == 0 ? 10 : take;
            var query = BuscaringresoActivo(ingresoActivo);
            query = query.OrderByDescending(x => x.Id).Skip(skip).Take(take);
            return await query.ToListAsync();
        }
    }
}
