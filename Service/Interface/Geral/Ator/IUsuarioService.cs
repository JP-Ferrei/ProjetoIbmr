using System.Threading.Tasks;
using Domain.Entities.Ator;
using Domain.Model;
using Service.Interface.Shared;

namespace Service.Interface.Geral.Ator
{
    public interface IUsuarioService: ICrudService<Usuario>
    {
        string GenerateToken(Usuario usuario, string jwtKey, double jwtExpireMinutes);

        Task<string> Login(string email, string senha, string jwtKey, double jwtExpireMinutes);

        new Task<Usuario> Post(Usuario usuario);
        bool LoginExistente(Usuario usuario);
        void GerarSenha(Usuario usuario);
    }
}
