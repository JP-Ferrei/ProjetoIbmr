using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Data.Interface.Geral;
using Data.Repository.Shared;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.Geral
{
    public class ArmazemRepository:CrudRepository<Armazem>, IArmazemRepository
    {
        public ArmazemRepository(ClinicaContext context) : base(context)
        {
            
        }


        public async Task<Armazem> GetFirst()
        {
            return await _query.FirstOrDefaultAsync();
        }
    }
}
