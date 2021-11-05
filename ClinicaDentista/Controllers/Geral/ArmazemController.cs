using System;
using System.Collections.Generic;
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
    [Authorize(Roles = "Recepcionista,Admin")]
    public class ArmazemController: MasterCrudController<Armazem>
    {
        private readonly IArmazemService _service;
        
        public ArmazemController(ILogger<MasterCrudController<Armazem>> logger, IArmazemService service, string includePatch = "") : base(logger, service, includePatch)
        {
            _service = service;
        }
         
        [HttpPost("AdicionarProduto")]
        public async Task<IActionResult> AdicionarProduto([FromBody] Produto produto)
        {
            try
            {
               await _service.AdicionarProduto(produto);
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

        [HttpGet("Produtos")]
        public async Task<ActionResult<List<Produto>>> GetProdutos()
        {
            try
            {
                var produtos = await _service.GetProdutos();
                return Ok(produtos);
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

        [HttpGet("First")]
        public async Task<ActionResult<Armazem>> GetFrist()
        {
            try
            {
                var armazem = await  _service.GetFirst();
                return Ok(armazem);
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
