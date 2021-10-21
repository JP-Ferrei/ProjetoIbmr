using Data.Context;
using Data.Interface.Geral.Prontuario;
using Data.Repository.Shared;

namespace Data.Repository.Geral.Prontuario
{
    public class ProntuarioRepository: CrudRepository<Domain.Entities.Prontuario.Prontuario>, IProntuarioRepository
    {
        public ProntuarioRepository(ClinicaContext context) : base(context)
        {
        }
    }
}
