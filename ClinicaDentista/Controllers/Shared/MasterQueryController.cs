using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interface.Shared;
using Framework.Exceptions;
using Framework.Helpers;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Interface.Shared;

namespace ClinicaDentista.Controllers.Shared
{
    [Authorize]
    public class MasterQueryController<TEntity> : MasterBaseController where TEntity : class, IEntity
    {
        protected readonly ILogger<MasterQueryController<TEntity>> _logger;
        private readonly IQueryService<TEntity> _service;

        public MasterQueryController(ILogger<MasterQueryController<TEntity>> logger, IQueryService<TEntity> service) : base()
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public virtual ActionResult<List<TEntity>> Get(ODataQueryOptions<TEntity> options, [FromHeader] string include)
        {
            try
            {
                var pageResult = GetPageResult(_service.Get(include), options);

                return Ok(pageResult);
            }
            catch (Exception e)
            {
                _logger.LogError("{0} - {1}", e.Message, e.InnerException?.Message);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TEntity>> GetById(long id, [FromHeader] string include)
        {
            try
            {
                var domain = await _service.Get(id, include);

                if (domain == null)
                    return NotFound(MensagemHelper.RegistroNaoEncontrato);

                return Ok(domain);
            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
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
