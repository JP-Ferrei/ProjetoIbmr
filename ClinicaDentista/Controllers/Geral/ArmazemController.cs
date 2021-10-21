using ClinicaDentista.Controllers.Shared;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Service.Interface.Shared;

namespace ClinicaDentista.Controllers.Geral
{
    public class ArmazemController: MasterCrudController<Armazem>
    {
        public ArmazemController(ILogger<MasterCrudController<Armazem>> logger, ICrudService<Armazem> service, string includePatch = "") : base(logger, service, includePatch)
        {
        }
    }
}
