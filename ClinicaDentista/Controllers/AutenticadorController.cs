using System;
using System.Threading.Tasks;
using ClinicaDentista.Controllers.Shared;
using Domain.Model;
using Framework.Exceptions;
using Framework.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface.Geral.Ator;
using Microsoft.Extensions.Configuration;

namespace ClinicaDentista.Controllers
{
    public class AutenticadorController : MasterBaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IUsuarioService _service;

        public AutenticadorController(IUsuarioService service, IConfiguration configuration)
        {
            _configuration = configuration;
            _service = service;
        }

        
        [HttpPost("usuario")]
        [AllowAnonymous]
        public async Task<ActionResult<RetornoLoginmodel>> Login([FromBody] LoginModel model)
        {
            try
            {
                var response = await _service.Login(model.Email, model.Senha, _configuration["JwtKey"],
                    double.Parse(_configuration["JwtExpireMinutes"]));

                return Ok(response);

            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{MensagemHelper.AlgumErroOcorreu} {e.Message} - {e.InnerException?.Message}");
            }
        }

    }
}
