using System.Threading.Tasks;
using Data.Interface.Shared;
using Domain.Entities;

namespace Data.Interface.Geral
{
    public interface IProdutoRepository: ICrudRepository<Produto>
    {
        Task<Produto> GetProdutoByNome(string nome);
    }
}
