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
    }
}
