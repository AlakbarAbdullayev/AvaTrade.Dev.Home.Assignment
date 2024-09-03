using AvaTrade.Domain.Entities.Subscriptions;
using AvaTrade.Infrastructure.Repositories;
using AvaTrade.Persistence.Contexts;

namespace AvaTrade.Persistence.Repositories
{
    public class TradingNewsSubscriptionRepository : EfRepositoryBase<TradingNewsSubscription, int, BaseDbContext>, ITradingNewsSubscriptionRepository
    {
        public TradingNewsSubscriptionRepository(BaseDbContext context) : base(context)
        {

        }
    }
}
