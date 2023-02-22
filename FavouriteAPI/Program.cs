using FavouriteAPI.Models;
using FavouriteAPI.Repository;
using FavouriteAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace FavouriteAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var con = Environment.GetEnvironmentVariable("SQL_DB");
            if (con == null)
            {
                builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));
            }
            else
            {
                builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(con));
            }

            builder.Services.AddScoped<IFavouriteRepository, FavouriteRepository>();
            builder.Services.AddScoped<IFavouriteService, FavouriteService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}