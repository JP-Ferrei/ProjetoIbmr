using System;
using System.Threading.Tasks;
using ClinicaDentista.Controllers.Shared;
using Domain.Model;
using Framework.Exceptions;
using Framework.Helpers;
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
        public async Task<ActionResult<string>> Login([FromBody] LoginModel model, string senha)
        {
            try
            {
                var response = await _service.Login(model, senha, _configuration["JwtKey"],
                    double.Parse(_configuration["JwtExpireMinutes"]), _configuration["JwtIssuer"], model.Tipo);

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
