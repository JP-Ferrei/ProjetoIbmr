using System;
using System.Threading.Tasks;
using Data.Interface.Shared;
using Domain.Interface.Shared;
using Framework.Exceptions;
using Framework.Helpers;
using Microsoft.AspNetCore.JsonPatch;
using Service.Interface.Shared;

namespace Service.Services.Shared
{
    public class CrudService<TEntity, TCrudRepository> : QueryService<TEntity, TCrudRepository>, ICrudService<TEntity> where TEntity : class, IEntity where TCrudRepository : ICrudRepository<TEntity>
    {
        public CrudService(TCrudRepository repository) : base(repository)
        {

        }

        public async virtual Task Delete(Guid id)
        {
            await _repository.Remove(id);

            await SaveChangesAsync();
        }

        public async virtual Task Delete(TEntity entity)
        {
            _repository.Remove(entity);

            await SaveChangesAsync();
        }

        public async virtual Task Post(TEntity entity, bool saveChanges = true)
        {
            await _repository.Insert(entity);

            if (saveChanges)
                await _repository.SaveChangesAsync();
        }

        public async virtual Task Post(TEntity entity)
        {
            await Post(entity, true);
        }

        public async virtual Task Put(TEntity entity)
        {
            _repository.Update(entity);

            await SaveChangesAsync();
        }

        public async virtual Task Patch(TEntity entity)
        {
            await SaveChangesAsync();
        }

        public async virtual Task Patch(Guid id, JsonPatchDocument<TEntity> model, string include)
        {
            var domain = string.IsNullOrEmpty(include) ? await GetTracking(id) : await GetTracking(id, include);
        
            if (domain == null)
                throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);
        
            model.ApplyTo(domain);
        
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _repository.SaveChangesAsync();
        }
    }
}
