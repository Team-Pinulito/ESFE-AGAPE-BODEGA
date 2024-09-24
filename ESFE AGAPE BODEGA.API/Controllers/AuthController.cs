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
        public async Task<IActionResult> Login(LoginUsuarioDTO loginUsuario)
        {
            var admin = await _usuarioDAL.GetUser(loginUsuario);

            if (admin is null)
            {
                return BadRequest(new { message = "Credenciales Invalidas." });
            }
            string jwtToken = GenerateToken(admin);

            return Ok(new {token = jwtToken});
        }

        private string GenerateToken(Usuario usuario)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuario.DUI),
                new Claim(ClaimTypes.Email, usuario.Password),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("JWT:key").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var SecurityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(8),
                signingCredentials: creds);

            string token = new JwtSecurityTokenHandler().WriteToken(SecurityToken);

            return token;
        }
    }
}
