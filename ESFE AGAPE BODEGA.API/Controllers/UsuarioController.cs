using Microsoft.AspNetCore.Mvc;
using ESFE_AGAPE_BODEGA.API.Models.DAL;
using ESFE_AGAPE_BODEGA.DTOs.UsuarioDTOs;
using ESFE_AGAPE_BODEGA.API.Models.Entitys;
using System.Threading.Tasks;

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
        public async Task<List<GetIdResultUsuarioDTO.UsuarioDTO>> ObtenerTodos()
        {
            var usuarios = await _usuarioDAL.ObtenerUsuarios();

            var usuarioDto = usuarios.Select(r => new GetIdResultUsuarioDTO.UsuarioDTO
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

        //obtener todos paginados
        [HttpPost("buscar")]
        public async Task<GetIdResultUsuarioDTO> Buscar(SearchQueryUsuarioDTO usuarioDto)
        {

            var usuario = new Usuario
            {
                Nombre = usuarioDto.Nombre_Like != null ? usuarioDto.Nombre_Like : string.Empty,
            };

            var usuarios = new List<Usuario>();
            var countRow = 0;

            if (usuarioDto.SendRowCount == 2)
            {
                usuarios = await _usuarioDAL.BuscarPaginado(usuario, skip: usuarioDto.Skip, take: usuarioDto.Take);
                if (usuarios.Count > 0)
                {
                    countRow = await _usuarioDAL.ContarResultUsuario(usuario);
                }
            }
            else
            {
                usuarios = await _usuarioDAL.BuscarPaginado(usuario, skip: usuarioDto.Skip, take: usuarioDto.Take);
            }

            var usuarioResult = new GetIdResultUsuarioDTO
            {
                Data = new List<GetIdResultUsuarioDTO.UsuarioDTO>(),
                CountRow = countRow
            };

            foreach (var item in usuarios)
            {
                usuarioResult.Data.Add(new GetIdResultUsuarioDTO.UsuarioDTO
                {
                    Id = item.Id,
                    Nombre = item.Nombre,
                    Apellido = item.Apellido,
                    Email = item.Email,
                    Telefono = item.Telefono,
                    DUI = item.DUI,
                    Password = item.Password,
                    Codigo = item.Codigo,
                    Direccion = item.Direccion,
                    RolId = item.RolId
                });
            }

            return usuarioResult;

        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetIdResultUsuarioDTO.UsuarioDTO>> ObtenerUsuarioId(int id)
        {
            var usuario = await _usuarioDAL.ObtenerUsuarioId(id);

            if (usuario == null)
            {
                return NotFound();
            }

            var usuarioDto = new GetIdResultUsuarioDTO.UsuarioDTO
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Email = usuario.Email,
                Telefono = usuario.Telefono,
                DUI = usuario.DUI,
                Password = usuario.Password,
                Codigo = usuario.Codigo,
                Direccion = usuario.Direccion,
                RolId = usuario.RolId
            };

            return usuarioDto;
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
                return Ok(result);
            }
            else
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _usuarioDAL.EliminarUsuario(id);
            if (result > 0)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(500);
            }
        }
    }
}
