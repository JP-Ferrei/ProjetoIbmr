using System.Threading.Tasks;
using Data.Interface.Geral.Ator;
using Domain.Entities.Ator;
using Framework.Exceptions;
using Framework.Helpers;
using Service.Interface.Geral.Ator;
using Service.Services.Shared;

namespace Service.Services.Geral.Ator
{
    public class DentistaService : CrudService<Dentista, IDentistaRepository>, IDentistaService
    {
        private readonly IUsuarioService _usuarioService;

        public DentistaService(IDentistaRepository repository, IUsuarioService service) : base(repository)
        {
            _usuarioService = service;
        }

        public override async Task Post(Dentista model)
        {
            if (string.IsNullOrEmpty(model.GetSenha()))
                throw new BadRequestException("Informe uma senha válida!");

            if (_usuarioService.LoginExistente(model))
            {
                throw new BadRequestException("Já existe um usuário utilizando esse login");
            }

            _usuarioService.GerarSenha(model);

            await base.Post(model);

            var user = await _usuarioService.GetTracking(model.Id);

            user.TipoId = 2;

            await _repository.SaveChangesAsync();
        }
    }
}
