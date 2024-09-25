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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUsuarioDTO loginDTO)
        {
            var user = await ValidateUser(loginDTO.DUI, loginDTO.Password);
            if (user == null)
            {
                return Unauthorized("DUI o contraseña incorrectos");
            }

            var token = GenerateToken(user);

            // Registrar el token generado para verificar
            Console.WriteLine($"Token generado: {token}");

            return Ok(new { token });
        }

        private async Task<Usuario> ValidateUser(string dui, string password)
        {
            // Aquí se hace la consulta a la base de datos para validar el usuario
            var user = await _usuarioDAL.ObtenerUsuarioPorDUIyPassword(dui, password);
            if (user == null)
            {
                return null; // Usuario no encontrado
            }

            return user;
        }

        private string GenerateToken(Usuario user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.DUI),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
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
