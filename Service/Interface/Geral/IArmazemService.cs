using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Service.Interface.Shared;

namespace Service.Interface.Geral
{
    public interface IArmazemService: ICrudService<Armazem>
    {
        Task AdicionarProduto(Produto produtoId);
        Task<List<Produto>> GetProdutos();
        Task<Armazem> GetFirst();
    }
}
