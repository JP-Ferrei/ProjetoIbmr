using Data.Context;
using Data.Interface.Geral.Ator;
using Data.Repository.Shared;
using Domain.Entities.Ator;

namespace Data.Repository.Geral.Ator
{
    public class ClienteRepository: CrudRepository<Cliente> , IClienteRepository
    {
        public ClienteRepository(ClinicaContext context) : base(context)
        {
        }
    }
}
