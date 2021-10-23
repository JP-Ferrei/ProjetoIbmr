using Data.Context;
using Data.Interface.Geral.Ator;
using Data.Repository.Shared;
using Domain.Entities.Ator;

namespace Data.Repository.Geral.Ator
{
    public class RecepcionistaRepository:CrudRepository<Recepcionista>, IRecepcionistaRepository
    {
        public RecepcionistaRepository(ClinicaContext context) : base(context)
        {
        }
    }
}
