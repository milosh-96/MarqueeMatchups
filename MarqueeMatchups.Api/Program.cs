using MarqueeMatchups.Api.Data;
using MarqueeMatchups.Api.Games;
using MarqueeMatchups.Api.Matches;
using Microsoft.EntityFrameworkCore;

namespace MarqueeMatchups.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    cors =>
                    {
                        cors.AllowAnyOrigin();
                    });
            });
            var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
            builder.Services.AddDbContext<DataDbContext>(options =>
            {
             options.UseNpgsql(connectionString);

            });
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // repositories //
            builder.Services.AddScoped<IGameRepository,GameRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowAll");
            app.UseHttpsRedirection();
            app.UseStatusCodePages();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}