using MarqueeMatchups.Api.Data;
using MarqueeMatchups.Api.Data.DTO;
using MarqueeMatchups.Api.Infrastructure;

namespace MarqueeMatchups.Api.Games
{
    public interface IGameRepository : IGenericRepository<Game,GameDto,int>
    {
        public ICollection<Game> GetFutureGames();
        public Task<ICollection<Game>> GetFutureGamesAsync();

        public ICollection<Game> GetFutureGamesBySport(SportValues sportId);
        public Task<ICollection<Game>> GetFutureGamesBySportAsync(SportValues sportId);
    }
}
