namespace AvaTrade.Application.Features.News.Queries.GetAllTradingNews
{
    public class GetAllTradingNewsResponse
    {
        public string Ticker { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Url { get; set; }
    }
}
