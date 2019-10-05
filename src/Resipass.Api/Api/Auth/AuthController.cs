using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Resipass.Api.Api.Usuario;
using Resipass.Data.contexto;
using ResidenteModel = Resipass.Domain.modelos.Residente.Residente;
using UsuarioModel = Resipass.Domain.modelos.Usuario.Usuario;

namespace Resipass.Api.Api.Auth
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly AppDbContext _dbContext;
        private const string InvalidDataString = "invalid data";

        public AuthController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        [HttpPost]
        public IActionResult Login([FromBody] UsuarioLogin loginDatos)
        {
            if (!ModelState.IsValid)
                return BadRequest(new {Error = InvalidDataString});

            if (loginDatos.EsUsuarioAdmin)
            {
                var usuario = AutentificarUsuario(loginDatos);
                if (usuario == null)
                    return NotFound("usuario inexistente");
                
                return Ok(usuario);
            }
            var residente = AutentificarResidente(loginDatos);
            if (residente == null)
                return NotFound("residente inexistente");
                
            return Ok(residente);
        }

        private UsuarioModel AutentificarUsuario(UsuarioLogin loginDatos)
        {
            return _dbContext.Usuarios
                .FirstOrDefault(x => x.NombreUsuario == loginDatos.NombreUsuario
                                     && x.Password == loginDatos.Password);
        }

        private ResidenteModel AutentificarResidente(UsuarioLogin loginDatos)
        {
            return _dbContext.Residentes
                .FirstOrDefault(x => x.NombreUsuario == loginDatos.NombreUsuario
                                     && x.Password == loginDatos.Password);
        }
    }
}