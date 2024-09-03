using AvaTrade.Infrastructure.Repositories;
using AvaTrade.Persistence.Contexts;
using AvaTrade.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AvaTrade.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("AvaTradeDatabaseConnection")));

            services.AddScoped<ITradingNewsRepository, TradingNewsRepository>();
            services.AddScoped<ITradingNewsSubscriptionRepository, TradingNewsSubscriptionRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
