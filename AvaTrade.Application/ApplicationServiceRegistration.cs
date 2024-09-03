using AvaTrade.Application.Services.Auth;
using AvaTrade.Application.Services.News;
using AvaTrade.Application.Services.Users;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AvaTrade.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITradingNewsService, TradingNewsService>();

            return services;
        }
    }
}
