using System;
using System.Threading.Tasks;
using Data.Context;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicaDentista.Controllers.Geral
{
    [Route("v1/[Controller]")]
    [ApiController]
    public class DentistaController: ControllerBase
    {
        private readonly ClinicaContext _context;

        public DentistaController(ClinicaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Dentista model)
        {
            try
            {
                var dentista = await _context.Dentistas.FirstOrDefaultAsync(x => x.Id == model.Id);
                if (dentista != null)
                    return BadRequest();

                await _context.Dentistas.AddAsync(model);
                await _context.SaveChangesAsync();

                return Created("", model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
