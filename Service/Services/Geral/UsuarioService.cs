using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Data.Interface.Geral;
using Data.Interface.Shared;
using Domain.Entities.Ator;
using Domain.Model;
using Microsoft.IdentityModel.Tokens;
using Service.Interface.Geral;
using Service.Services.Shared;

namespace Service.Services.Geral
{
    public class UsuarioService: CrudService<Usuario,IUsuarioRepository>, IUsuarioService
    {
        
        
        public UsuarioService(IUsuarioRepository repository) : base(repository)
        {
        }
        
        
        
        
        public string GenerateToken(Usuario usuario, string jwtKey, double jwtExpireMinutes, string jwtIssuer, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtKey);
            var creds = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new []
                {
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim(ClaimTypes.Role, usuario.Tipo.Role),
                   
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = creds  
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<string> Loging(LoginModel model, string jwtKey, double jwtExpireMinutes, string jwtIssuer,
            string role)
        {
            
            return "    ";

        }

       
    }
}
