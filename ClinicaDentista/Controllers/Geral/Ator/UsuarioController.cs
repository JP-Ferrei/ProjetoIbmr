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
    
    public class UsuarioController: MasterCrudController<Usuario>
    {
        private readonly IUsuarioService _service;
        public UsuarioController(ILogger<MasterCrudController<Usuario>> logger, IUsuarioService service, string includePatch = "") : base(logger, service, includePatch)
        {
            _service = service;
        }

        [HttpGet("{email}/email")]
        public async Task<ActionResult<Usuario>> BuscarPorEmail(string email)
        {
            try
            {
                var usuario = await _service.BuscarPorEmail(email);
                return Ok(usuario);
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
