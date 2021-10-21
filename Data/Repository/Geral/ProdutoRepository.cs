using Data.Context;
using Data.Interface.Geral;
using Data.Repository.Shared;
using Domain.Entities;

namespace Data.Repository.Geral
{
    public class ProdutoRepository: CrudRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ClinicaContext context) : base(context)
        {
        }
    }
}
