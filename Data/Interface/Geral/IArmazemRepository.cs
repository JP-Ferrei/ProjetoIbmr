using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Interface.Shared;
using Domain.Entities;

namespace Data.Interface.Geral
{
    public interface IArmazemRepository: ICrudRepository<Armazem>
    {
        Task<Armazem> GetFirst();
    }
}
