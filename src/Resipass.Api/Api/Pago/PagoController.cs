using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resipass.Data.contexto;
using Resipass.Domain.modelos.RegistroPago;

namespace Resipass.Api.Api.Pago
{
    [Route("api/pago")]
    public class PagoController : Controller
    {
        private readonly AppDbContext _dbContext;

        public PagoController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("reporte-pagos")]
        public async Task<IActionResult> ReportePagos([FromQuery] int residenteId)
        {
            var tarjeta = await _dbContext.Tarjetas
                .Where(x => x.ResidenteId == residenteId)
                .SingleOrDefaultAsync();
            
            return Ok(await _dbContext.RegistroPagos
                .Where(x =>
                    x.FechaPago >= DateTime.Now.AddMonths(-12)
                    && x.FechaPago <= DateTime.Now
                    && x.TarjetaId == tarjeta.Id)
                .ToListAsync());
        }

        [HttpGet("pagos-mes")]
        public async Task<IActionResult> ReportePagosMensual()
        {
            return Ok(await _dbContext.RegistroPagos
                .Where(x =>
                    x.FechaPago >= DateTime.Now.AddMonths(-1).AddDays(1)
                    && x.FechaPago <= DateTime.Now.AddMonths(1).AddDays(-1))
                .Include(x => x.Tarjeta)
                .ToListAsync());
        }
        
        [HttpPost]
        public async Task<IActionResult> CrearPago([FromBody] RegistroPago modelo)
        {
            ModelState.Remove("Id");
            if (!ModelState.IsValid)
                return BadRequest(new {Error = "Invalid data"});
            
            try
            {
                modelo.FechaPago = DateTime.UtcNow;
                modelo.FechaVencimiento = DateTime.UtcNow.AddMonths(1);
                
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
    }
}