namespace MarqueeMatchups.Core.Games
{
    public interface IGameRepository : IGenericRepository<Game,GameDto,int>
    {
        public ICollection<Game> GetFutureGames();
        public Task<ICollection<Game>> GetFutureGamesAsync();

        public ICollection<Game> GetFutureGamesBySport(SportValues sportId);
        public Task<ICollection<Game>> GetFutureGamesBySportAsync(SportValues sportId);
    }
}
