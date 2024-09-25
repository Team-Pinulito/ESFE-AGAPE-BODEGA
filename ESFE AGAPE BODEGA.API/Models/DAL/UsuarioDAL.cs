using ESFE_AGAPE_BODEGA.API.Models.Entitys;
using ESFE_AGAPE_BODEGA.DTOs.UsuarioDTOs;
using Microsoft.EntityFrameworkCore;

namespace ESFE_AGAPE_BODEGA.API.Models.DAL
{
    public class UsuarioDAL
    {
        //injeccion de dependencia de el contexto de la base de datos
        private readonly ApplicationDbContext applicationDbContext;

        //constructor
        public UsuarioDAL(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        //obtener roles
        public async Task<List<Usuario>> ObtenerUsuarios()
        {
            return await applicationDbContext.usuarios.ToListAsync();
        }

        //buscar rol por id
        public async Task<Usuario> ObtenerUsuarioId(int id)
        {
            return await applicationDbContext.usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> CrearUsuario(Usuario usuario)
        {
            // Hashear la contraseña antes de guardarla
            usuario.Password = BCrypt.Net.BCrypt.HashPassword(usuario.Password);
            applicationDbContext.usuarios.Add(usuario);
            return await applicationDbContext.SaveChangesAsync();
        }

        //actualizar rol
        public async Task<int> ActualizarUsuario(Usuario usuario)
        {
            applicationDbContext.usuarios.Update(usuario);
            var result = await applicationDbContext.SaveChangesAsync();
            return result;
        }

        //eliminar rol
        public async Task<int> EliminarUsuario(int id)
        {
            var usuario = await ObtenerUsuarioId(id);
            applicationDbContext.usuarios.Remove(usuario);
            var result = await applicationDbContext.SaveChangesAsync();
            return result;
        }

        //buscar rol con filtros
        public IQueryable<Usuario> BuscarUsuario(Usuario usuario)
        {
            var query = applicationDbContext.usuarios.AsQueryable();
            if (!string.IsNullOrEmpty(usuario.Nombre))
            {
                query = query.Where(x => x.Nombre.Contains(usuario.Nombre));
            }


            return query;
        }

        //cantidad de resultados de la busqueda
        public async Task<int> ContarResultUsuario(Usuario usuario)
        {
            return await BuscarUsuario(usuario).CountAsync();
        }

        //paginacion de resultados
        public async Task<List<Usuario>> BuscarPaginado(Usuario usuario, int take = 10, int skip = 0)
        {
            take = take == 0 ? 10 : take;
            var query = BuscarUsuario(usuario);
            query = query.OrderByDescending(x => x.Id).Skip(skip).Take(take);
            return await query.ToListAsync();
        }

        public async Task<Usuario> GetUser(LoginUsuarioDTO login)
        {
            return await applicationDbContext.usuarios
                .Include(u => u.Rol) // Incluir la entidad de Rol para acceder al ID del rol
                .SingleOrDefaultAsync(x => x.DUI == login.DUI && x.Password == login.Password);
        }

        public async Task<Usuario> ObtenerUsuarioPorDUIyPassword(string dui, string password)
        {
            // Buscar al usuario por DUI
            var user = await applicationDbContext.usuarios.FirstOrDefaultAsync(u => u.DUI == dui);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return null; // Usuario no encontrado o contraseña incorrecta
            }
            return user; //
        }
    }
}
