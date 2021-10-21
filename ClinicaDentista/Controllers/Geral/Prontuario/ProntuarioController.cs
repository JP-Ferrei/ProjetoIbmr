using ClinicaDentista.Controllers.Shared;
using Microsoft.Extensions.Logging;
using Service.Interface.Shared;

namespace ClinicaDentista.Controllers.Geral.Prontuario
{
    public class ProntuarioController: MasterCrudController<Domain.Entities.Prontuario.Prontuario>
    {
        public ProntuarioController(ILogger<MasterCrudController<Domain.Entities.Prontuario.Prontuario>> logger, ICrudService<Domain.Entities.Prontuario.Prontuario> service, string includePatch = "") : base(logger, service, includePatch)
        {
        }
    }
}
