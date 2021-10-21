using ClinicaDentista.Controllers.Shared;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Service.Interface.Shared;

namespace ClinicaDentista.Controllers.Geral
{
    public class ConsultaController: MasterCrudController<Consulta>
    {
        public ConsultaController(ILogger<MasterCrudController<Consulta>> logger, ICrudService<Consulta> service, string includePatch = "") : base(logger, service, includePatch)
        {
        }
    }
}
