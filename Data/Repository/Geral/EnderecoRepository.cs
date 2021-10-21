using Data.Context;
using Data.Interface.Geral.Prontuario;
using Data.Repository.Shared;
using Domain.Entities;

namespace Data.Repository.Geral
{
    public class EnderecoRepository: CrudRepository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(ClinicaContext context) : base(context)
        {
        }
    }
}
