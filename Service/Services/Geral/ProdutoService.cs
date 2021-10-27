using System.Threading.Tasks;
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

        public override async Task<Produto> Post(Produto model)
        {
            var produto = await _repository.GetProdutoByNome(model.Nome);

            if (produto == null)
            {
                await _repository.Insert(model);
                await _repository.SaveChangesAsync();
                return model;
            }

            produto.Quantidade += model.Quantidade;

            await _repository.SaveChangesAsync();

            return produto;
        }
    }
}
