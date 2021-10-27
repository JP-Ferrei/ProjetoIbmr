using System;
using System.Threading.Tasks;
using ClinicaDentista.Controllers.Shared;
using Domain.Entities.Ator;
using Framework.Exceptions;
using Framework.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Interface.Geral.Ator;
using Service.Interface.Shared;

namespace ClinicaDentista.Controllers.Geral.Ator
{
    public class ClienteController: MasterCrudController<Cliente>
    {
        private readonly IClienteService _service;
        public ClienteController(ILogger<MasterCrudController<Cliente>> logger, IClienteService service, string includePatch = "") : base(logger, service, includePatch)
        {
            _service = service;
        }

        [HttpPost]
        public override async Task<ActionResult<Cliente>> Post(Cliente model)
        {
            try
            {
                await _service.Post(model);
                model.Senha = "";
                return Created(string.Empty, model);
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
