using ClinicaDentista.Controllers.Shared;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Service.Interface.Shared;

namespace ClinicaDentista.Controllers.Geral
{
    public class EnderecoController:MasterCrudController<Endereco>
    {
        public EnderecoController(ILogger<MasterCrudController<Endereco>> logger, ICrudService<Endereco> service, string includePatch = "") : base(logger, service, includePatch)
        {
        }
    }
}
