using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Data.Interface.Geral;
using Data.Repository.Shared;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.Geral
{
    public class ProdutoRepository: CrudRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ClinicaContext context) : base(context)
        {
        }

        public async Task<Produto> GetProdutoByNome(string nome)
        {
            return await _query.FirstOrDefaultAsync(x => x.Nome.ToLower().Trim() == nome.ToLower().Trim());
        }
    }
}
