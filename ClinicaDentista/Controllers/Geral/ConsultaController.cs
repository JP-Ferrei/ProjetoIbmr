using System;
using System.Threading.Tasks;
using ClinicaDentista.Controllers.Shared;
using Domain.Entities;
using Framework.Exceptions;
using Framework.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Interface.Geral;
using Service.Interface.Shared;

namespace ClinicaDentista.Controllers.Geral
{
    public class ConsultaController : MasterCrudController<Consulta>
    {
        private readonly IConsultaService _service;

        public ConsultaController(ILogger<MasterCrudController<Consulta>> logger, IConsultaService service,
            string includePatch = "Clientes, Dentistas") : base(logger, service, includePatch)
        {
            _service = service;
        }


        [HttpPost]
        public async override Task<ActionResult<Consulta>> Post(Consulta model)
        {
            try
            {
                var consulta = await _service.Post(model);
                return Created(string.Empty, consulta);
            }
            catch (NotFoundException e)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError("{0} - {1}", e.Message, e.InnerException?.Message);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }
        }
    }
}
