using System.Threading.Tasks;
using Data.Interface.Geral;
using Data.Repository.Geral;
using Domain.Entities;
using Domain.Entities.Ator;
using Framework.Exceptions;
using Framework.Helpers;
using Service.Interface.Geral;
using Service.Interface.Geral.Ator;
using Service.Services.Shared;

namespace Service.Services.Geral
{
    public class ConsultaService: CrudService<Consulta, IConsultaRepository>, IConsultaService
    {
        private readonly IClienteService _clienteService;
        private readonly IDentistaService _dentistaService;
        
        public ConsultaService(IConsultaRepository repository, IClienteService clienteService, IDentistaService dentistaService) : base(repository)
        {
            _clienteService = clienteService;
            _dentistaService = dentistaService;
        }

        public override async Task<Consulta> Post(Consulta model)
        {
           // using (var transaction = _repository.BeginTransaction())
            //{
                var cliente = await _clienteService.Get(model.ClienteId);
                if (cliente == null)
                    throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);
                
                var dentista = await _dentistaService.Get(model.DentistaId);
                if (dentista == null)
                    throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

                await base.Post(model);

                await _repository.SaveChangesAsync();
              //  transaction.Commit();

                return model;
            //}
        }
    }

   
}
