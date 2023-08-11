using MarqueeMatchups.Core.Games;
using MarqueeMatchups.Core.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace MarqueeMatchups.Infrastructure
{
    public class DataDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,int>
    {
        public DataDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Sport> Sports { get; set; }
    }
}
