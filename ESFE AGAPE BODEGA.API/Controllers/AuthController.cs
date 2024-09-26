using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using ESFE_AGAPE_BODEGA.DTOs.UsuarioDTOs;
using ESFE_AGAPE_BODEGA.API.Models.DAL;
using ESFE_AGAPE_BODEGA.API.Models.Entitys;
using Microsoft.AspNetCore.Authorization;

namespace ESFE_AGAPE_BODEGA.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UsuarioDAL _usuarioDAL;

        private IConfiguration _config;

        public AuthController(UsuarioDAL usuarioDAL, IConfiguration config)
        {
            _usuarioDAL = usuarioDAL;
            _config = config;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Login([FromBody]LoginUsuarioDTO loginUsuario)
        {
            if (loginUsuario == null || string.IsNullOrEmpty(loginUsuario.DUI) || string.IsNullOrEmpty(loginUsuario.Password))
            {
                return BadRequest(new { message = "Usuario y contraseña son requeridos." });
            }

            Usuario admin;
            try
            {
                admin = await _usuarioDAL.GetUser(loginUsuario);
            }
            catch (Exception ex)
            {
                // Log el error si es necesario
                return StatusCode(500, new { message = "Error al autenticar al usuario." });
            }

            if (admin is null)
            {
                return BadRequest(new { message = "Credenciales Invalidas." });
            }

            string jwtToken = GenerateToken(admin);

            return Ok(new
            {
                token = jwtToken,
                nombre = admin.Nombre,
                apellido = admin.Apellido,
                rol = admin.Rol.Nombre
            });
        }

        private string GenerateToken(Usuario usuario)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuario.Nombre),
                new Claim("Apellido", usuario.Apellido),
                new Claim(ClaimTypes.Role, usuario.Rol.Nombre),
            };

            var token = new JwtSecurityToken(
             issuer: _config["JWT:issuer"],
             audience: _config["JWT:audience"],
              claims: claims,
              expires: DateTime.Now.AddHours(8),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
