using AvaTrade.Domain.Entities.News;

namespace AvaTrade.Application.Services.News
{
    public interface ITradingNewsService
    {
        Task<IEnumerable<TradingNews>> GetAll();
        Task<IEnumerable<TradingNews>> GetAllNewsFromToday(DateTime toDate);
        Task<IEnumerable<TradingNews>> GetAllNewsByInstrument(string instrumentName, int limit);
        Task<IEnumerable<TradingNews>> GetAllNewsByText(string text);
        Task<IEnumerable<TradingNews>> GetLatestNewsGroupedByInstruments(int topCount);
    }
}
