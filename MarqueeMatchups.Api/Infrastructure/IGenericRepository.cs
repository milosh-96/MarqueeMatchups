using MarqueeMatchups.Api.Data.DTO;
using System.Threading.Tasks;

namespace MarqueeMatchups.Api.Infrastructure
{
    public interface IGenericRepository<T,Dto,Key> 
    {
        T? GetById(Key id);
        IEnumerable<T> GetAll();

        T? Create(Dto data);
        T? Update(Key id,Dto data);
        bool Delete(Key id);
        //async
        Task<T?> GetByIdAsync(Key id);
        Task<IEnumerable<T>> GetAllAsync();

        Task<T?> CreateAsync(Dto data);
        Task<T?> UpdateAsync(Key id, Dto data);
        Task<bool> DeleteAsync(Key id);
    }
}
