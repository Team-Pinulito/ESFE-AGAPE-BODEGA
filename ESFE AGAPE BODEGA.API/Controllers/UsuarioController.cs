using Microsoft.AspNetCore.Mvc;
using ESFE_AGAPE_BODEGA.API.Models.DAL;
using ESFE_AGAPE_BODEGA.DTOs.UsuarioDTOs;
using ESFE_AGAPE_BODEGA.API.Models.Entitys;
using System.Threading.Tasks;
using ESFE_AGAPE_BODEGA.DTOs.RolDTOs;

namespace ESFE_AGAPE_BODEGA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioDAL _usuarioDAL;

        public UsuarioController(UsuarioDAL usuarioDAL)
        {
            _usuarioDAL = usuarioDAL;
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public async Task<List<GetIdResultUsuarioDTO>> ObtenerTodos()
        {
            var usuarios = await _usuarioDAL.ObtenerUsuarios();

            var usuarioDto = usuarios.Select(r => new GetIdResultUsuarioDTO
            {
                Id = r.Id,
                Nombre = r.Nombre,
                Apellido = r.Apellido,
                Email = r.Email,
                Telefono = r.Telefono,
                DUI = r.DUI,
                Password = r.Password,
                Codigo = r.Codigo,
                Direccion = r.Direccion,
                RolId = r.RolId
            }).ToList();

            return usuarioDto;
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public async Task<Usuario> ObtenerUsuarioId(int id)
        {
            return await _usuarioDAL.ObtenerUsuarioId(id);
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearUsuarioDTO crearUsuarioDTO)
        {
            var usuario = new Usuario
            {
                Nombre = crearUsuarioDTO.Nombre,
                Apellido = crearUsuarioDTO.Apellido,
                Email = crearUsuarioDTO.Email,
                Telefono = crearUsuarioDTO.Telefono,
                DUI = crearUsuarioDTO.DUI,
                Password = crearUsuarioDTO.Password,
                Codigo = crearUsuarioDTO.Codigo,
                Direccion = crearUsuarioDTO.Direccion,
                RolId = crearUsuarioDTO.RolId
            };

            var result = await _usuarioDAL.CrearUsuario(usuario);

            if (result > 0)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(500);
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] EditUsuarioDTO editUsuarioDTO)
        {
            if (id != editUsuarioDTO.Id)
            {
                return BadRequest();
            }

            var usuario = new Usuario
            {
                Id = editUsuarioDTO.Id,
                Nombre = editUsuarioDTO.Nombre,
                Apellido = editUsuarioDTO.Apellido,
                Email = editUsuarioDTO.Email,
                Telefono = editUsuarioDTO.Telefono,
                DUI = editUsuarioDTO.DUI,
                Password = editUsuarioDTO.Password,
                Codigo = editUsuarioDTO.Codigo,
                Direccion = editUsuarioDTO.Direccion,
                RolId = editUsuarioDTO.RolId
            };

            var result = await _usuarioDAL.ActualizarUsuario(usuario);
            if (result > 0)
            {
                return NoContent();
            }
            return NotFound();
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _usuarioDAL.EliminarUsuario(id);
            if (result > 0)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
