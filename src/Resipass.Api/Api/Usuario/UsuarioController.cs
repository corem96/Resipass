using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resipass.Data.contexto;
using UsuarioModel = Resipass.Domain.modelos.Usuario.Usuario;

namespace Resipass.Api.Api.Usuario
{
    [Route("api/usuario")]
    public class UsuarioController : Controller
    {
        private readonly AppDbContext _dbContext;
        private const string InvalidDataString = "invalid data";

        public UsuarioController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        [HttpGet]
        public async Task<IActionResult> ObtenerTodo()
        {
            return Ok(await _dbContext.Tarjetas.ToListAsync());
        }
        
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] UsuarioModel modelo)
        {
            ModelState.Remove("Id");
            if (!ModelState.IsValid)
                return BadRequest(new {Error = InvalidDataString});

            try
            {
                _dbContext.Add(modelo);
                await _dbContext.SaveChangesAsync();

                return Ok(modelo);
            }
            catch (DbUpdateException e)
            {
                ModelState.AddModelError("error", "no es posible insertar los datos");
                return BadRequest(new {Error = e.Message});
            }
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] UsuarioModel modelo)
        {
            if (!ModelState.IsValid)
                return BadRequest(new {Error = InvalidDataString});

            try
            {
                _dbContext.Entry(modelo).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();

                return Ok(modelo);
            }
            catch (DbUpdateException e)
            {
                ModelState.AddModelError("error",
                    "No es posible actualizar datos");
                return BadRequest(new {Error = e.Message});
            }
        }
    }
}