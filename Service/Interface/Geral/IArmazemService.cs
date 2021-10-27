using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Service.Interface.Shared;

namespace Service.Interface.Geral
{
    public interface IArmazemService: ICrudService<Armazem>
    {
        Task AdicionarProduto( Guid id ,Produto produtoId);
        Task<List<Produto>> GetProdutos(Guid id);
        Task<Armazem> GetFirst();
    }
}
