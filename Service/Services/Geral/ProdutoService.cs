using Data.Interface.Geral;
using Data.Repository.Geral;
using Domain.Entities;
using Service.Interface.Geral;
using Service.Services.Shared;

namespace Service.Services.Geral
{
    public class ProdutoService: CrudService<Produto, IProdutoRepository>, IProdutoService
    {
        public ProdutoService(IProdutoRepository repository) : base(repository)
        {
        }
        
    }
}
