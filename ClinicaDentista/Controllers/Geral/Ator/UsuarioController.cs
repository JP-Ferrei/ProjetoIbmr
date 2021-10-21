using ClinicaDentista.Controllers.Shared;
using Domain.Entities.Ator;
using Microsoft.Extensions.Logging;
using Service.Interface.Shared;

namespace ClinicaDentista.Controllers.Geral.Ator
{
    public class UsuarioController: MasterCrudController<Usuario>
    {
        public UsuarioController(ILogger<MasterCrudController<Usuario>> logger, ICrudService<Usuario> service, string includePatch = "") : base(logger, service, includePatch)
        {
        }
        
        
    }
}
