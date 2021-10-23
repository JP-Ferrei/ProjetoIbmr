using System.Threading.Tasks;
using Domain.Entities.Ator;
using Service.Interface.Shared;

namespace Service.Interface.Geral.Ator
{
    public interface IRecepcionistaService:ICrudService<Recepcionista>
    {
        Task Post(Recepcionista entity);
    }
}
