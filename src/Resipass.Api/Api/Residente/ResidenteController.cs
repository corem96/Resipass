using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resipass.Data.contexto;
using ResidenteModel = Resipass.Domain.modelos.Residente.Residente;

namespace Resipass.Api.Api.Residente
{
    [Route("api/residente")]
    public class ResidenteController : Controller
    {
        private readonly AppDbContext _dbContext;
        private const string InvalidDataString = "invalid data";

        public ResidenteController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        [HttpGet]
        public async Task<IActionResult> ObtenerTodo()
        {
            return Ok(await _dbContext.Residentes.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] ResidenteModel modelo)
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
        public async Task<IActionResult> Actualizar([FromBody] ResidenteModel modelo)
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