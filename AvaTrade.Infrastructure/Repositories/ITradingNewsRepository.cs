using AvaTrade.Domain.Entities.News;

namespace AvaTrade.Infrastructure.Repositories
{
    public interface ITradingNewsRepository : IAsyncRepository<TradingNews, int>, IRepository<TradingNews, int>
    {
        Task<IEnumerable<TradingNews>> GetLatestNewsGroupedByInstruments(int topCount);
    }
}