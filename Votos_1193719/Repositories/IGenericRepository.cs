namespace Votos_1193719.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> Insert(TEntity entity);
    }
}
