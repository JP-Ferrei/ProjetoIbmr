using Data.Context;
using Data.Interface.Geral.Ator;
using Data.Repository.Shared;
using Domain.Entities.Ator;

namespace Data.Repository.Geral.Ator
{
    public class DentistaRepository: CrudRepository<Dentista>, IDentistaRepository
    {
        public DentistaRepository(ClinicaContext context) : base(context)
        {
        }
    }
}
