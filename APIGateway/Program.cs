using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;
using System.Text;

namespace APIGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // To configure the Ocelot.json file
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("ocelot.json").Build();
            
            // To use Ocelot and Consul for service discovery
            builder.Services.AddOcelot(config).AddConsul();

            // Authentication Code
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("code_crusaders_secret_key_for_user"));
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,

                ValidateIssuer = true,
                ValidIssuer = "authapi",

                ValidateAudience = true,
                ValidAudience = "userapi"
            });

            var app = builder.Build();

            app.UseOcelot();
            app.UseAuthentication();

            app.Run();
        }
    }
}