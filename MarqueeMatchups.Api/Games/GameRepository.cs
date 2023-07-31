using MarqueeMatchups.Api.Data;
using MarqueeMatchups.Api.Data.DTO;
using MarqueeMatchups.Api.Games;
using MarqueeMatchups.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MarqueeMatchups.Api.Matches
{
    public class GameRepository : IGameRepository
    {
        private readonly IEnumerable<Game> Games = new[]
       {
             new Game {
                Id = 1,
                Name="Everton - Fulham",
                ScheduledAt = new DateTimeOffset(new DateTime(2023,08,12,16,00,00,DateTimeKind.Local)),
                SportId=1,
                Competition="Premier League"
            },
            new Game {
                Id = 2,
                Name="Chelsea - Liverpool",
                ScheduledAt = new DateTimeOffset(new DateTime(2023,08,13,17,30,00,DateTimeKind.Local)),
                SportId=1,
                Competition="Premier League"
            },
             new Game {
                Id = 3,
                Name="Manchester United - Wolverhampton",
                ScheduledAt = new DateTimeOffset(new DateTime(2023,08,14,21,00,00,DateTimeKind.Local)),
                SportId=1,
                Competition="Premier League"
            }

        };

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
