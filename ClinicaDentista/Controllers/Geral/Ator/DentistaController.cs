using System;
using System.Threading.Tasks;
using ClinicaDentista.Controllers.Shared;
using Domain.Entities.Ator;
using Framework.Exceptions;
using Framework.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Interface.Geral.Ator;
using Service.Interface.Shared;

namespace ClinicaDentista.Controllers.Geral.Ator
{
    public class DentistaController: MasterCrudController<Dentista>
    {
        private readonly IDentistaService _service;
        public DentistaController(ILogger<MasterCrudController<Dentista>> logger, IDentistaService service, string includePatch = "") : base(logger, service, includePatch)
        {
            _service = service;
        }

        [HttpPost]
        [AllowAnonymous]
        public override async Task<ActionResult<Dentista>> Post(Dentista model)
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
