using MarqueeMatchups.Api.Data;
using MarqueeMatchups.Api.Infrastructure;

namespace MarqueeMatchups.Api.Games
{
    public interface IGameRepository : IGenericRepository<Game,int>
    {
    }
}
