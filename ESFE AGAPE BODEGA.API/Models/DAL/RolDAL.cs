using ESFE_AGAPE_BODEGA.API.Models.Entitys;
using Microsoft.EntityFrameworkCore;

namespace ESFE_AGAPE_BODEGA.API.Models.DAL
{
    public class RolDAL
    {

        //injeccion de dependencia de el contexto de la base de datos
        private readonly ApplicationDbContext applicationDbContext;

        //constructor
        public RolDAL(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        //obtener roles
        public async Task<List<Rol>> ObtenerRoles()
        {
            return await applicationDbContext.roles.ToListAsync();
        }

        //buscar rol por id
        public async Task<Rol> ObtenerRolId(int id)
        {
            return await applicationDbContext.roles.FirstOrDefaultAsync(x => x.Id == id);
        }

        //crear rol
        public async Task<int> CrearRol(Rol rol)
        {
            applicationDbContext.roles.Add(rol);
            var result = await applicationDbContext.SaveChangesAsync();
            return result;
        }

        //actualizar rol
        public async Task<int> ActualizarRol(Rol rol)
        {
            applicationDbContext.roles.Update(rol);
            var result = await applicationDbContext.SaveChangesAsync();
            return result;
        }

        //eliminar rol
        public async Task<int> EliminarRol(int id)
        {
            var rol = await ObtenerRolId(id);
            applicationDbContext.roles.Remove(rol);
            var result = await applicationDbContext.SaveChangesAsync();
            return result;
        }

        //buscar rol con filtros
        public  IQueryable<Rol> BuscarRol(Rol rol)
        {
            var query = applicationDbContext.roles.AsQueryable();
            if (!string.IsNullOrEmpty(rol.Nombre))
            {
                query = query.Where(x => x.Nombre.Contains(rol.Nombre));
            }
            if (!string.IsNullOrEmpty(rol.Descripcion))
            {
                query = query.Where(x => x.Descripcion.Contains(rol.Descripcion));
            }

            return query;
        }

        //cantidad de resultados de la busqueda
        public async Task<int> ContarResultRol(Rol rol)
        {
            return await BuscarRol(rol).CountAsync();
        }

        //paginacion de resultados
        public async Task<List<Rol>> BuscarPaginado(Rol rol, int take = 10 , int skip = 0)
        {
            take = take == 0 ? 10 : take;
            var query = BuscarRol(rol);
            query = query.OrderByDescending(x => x.Id).Skip(skip).Take(take);
            return await query.ToListAsync();
        }


    }
}
