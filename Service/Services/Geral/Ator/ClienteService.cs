using System.Threading.Tasks;
using Data.Interface.Geral.Ator;
using Data.Repository.Shared;
using Domain.Entities.Ator;
using Framework.Exceptions;
using Service.Interface.Geral.Ator;
using Service.Services.Shared;

namespace Service.Services.Geral.Ator
{
    public class ClienteService: CrudService<Cliente, IClienteRepository>, IClienteService
    {
        private readonly IUsuarioService _usuarioService;

        public ClienteService(IClienteRepository repository, IUsuarioService usuarioService) : base(repository)
        {
            _usuarioService = usuarioService;
        }
        
        
        public override async Task Post(Cliente model)
        {
            using (var transaction = _repository.BeginTransaction())
            {
                    
                if( string.IsNullOrEmpty(model.GetSenha()) )
                    throw new BadRequestException("Informe uma senha válida!");
                
                if( _usuarioService.LoginExistente(model) )
                {
                    throw new BadRequestException("Já existe um usuário utilizando esse login");
                }
                
                _usuarioService.GerarSenha(model);
                
                await base.Post(model);

                var user = await _usuarioService.GetTracking(model.Id);

                user.TipoId = 3;

                await _repository.SaveChangesAsync();
                transaction.Commit();
            }
        }
    }
}
