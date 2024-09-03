namespace AvaTrade.Application.Features.News.Queries.GetLatestTradingNewsByTop5DifferentInstruments
{
    public class GetNewsByTop5DifferentInstrumentsResponse
    {
        public string Ticker { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Url { get; set; }
    }
}
