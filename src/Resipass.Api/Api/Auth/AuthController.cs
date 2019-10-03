using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Resipass.Api.Api.Usuario;
using Resipass.Data.contexto;
using UsuarioModel = Resipass.Domain.modelos.Usuario.Usuario;

namespace Resipass.Api.Api.Auth
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _dbContext;

        public AuthController(IConfiguration configuration, AppDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }
        
        [AllowAnonymous]
        [HttpPost]
        public IActionResult CrearToken([FromBody] UsuarioLogin usuarioLogin)
        {
            IActionResult response = Unauthorized();
            var usuario = Authenticate(usuarioLogin);

            if (usuario == null)
                return response;

            var tokenString = BuildToken(usuario);
            response = Ok(new { token = tokenString });

            return response;
        }

        private string BuildToken(UsuarioModel usuario)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credenciales);
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UsuarioModel Authenticate(UsuarioLogin login)
        {
            return _dbContext.Usuarios
                .FirstOrDefault(x => x.NombreUsuario == login.NombreUsuario
                                     && x.Password == login.Password);
        }
    }
}