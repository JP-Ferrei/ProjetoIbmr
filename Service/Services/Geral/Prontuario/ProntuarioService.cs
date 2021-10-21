using Data.Interface.Geral.Prontuario;
using Data.Repository.Geral.Prontuario;
using Service.Interface.Geral.Prontuario;
using Service.Services.Shared;

namespace Service.Services.Geral.Prontuario
{
    public class ProntuarioService: CrudService<Domain.Entities.Prontuario.Prontuario, IProntuarioRepository>, IProntuarioService
    {
        public ProntuarioService(IProntuarioRepository repository) : base(repository)
        {
        }
    }
}
