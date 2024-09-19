using ESFE_AGAPE_BODEGA.API.Models.DAL;
using ESFE_AGAPE_BODEGA.API.Models.Entitys;
using ESFE_AGAPE_BODEGA.DTOs.RolDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESFE_AGAPE_BODEGA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {

        private readonly RolDAL _rolDAL;
        public RolController(RolDAL rolDAL)
        {
            _rolDAL = rolDAL;
        
        }

        //obtener todos
        [HttpGet]
        public async Task<List<BuscarRolResultadosDto.RolDto>> ObtenerTodos()
        {
            var roles = await _rolDAL.ObtenerRoles();

            var rolesDto = roles.Select(r => new BuscarRolResultadosDto.RolDto
            {
                Id = r.Id,
                Nombre = r.Nombre,
                Descripcion = r.Descripcion
            }).ToList();

            return rolesDto;
        }


        //obtener todos paginados
        [HttpPost("buscar")]
        public async Task<BuscarRolResultadosDto> Buscar(BuscarRolFiltroDto rolDto)
        {

            var rol = new Rol
            {
                Nombre = rolDto.Nombre != null ? rolDto.Nombre : string.Empty,
                Descripcion = rolDto.Descripcion != null ? rolDto.Descripcion : string.Empty
            };

            var roles = new List<Rol>();
            var countRow = 0;

            if (rolDto.SendRowCount == 2)
            {
                roles = await _rolDAL.BuscarPaginado(rol, skip: rolDto.Skip, take: rolDto.Take);
                if (roles.Count > 0)
                {
                    countRow = await _rolDAL.ContarResultRol(rol);
                }
            }
            else
            {
                roles = await _rolDAL.BuscarPaginado(rol, skip: rolDto.Skip, take: rolDto.Take);
            }

            var rolResult = new BuscarRolResultadosDto
            {
                Data = new List<BuscarRolResultadosDto.RolDto>(),
                CountRow = countRow
            };

            foreach (var item in roles)
            {
                rolResult.Data.Add(new BuscarRolResultadosDto.RolDto
                {
                    Id = item.Id,
                    Nombre = item.Nombre,
                    Descripcion = item.Descripcion
                });
            }

            return rolResult;

        }

        //obtener por id
        [HttpGet("{id}")]
        public async Task<Rol> ObtenerRolId(int id)
        {
            return await _rolDAL.ObtenerRolId(id);
        }


        //crear 
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearRolDto crearRolDto)
        {
            var rol = new Rol
            {
                Nombre = crearRolDto.Nombre,
                Descripcion = crearRolDto.Descripcion
            };

            int result = await _rolDAL.CrearRol(rol);

            if (result > 0)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(500);
            }

        }

        //actualizar
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] EditarRolDto editarRolDto)
        {
           var updateRol = await _rolDAL.ObtenerRolId(id);

            if (updateRol == null)
            {
                return NotFound();
            }

            updateRol.Nombre = editarRolDto.Nombre;
            updateRol.Descripcion = editarRolDto.Descripcion;

            int result = await _rolDAL.ActualizarRol(updateRol);

            if (result > 0)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(500);
            }   
        }

        //eliminar
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _rolDAL.EliminarRol(id);

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
