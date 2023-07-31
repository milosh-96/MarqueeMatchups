using MarqueeMatchups.Api.Data;
using MarqueeMatchups.Api.Data.DTO;
using MarqueeMatchups.Api.Infrastructure;

namespace MarqueeMatchups.Api.Games
{
    public interface IGameRepository : IGenericRepository<Game,GameDto,int>
    {
    }
}
