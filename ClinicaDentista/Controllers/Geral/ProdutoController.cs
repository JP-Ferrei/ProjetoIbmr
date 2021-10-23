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
        public ProdutoController(ILogger<MasterCrudController<Produto>> logger, IProdutoService service, string includePatch = "") : base(logger, service, includePatch)
        {
        }

       
    }
}
