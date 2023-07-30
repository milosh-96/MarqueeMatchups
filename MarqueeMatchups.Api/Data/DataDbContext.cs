using Microsoft.EntityFrameworkCore;

namespace MarqueeMatchups.Api.Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Sport> Sports { get; set; }
    }
}
