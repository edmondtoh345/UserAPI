using Consul;
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

            builder.Services.AddScoped<DataContext>();

            // builder.Services.AddScoped<IFavouriteRepository, FavouriteRepository>();
            // builder.Services.AddScoped<IFavouriteService, FavouriteService>();

            builder.Services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(consulConfig =>
            {
                consulConfig.Address = new System.Uri(builder.Configuration["ConsulConfig:ConsulAddress"]);
            }));

            // CORS Policy
            builder.Services.AddCors(options => options.AddPolicy("MyCorsPolicy", policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));

            var app = builder.Build();

            // For Consul
            app.UseConsul(builder.Configuration);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("MyCorsPolicy");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}