using ClinicaDentista.Controllers.Shared;
using Domain.Entities.Prontuario;
using Microsoft.Extensions.Logging;
using Service.Interface.Shared;

namespace ClinicaDentista.Controllers.Geral.Prontuario
{
    public class DocumentoController: MasterCrudController<Documento>
    {
        public DocumentoController(ILogger<MasterCrudController<Documento>> logger, ICrudService<Documento> service, string includePatch = "") : base(logger, service, includePatch)
        {
        }
    }
}
