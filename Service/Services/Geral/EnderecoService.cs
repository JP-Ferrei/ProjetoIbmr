using Data.Interface.Geral.Prontuario;
using Data.Repository.Geral;
using Domain.Entities;
using Service.Interface.Geral;
using Service.Services.Shared;

namespace Service.Services.Geral
{
    public class EnderecoService: CrudService<Endereco, IEnderecoRepository>, IEnderecoService
    {
        public EnderecoService(IEnderecoRepository repository) : base(repository)
        {
        }
    }
}
