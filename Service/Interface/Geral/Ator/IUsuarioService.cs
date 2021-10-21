using System.Threading.Tasks;
using Domain.Entities.Ator;
using Domain.Model;
using Service.Interface.Shared;

namespace Service.Interface.Geral.Ator
{
    public interface IUsuarioService: ICrudService<Usuario>
    {
        string GenerateToken(Usuario usuario, string jwtKey, double jwtExpireMinutes, string jwtIssuer, string role);

        Task<string> Login(LoginModel model,string senha, string jwtKey, double jwtExpireMinutes, string jwtIssuer,
            string role);
    }
}
