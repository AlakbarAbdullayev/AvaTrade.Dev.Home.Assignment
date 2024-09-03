namespace AvaTrade.Application.Features.News.Queries.GetAllTradingNewsByInstrument
{
    public class GetAllTradingNewsByInstrumentResponse
    {
        public string Ticker { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Url { get; set; }
    }
}
