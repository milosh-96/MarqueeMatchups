using System.Threading.Tasks;

namespace MarqueeMatchups.Api.Infrastructure
{
    public interface IGenericRepository<T,K> 
    {
        T? GetById(K id);
        IEnumerable<T> GetAll();

        T? Create(object data);
        T? Update(K id,object data);
        bool Delete(K id);
        //async
        Task<T?> GetByIdAsync(K id);
        Task<IEnumerable<T>> GetAllAsync();

        Task<T?> CreateAsync(object data);
        Task<T?> UpdateAsync(K id, object data);
        Task<bool> DeleteAsync(K id);
    }
}
