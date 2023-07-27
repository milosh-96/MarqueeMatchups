namespace MarqueeMatchups.Api.Infrastructure
{
    public interface IGenericRepository<T,K> 
    {
        T? GetById(K id);
        IEnumerable<T> GetAll();

        T? Create(object data);
        T? Update(K id,object data);
        bool Delete(K id);
    }
}
