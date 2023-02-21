using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace UserAPI
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public static class ServiceRegistryExtension
    {
        // Creating Middleware for registering service on Consul

        public static IApplicationBuilder UseConsul(this IApplicationBuilder app, IConfiguration configurationSetting)
        {
            var consulClient = app.ApplicationServices.GetRequiredService<IConsulClient>();
            var logger = app.ApplicationServices.GetRequiredService<ILoggerFactory>().CreateLogger("AppExtension");
            var lifetime = app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>();

            // Registration configuration from appsettings.json file
            var registration = new AgentServiceRegistration()
            {
                ID = configurationSetting["ConsulConfig:ServiceName"],
                Name = configurationSetting["ConsulConfig:ServiceName"],
                Address = configurationSetting["ConsulConfig:ServiceHost"],
                Port = int.Parse(configurationSetting["ConsulConfig:ServicePort"])
            };

            logger.LogInformation("Registering with consul");
            // Registering the service with service ID
            consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(true);
            consulClient.Agent.ServiceRegister(registration).ConfigureAwait(true);

            lifetime.ApplicationStopped.Register(() =>
            {
                logger.LogInformation("Unregistering service from consul");
                consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(!true);
            });
            return app;
        }
    }
}
