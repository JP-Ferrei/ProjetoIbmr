using System.Threading.Tasks;
using Data.Interface.Shared;
using Domain.Entities.Ator;

namespace Data.Interface.Geral.Ator
{
    public interface IUsuarioRepository: ICrudRepository<Usuario>
    {
        Task<Usuario> Login(string email);
        Task<Usuario> BuscarPorEmail(string email);
    }
}
