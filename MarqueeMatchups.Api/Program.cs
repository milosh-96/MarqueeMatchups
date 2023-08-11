using MarqueeMatchups.Core.Games;
using MarqueeMatchups.Core.Identity;
using MarqueeMatchups.Core.Services;
using MarqueeMatchups.Infrastructure;
using MarqueeMatchups.Infrastructure.Games;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
                            "Content-Type",
                            "Authorization"
                        });
                       // cors.AllowAnyOrigin();
                       // cors.AllowCredentials();
                    });
            });
            var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];

            builder.Services.RegisterInfrastructure(connectionString);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                var key = Encoding.UTF8.GetBytes(builder.Configuration["Authentication:JWT:Key"]);
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Authentication:JWT:Issuer"],
                    ValidAudience = builder.Configuration["Authentication:JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });
            builder.Services.AddAuthorization();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


            // repositories //
            builder.Services.AddScoped<IGameRepository, GameRepository>();
            builder.Services.AddScoped<IJwtTokenGeneratorService, JwtTokenGeneratorService>();

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