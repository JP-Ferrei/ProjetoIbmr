using Data.Context;
using Data.Interface.Geral;
using Data.Repository.Shared;
using Domain.Entities;

namespace Data.Repository.Geral
{
    public class ConsultaRepository:CrudRepository<Consulta>, IConsultaRepository
    {
        public ConsultaRepository(ClinicaContext context) : base(context)
        {
        }
    }
}
