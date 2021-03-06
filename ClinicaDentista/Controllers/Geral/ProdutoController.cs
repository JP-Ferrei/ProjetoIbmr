using System;
using System.Threading.Tasks;
using ClinicaDentista.Controllers.Shared;
using Data.Interface.Geral;
using Domain.Entities;
using Framework.Exceptions;
using Framework.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Interface.Geral;
using Service.Interface.Shared;

namespace ClinicaDentista.Controllers.Geral
{
    
    public class ProdutoController: MasterCrudController<Produto>
    {
        private readonly IProdutoService _service;
        public ProdutoController(ILogger<MasterCrudController<Produto>> logger, IProdutoService service, string includePatch = "") : base(logger, service, includePatch)
        {
            _service = service;
        }

        [HttpPost]
        public async override Task<ActionResult<Produto>> Post(Produto model)
        {
            try
            {
                var produto = await _service.Post(model);
                return Created(string.Empty, produto);
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
