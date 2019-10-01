using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resipass.Data.contexto;
using AvisoModel = Resipass.Domain.modelos.Aviso.Aviso;

namespace Resipass.Api.Api.Aviso
{
    [Route("api/aviso")]
    public class AvisoController : Controller
    {
        private readonly AppDbContext _dbContext;
        private const string InvalidDataString = "invalid data";

        public AvisoController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        [HttpGet]
        public async Task<IActionResult> ObtenerTodo()
        {
            return Ok(await _dbContext.Avisos.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] AvisoModel modelo)
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
        public async Task<IActionResult> Actualizar([FromBody] AvisoModel modelo)
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