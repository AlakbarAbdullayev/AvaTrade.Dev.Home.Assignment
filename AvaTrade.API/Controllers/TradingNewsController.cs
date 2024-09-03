using AvaTrade.API.Common;
using AvaTrade.Application.Features.News.Queries.GetAllTradingNews;
using AvaTrade.Application.Features.News.Queries.GetAllTradingNewsByInstrument;
using AvaTrade.Application.Features.News.Queries.GetAllTradingNewsByText;
using AvaTrade.Application.Features.News.Queries.GetAllTradingNewsFromToday;
using AvaTrade.Application.Features.News.Queries.GetLatestTradingNewsByTop5DifferentInstruments;
using AvaTrade.Application.Features.Subscriptions.Commands.TradingNewsSubscription;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AvaTrade.API.Controllers
{
    [Authorize]
    public class TradingNewsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetAllTradingNewsQuery query = new GetAllTradingNewsQuery();

            var response = await Mediator.Send(query);

            return Ok(new ApiResponse<IEnumerable<GetAllTradingNewsResponse>>(response));
        }

        [Authorize]
        [HttpGet("get-all-news-from-today/{daysAgo}")]
        public async Task<IActionResult> GetAllTradingNewsFromToday(int daysAgo)
        {
            // Calculate the date from 'daysAgo' days ago
            var fromDate = DateTime.UtcNow.AddDays(-daysAgo);
            var query = new GetAllTradingNewsFromTodayQuery(fromDate);

            var response = await Mediator.Send(query);

            return Ok(new ApiResponse<IEnumerable<GetAllTradingNewsFromTodayResponse>>(response));
        }

        [Authorize]
        [HttpGet("get-news-by-instrument/{instrumentName}")]
        public async Task<IActionResult> GetTradingNewsByInstrument(string instrumentName, [FromQuery] int limit = 10)
        {
            // Ensure the limit is positive
            limit = limit <= 0 ? 10 : limit;

            var query = new GetAllTradingNewsByInstrumentQuery(instrumentName, limit);

            var response = await Mediator.Send(query);

            return Ok(new ApiResponse<IEnumerable<GetAllTradingNewsByInstrumentResponse>>(response));
        }

        [Authorize]
        [HttpGet("get-news-by-text")]
        public async Task<IActionResult> GetTradingNewsByText([FromQuery] string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return BadRequest("Search text cannot be empty.");
            }

            var query = new GetAllTradingNewsByTextQuery(text);

            var response = await Mediator.Send(query);

            return Ok(new ApiResponse<IEnumerable<GetAllTradingNewsByTextResponse>>(response));
        }

        [Authorize]
        [HttpPost("subscribe")]
        public async Task<IActionResult> Subscribe()
        {
            var response = await Mediator.Send(new TradingNewsSubscriptionCommand());

            return Ok(new ApiResponse<TradingNewsSubscriptionResponse>(response));
        }

        [AllowAnonymous]
        [HttpGet("get-news-by-top5-different-instruments")]
        public async Task<IActionResult> GetNewsByTop5DifferentInstruments()
        {
            var query = new GetTradingNewsByTop5DifferentInstrumentsQuery();
            var response = await Mediator.Send(query);
            return Ok(new ApiResponse<IEnumerable<GetNewsByTop5DifferentInstrumentsResponse>>(response));
        }
    }
}
