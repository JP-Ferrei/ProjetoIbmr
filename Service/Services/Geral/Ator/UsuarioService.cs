using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Data.Interface.Geral.Ator;
using Domain.Entities.Ator;
using Domain.Model;
using Framework.Exceptions;
using Framework.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.IdentityModel.Tokens;
using Service.Interface.Geral.Ator;
using Service.Services.Shared;

namespace Service.Services.Geral.Ator
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

        public async Task<string> Login(LoginModel model, string senha ,string jwtKey, double jwtExpireMinutes, string jwtIssuer,
            string role)
        {
            var user = await _repository.GetByIdAsync(model.UsuarioId);
            
            if( user == null )
            {
                throw new BadRequestException("Usuário não cadastrado no sistema");
            }
            var hasher = new PasswordHasher<Usuario>();
            if( hasher.VerifyHashedPassword(user, user?.GetSenha() ?? "", senha ) == PasswordVerificationResult.Failed )
                throw new BadRequestException("Login e/ou senha incorretos");

            return GenerateToken(user, jwtKey,jwtExpireMinutes, jwtIssuer, role);

        }

        private Usuario GerarSenha(Usuario usuario)
        {
            var hasher = new PasswordHasher<Usuario>();
            usuario.Senha = hasher.HashPassword(usuario, usuario.GetSenha());

            return usuario;
        }

        private bool VerificaSenha(Usuario usuario, string senha)
        {
            var hasher = new PasswordHasher<Usuario>();

            return hasher.VerifyHashedPassword(usuario, usuario.GetSenha(), senha) == PasswordVerificationResult.Success;
        }


        public override async Task Post(Usuario usuario)
        {
            if( string.IsNullOrEmpty(usuario.GetSenha()) )
                throw new BadRequestException("Informe uma senha válida!");
            
            if( LoginExistente(usuario) )
            {
                throw new BadRequestException("Já existe um usuário utilizando esse login");
            }
            else
            {
                usuario = GerarSenha(usuario);

                await base.Post(usuario);
            }
        }

        private bool LoginExistente(Usuario usuario)
        {
            return Get().Any(x => x.Email == usuario.Email);
        }
        
        public override async Task Patch(Guid id, JsonPatchDocument<Usuario> model, string include)
        {
            var domain = string.IsNullOrEmpty(include) ? await GetTracking(id) : await GetTracking(id, include);

            if( domain == null )
                throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

            model.ApplyTo(domain);

            await SaveChangesAsync();
        }
    }
}
