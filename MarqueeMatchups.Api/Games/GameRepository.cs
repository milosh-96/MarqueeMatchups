using MarqueeMatchups.Api.Data;
using MarqueeMatchups.Api.Infrastructure;

namespace MarqueeMatchups.Api.Matches
{
    public class GameRepository : IGenericRepository<Game,int>
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

        public Game Create(object data)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Game> GetAll()
        {
          
            return this.Games;
        }

        public Game? GetById(int id)
        {
            return this.Games.Where(x => x.Id == id).FirstOrDefault();
        }

        public Game Update(int id, object data)
        {
            throw new NotImplementedException();
        }
    }
}
