using System;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Data.Interface.Shared;
using Domain.Interface.Shared;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.Shared
{
    public class QueryRepository<TEntity> : IQueryRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly ClinicaContext _context;
        protected IQueryable<TEntity> _query;

     

        public QueryRepository(ClinicaContext context)
        {
            _context = context;
            _query = _context.Set<TEntity>();

           
        }

        protected IQueryable<TEntity> SetInclude(IQueryable<TEntity> query, string include)
        {
            if (string.IsNullOrEmpty(include))
                return query;

            var includes = include.Split(",");

            foreach (var item in includes)
                query = query.Include(item.Trim());

            return query;
        }

        public IQueryable<TEntity> GetAll(string include = "")
        {
            var query = SetInclude(GetAllNoInclude(), include);

            return string.IsNullOrEmpty(include) ? _query : query;
        }

        public IQueryable<TEntity> GetAllNoInclude()
        {
            return _context.Set<TEntity>();
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _query.AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id, string include)
        {
            var query = SetInclude(GetAllNoInclude(), include);

            return await query.AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<TEntity> GetByIdNoIncludeAsync(Guid id)
        {
            return await _context.Set<TEntity>().AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<TEntity> GetByIdTrackingAsync(Guid id)
        {
            return await _query.SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<TEntity> GetByIdTrackingAsync(Guid id, string include)
        {
            var query = SetInclude(GetAllNoInclude(), include);

            return await query.SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<TEntity> GetByIdTrackingNoFilterAsync(Guid id)
        {
            return await _query.IgnoreQueryFilters().SingleOrDefaultAsync(x => x.Id.Equals(id));
        }
    }
}
