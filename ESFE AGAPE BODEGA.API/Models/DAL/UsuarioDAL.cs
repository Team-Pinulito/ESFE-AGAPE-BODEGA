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

        public async Task<int> ActualizarUsuario(Usuario usuario)
        {
            var usuarioExistente = await applicationDbContext.usuarios.FindAsync(usuario.Id);

            if (usuarioExistente == null)
            {
                throw new Exception("Usuario no encontrado");
            }

            // Verifica si la contraseña ha cambiado
            if (!string.IsNullOrWhiteSpace(usuario.Password) &&
                usuario.Password != usuarioExistente.Password)
            {
                // Hashear la nueva contraseña
                usuario.Password = BCrypt.Net.BCrypt.HashPassword(usuario.Password);
            }
            else
            {
                // Mantiene la contraseña original
                usuario.Password = usuarioExistente.Password;
            }

            // Actualiza los otros campos del usuario
            usuarioExistente.Nombre = usuario.Nombre; // Ejemplo de otro campo
            usuarioExistente.Apellido = usuario.Apellido; // Ejemplo de otro campo
            usuarioExistente.Email = usuario.Email;   // Ejemplo de otro campo
            usuarioExistente.Telefono = usuario.Telefono; // Ejemplo de otro campo
            usuarioExistente.DUI = usuario.DUI; // Ejemplo de otro campo
            usuarioExistente.Password = usuario.Password; // Asumimos que 'Password' se ha manejado
            usuarioExistente.Codigo = usuario.Codigo; // Ejemplo de otro campo
            usuarioExistente.Direccion = usuario.Direccion; // Ejemplo de otro campo
            usuarioExistente.RolId = usuario.RolId; // Ejemplo de otro campo

            applicationDbContext.usuarios.Update(usuarioExistente);
            return await applicationDbContext.SaveChangesAsync();
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

        public async Task<Usuario> ObtenerUsuarioPorDUIyPassword(LoginUsuarioDTO login)
        {
            // Buscar al usuario por DUI
            var user = await applicationDbContext.usuarios
                 .Include(u => u.Rol) // Incluir la entidad de Rol para acceder al ID del rol
                .FirstOrDefaultAsync(u => u.DUI == login.DUI);
            if (user == null || !BCrypt.Net.BCrypt.Verify(login.Password, user.Password))
            {
                return null; // Usuario no encontrado o contraseña incorrecta
            }
            return user; //
        }
    }
}
