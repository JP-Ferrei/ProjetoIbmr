using Data.Interface.Geral;
using Data.Repository.Geral;
using Domain.Entities;
using Service.Interface.Geral;
using Service.Services.Shared;

namespace Service.Services.Geral
{
    public class ConsultaService: CrudService<Consulta, IConsultaRepository>, IConsultaService
    {
        public ConsultaService(IConsultaRepository repository) : base(repository)
        {
        }
    }
}
