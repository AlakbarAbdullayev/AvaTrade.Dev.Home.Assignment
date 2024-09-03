using AvaTrade.Domain.Entities.News;
using AvaTrade.Domain.Entities.Subscriptions;

namespace AvaTrade.Infrastructure.Repositories
{
    public interface ITradingNewsSubscriptionRepository : IAsyncRepository<TradingNewsSubscription, int>, IRepository<TradingNewsSubscription, int>
    {
    }
}
