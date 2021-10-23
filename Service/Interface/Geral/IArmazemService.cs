using System;
using System.Threading.Tasks;
using Domain.Entities;
using Service.Interface.Shared;

namespace Service.Interface.Geral
{
    public interface IArmazemService: ICrudService<Armazem>
    {
        Task AdicionarProduto(Guid armazemId, Guid produtoId);
    }
}
