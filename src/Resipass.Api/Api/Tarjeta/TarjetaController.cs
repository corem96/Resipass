using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resipass.Api.Api.ViewModels;
using Resipass.Data.contexto;
using TarjetaModel = Resipass.Domain.modelos.Tarjeta.Tarjeta;

namespace Resipass.Api.Api.Tarjeta
{
    [Route("api/tarjeta")]
    public class TarjetaController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private const string InvalidDataString = "invalid data";

        public TarjetaController(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> ObtenerTodo()
        {
            return Ok(await _dbContext.Tarjetas
                    .ProjectTo<TarjetaVm>(_mapper.ConfigurationProvider)
                    .ToListAsync());
        }

        [HttpGet("tarjeta-residente")]
        public async Task<IActionResult> ObtenerTarjetaResidente([FromQuery] int residenteId)
        {
            return Ok(await _dbContext.Tarjetas
                    .Where(x => x.ResidenteId == residenteId)
                    .SingleOrDefaultAsync());
        }
        
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] TarjetaModel modelo)
        {
            ModelState.Remove("Id");
            if (!ModelState.IsValid)
                return BadRequest(new {Error = InvalidDataString});

            try
            {
                modelo.Vigencia = DateTime.UtcNow.AddDays(30);
                
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
        public async Task<IActionResult> Actualizar([FromBody] TarjetaModel modelo)
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