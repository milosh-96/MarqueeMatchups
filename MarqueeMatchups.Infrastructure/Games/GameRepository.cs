using MarqueeMatchups.Core.Games;
using Microsoft.EntityFrameworkCore;

namespace MarqueeMatchups.Infrastructure.Games
{
    public class GameRepository : IGameRepository
    {
        

        private readonly DataDbContext _dbContext;

        public GameRepository(DataDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Game Create(GameDto data)
        {
            Game game = new Game();
            DateTimeOffset scheduledDateTime = DateTime.Parse(data.ScheduledAt).ToUniversalTime();
            game.Name = data.Name;
            game.SportId = data.SportId;
            game.Competition = data.Competition;
            game.ScheduledAt = scheduledDateTime;
            _dbContext.Set<Game>().Add(game);
            if(_dbContext.SaveChanges() < 1)
            {
                throw new Exception("there was an error while saving!");
            }
         
            return game;
        }

        public Task<Game?> CreateAsync(GameDto data)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Game> GetAll()
        {
            return this._dbContext.Set<Game>().ToList();
        }

        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            return await this._dbContext.Set<Game>().ToListAsync();
        }

        public Game? GetById(int id)
        {
            return this._dbContext.Set<Game>().Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task<Game?> GetByIdAsync(int id)
        {
            return await this._dbContext.Set<Game>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        // this query will keep matches that are started no more than 5 hours ago //
        private IQueryable<Game> GetFutureGamesQuery()
        {
            return this._dbContext.Set<Game>()
                .Where(x => (x.ScheduledAt - DateTimeOffset.UtcNow).TotalHours > -5)
                .OrderBy(x => x.ScheduledAt);
        } 
        public ICollection<Game> GetFutureGames()
        {
            return GetFutureGamesQuery().ToList();
        }
        public async Task<ICollection<Game>> GetFutureGamesAsync()
        {
            return await GetFutureGamesQuery().ToListAsync();
        }

        public async Task<ICollection<Game>> GetFutureGamesBySportAsync(SportValues sportId = SportValues.Football)
        {
            return await GetFutureGamesQuery().Where(x => x.SportId == (int)sportId)
                .ToListAsync();
        }

        public ICollection<Game> GetFutureGamesBySport(SportValues sportId)
        {
            throw new NotImplementedException();
        }

        public Game Update(int id, GameDto data)
        {
            throw new NotImplementedException();
        }

        public Task<Game?> UpdateAsync(int id, GameDto data)
        {
            throw new NotImplementedException();
        }
    }
}
