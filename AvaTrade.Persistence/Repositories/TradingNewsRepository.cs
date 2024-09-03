using AvaTrade.Domain.Entities.News;
using AvaTrade.Infrastructure.Repositories;
using AvaTrade.Persistence.Contexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AvaTrade.Persistence.Repositories
{
    public class TradingNewsRepository : EfRepositoryBase<TradingNews, int, BaseDbContext>, ITradingNewsRepository
    {
        public TradingNewsRepository(BaseDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TradingNews>> GetLatestNewsGroupedByInstruments(int topCount)
        {
            var sql = @"
                    WITH RankedNews AS (
                        SELECT *,
                               ROW_NUMBER() OVER (PARTITION BY Ticker ORDER BY PublishedDate DESC) AS rn
                        FROM TradingNews
                    )
                    SELECT *
                    FROM RankedNews
                    WHERE rn = 1
                    ORDER BY PublishedDate DESC
                    OFFSET 0 ROWS FETCH NEXT @TopCount ROWS ONLY";

            return await Context.TradingNews.FromSqlRaw(sql, new SqlParameter("@TopCount", topCount))
                .ToListAsync();
        }
    }
}
