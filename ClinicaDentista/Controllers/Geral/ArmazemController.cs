using System;
using System.Threading.Tasks;
using ClinicaDentista.Controllers.Shared;
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
    [Authorize(Roles = "Recepcinista")]
    public class ArmazemController: MasterCrudController<Armazem>
    {
        private readonly IArmazemService _service;
        
        public ArmazemController(ILogger<MasterCrudController<Armazem>> logger, IArmazemService service, string includePatch = "") : base(logger, service, includePatch)
        {
            _service = service;
        }
         
        [HttpPost("{armazemId}/AdicionarProduto/{produtoId}")]
        public async Task<IActionResult> AdicionarProduto(Guid armazemid, Guid produtoId)
        {
            try
            {
                _service.AdicionarProduto(armazemid, produtoId);
                return NoContent();
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
