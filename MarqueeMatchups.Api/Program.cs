using MarqueeMatchups.Api.Data;
using MarqueeMatchups.Api.Data.Identity;
using MarqueeMatchups.Api.Games;
using MarqueeMatchups.Api.Matches;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using static System.Net.WebRequestMethods;

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
                        cors.WithOrigins(
                            new[] { "http://localhost:4200" }
                            );
                        cors.WithHeaders(new[]
                        {
                            "Content-Type"
                        });
                        cors.AllowAnyOrigin();
                    });
            });
            var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
            builder.Services.AddDbContext<DataDbContext>(options =>
            {
                options.UseNpgsql(connectionString);

            });

            // add identity
            builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<DataDbContext>();
            builder.Services.ConfigureApplicationCookie(c =>
            {
                c.LoginPath = "/login";
            });
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme);
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // repositories //
            builder.Services.AddScoped<IGameRepository, GameRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseStatusCodePages();

            //cors
            app.UseCors("AllowAll");
            //

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            app.MapFallbackToFile("index.html");
            app.Run();
        }
    }
}