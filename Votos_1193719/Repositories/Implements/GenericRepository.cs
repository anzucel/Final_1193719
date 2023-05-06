using Votos_1193719.Models;

namespace Votos_1193719.Repositories.Implements
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly VotesContext _context;

        public GenericRepository(VotesContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<TEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
