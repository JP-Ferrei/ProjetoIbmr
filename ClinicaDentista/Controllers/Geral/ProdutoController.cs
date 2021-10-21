using ClinicaDentista.Controllers.Shared;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Service.Interface.Shared;

namespace ClinicaDentista.Controllers.Geral
{
    public class ProdutoController: MasterCrudController<Produto>
    {
        public ProdutoController(ILogger<MasterCrudController<Produto>> logger, ICrudService<Produto> service, string includePatch = "") : base(logger, service, includePatch)
        {
        }
    }
}
