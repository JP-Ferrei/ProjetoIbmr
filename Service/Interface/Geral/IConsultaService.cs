using System.Threading.Tasks;
using Domain.Entities;
using Service.Interface.Shared;

namespace Service.Interface.Geral
{
    public interface IConsultaService: ICrudService<Consulta>
    {
        Task<Consulta> Post(Consulta model);
    }
}
