using System.Threading.Tasks;
using Domain.Interface.Shared;
using Microsoft.EntityFrameworkCore.Storage;

namespace Data.Interface.Shared
{
    public interface ICrudRepository<TEntity> : IQueryRepository<TEntity> where TEntity : class, IEntity
    {
        IDbContextTransaction BeginTransaction();
        Task Insert(TEntity entity);
        void Update(TEntity entity);
        Task Remove(long id);
        void Remove(TEntity entity);
        void Detached(TEntity entity);
        Task SaveChangesAsync();
    }
}
