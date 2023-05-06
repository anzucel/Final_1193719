using Votos_1193719.Repositories;

namespace Votos_1193719.Services.Implements
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        private IGenericRepository<TEntity> _repository;

        public GenericService(IGenericRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<TEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            await _repository.Insert(entity);
            return entity;
        }
    }
}
