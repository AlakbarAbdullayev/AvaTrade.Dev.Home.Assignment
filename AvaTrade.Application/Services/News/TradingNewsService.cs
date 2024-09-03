using AvaTrade.Domain.Entities.News;
using AvaTrade.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AvaTrade.Application.Services.News
{
    public class TradingNewsService : ITradingNewsService
    {
        private readonly ITradingNewsRepository _tradingNewsRepository;

        public TradingNewsService(ITradingNewsRepository tradingNewsRepository)
        {
            _tradingNewsRepository = tradingNewsRepository;
        }

        public async Task<IEnumerable<TradingNews>> GetAll()
        {
            return await _tradingNewsRepository.GetAllAsync(orderBy: q=> q.OrderByDescending(n=> n.PublishedDate), enableTracking: false);
        }

        public async Task<IEnumerable<TradingNews>> GetAllNewsFromToday(DateTime toDate)
        {
            return await _tradingNewsRepository.GetAllAsync(predicate: (n => n.PublishedDate > DateTime.Now && n.PublishedDate <= toDate), orderBy: q => q.OrderByDescending(n => n.PublishedDate), enableTracking: false);
        }

        public async Task<IEnumerable<TradingNews>> GetAllNewsByInstrument(string instrumentName, int limit)
        {
            return await _tradingNewsRepository.GetAllAsync(take: limit, orderBy: q => q.OrderByDescending(n => n.PublishedDate), enableTracking: false);
        }

        public async Task<IEnumerable<TradingNews>> GetAllNewsByText(string text)
        {
            return await _tradingNewsRepository.GetAllAsync(predicate: (n => n.Title.Contains(text) ||
                        n.Summary.Contains(text)));
        }

        public async Task<IEnumerable<TradingNews>> GetLatestNewsGroupedByInstruments(int topCount)
        {
            return await _tradingNewsRepository.GetLatestNewsGroupedByInstruments(topCount);
        }
    }
}
