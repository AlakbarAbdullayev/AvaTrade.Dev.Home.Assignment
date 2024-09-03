using AvaTrade.Domain.Common;

namespace AvaTrade.Domain.Entities.News
{
    public class TradingNews: Entity<int>
    {
        public string Ticker { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Url { get; set; }
    }
}
