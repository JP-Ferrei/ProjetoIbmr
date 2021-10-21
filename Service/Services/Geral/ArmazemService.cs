using Data.Interface.Geral;
using Data.Repository.Geral;
using Domain.Entities;
using Service.Interface.Geral;
using Service.Services.Shared;

namespace Service.Services.Geral
{
    public class ArmazemService: CrudService<Armazem, IArmazemRepository>, IArmazemService
    {
        public ArmazemService(IArmazemRepository repository) : base(repository)
        {
        }
    }
}
