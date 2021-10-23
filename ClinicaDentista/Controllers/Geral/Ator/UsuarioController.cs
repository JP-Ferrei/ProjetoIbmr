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
    
         
        
    }
}
