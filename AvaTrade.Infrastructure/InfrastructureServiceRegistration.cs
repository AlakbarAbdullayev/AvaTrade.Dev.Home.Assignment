using AvaTrade.Infrastructure.Security.JWT;
using Microsoft.Extensions.DependencyInjection;

namespace AvaTrade.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            services.AddScoped<ITokenHelper, JwtHelper>();
            return services;
        }
    }
}
