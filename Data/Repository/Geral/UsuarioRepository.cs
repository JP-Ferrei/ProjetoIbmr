using Data.Context;
using Data.Interface.Geral;
using Data.Repository.Shared;
using Domain.Entities.Ator;

namespace Data.Repository.Geral
{
    public class UsuarioRepository:CrudRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ClinicaContext context) : base(context)
        {
        }
    }
}
