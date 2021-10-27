using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interface.Shared;
using Domain.Model;

namespace Data.Interface.Shared
{
    public interface IQueryRepository<TEntity> where TEntity : class, IEntity
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task<TEntity> GetByIdAsync(Guid id, string include);
        Task<TEntity> GetByIdTrackingAsync(Guid id);
        Task<TEntity> GetByIdTrackingAsync(Guid id, string include);
        Task<TEntity> GetByIdNoIncludeAsync(Guid id);
        Task<TEntity> GetByIdTrackingNoFilterAsync(Guid id);
        IQueryable<TEntity> GetAll(string include = "");
        IQueryable<TEntity> GetAllNoInclude();
        SessionAppModel SessionApp { get; }
    }
}
