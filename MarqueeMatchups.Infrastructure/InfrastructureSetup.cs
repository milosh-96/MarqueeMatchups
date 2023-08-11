using MarqueeMatchups.Core.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MarqueeMatchups.Core.Games;
using MarqueeMatchups.Infrastructure.Games;

namespace MarqueeMatchups.Infrastructure
{
    public static class InfrastructureSetup
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, string dbConnectionString)
        {
            var connectionString = dbConnectionString ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
           services.AddDbContext<DataDbContext>(options =>
                options.UseNpgsql(connectionString));
            services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<DataDbContext>();

            services.AddScoped<IGameRepository, GameRepository>();

            return services;
        } 
    }
}
