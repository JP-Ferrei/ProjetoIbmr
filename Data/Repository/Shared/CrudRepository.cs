using System.Threading.Tasks;
using Data.Context;
using Data.Interface.Shared;
using Domain.Interface.Shared;
using Framework.Exceptions;
using Framework.Helpers;
using Microsoft.EntityFrameworkCore.Storage;

namespace Data.Repository.Shared
{
    public class CrudRepository<TEntity> : QueryRepository<TEntity>, ICrudRepository<TEntity> where TEntity : class, IEntity
    {
        public CrudRepository(ClinicaContext context) : base(context)
        {

        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }
        
        public async Task Insert(TEntity entity)
        {
            await _context.AddAsync(entity);
        }

        public async Task Remove(long id)
        {
            var entity = await GetByIdNoIncludeAsync(id);

            if (entity == null)
                throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

            _context.Remove(entity);
        }

        public void Remove(TEntity entity)
        {
            _context.Remove(entity);
        }

        public void Detached(TEntity entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
        }

        public async Task SaveChangesAsync()
        {

            await _context.SaveChangesAsync();
        }

        public virtual void Update(TEntity entity)
        {
            _context.Update(entity);
        }
    }
}
