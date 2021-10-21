using Data.Context;
using Data.Interface.Geral;
using Data.Interface.Geral.Ator;
using Data.Repository.Shared;
using Domain.Entities.Ator;

namespace Data.Repository.Geral.Ator
{
    public class UsuarioRepository:CrudRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ClinicaContext context) : base(context)
        {
        }
    }
}
