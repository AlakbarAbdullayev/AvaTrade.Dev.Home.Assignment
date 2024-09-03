using AvaTrade.Domain.Common;
using AvaTrade.Domain.Entities.Users;

namespace AvaTrade.Domain.Entities.Subscriptions
{
    public class TradingNewsSubscription : Entity<int>
    {
        public int UserId { get; set; }
        public DateTime SubscribedDate { get; set; }
        public bool IsActive { get; set; }
        public User User { get; set; }
    }
}
