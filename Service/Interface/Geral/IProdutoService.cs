using System.Threading.Tasks;
using Domain.Entities;
using Service.Interface.Shared;

namespace Service.Interface.Geral
{
    public interface IProdutoService: ICrudService<Produto>
    {
        
        Task<Produto> Post(Produto model);
    }
}
