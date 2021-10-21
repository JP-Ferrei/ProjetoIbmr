using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interface.Shared;

namespace Service.Interface.Shared
{
    public interface IQueryService<TEntity> where TEntity : class, IEntity
    {
        Task<TEntity> Get(Guid id);
        Task<TEntity> Get(Guid id, string include);
        Task<TEntity> GetTracking(Guid id);
        Task<TEntity> GetTracking(Guid id, string include);
        Task<TEntity> GetTrackingNoFilter(Guid id);
        IQueryable<TEntity> Get(string include = "");
        IQueryable<TEntity> GetNoInclude();
        Task<TEntity> GetNoInclude(Guid id);
        
    }
}
