using Data.Context;
using Data.Interface.Geral;
using Data.Repository.Shared;
using Domain.Entities;

namespace Data.Repository.Geral
{
    public class ArmazemRepository:CrudRepository<Armazem>, IArmazemRepository
    {
        public ArmazemRepository(ClinicaContext context) : base(context)
        {
        }
    }
}
