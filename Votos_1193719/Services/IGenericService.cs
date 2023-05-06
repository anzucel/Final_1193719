namespace Votos_1193719.Services
{
    public interface IGenericService<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> Insert(TEntity entity);
    }
}
