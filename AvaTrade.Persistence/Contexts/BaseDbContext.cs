using AvaTrade.Domain.Entities.News;
using AvaTrade.Domain.Entities.Subscriptions;
using AvaTrade.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AvaTrade.Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options)
        {
        }

        public DbSet<TradingNews> TradingNews { get; set; }
        public DbSet<TradingNewsSubscription> TradingNewsSubscriptions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
