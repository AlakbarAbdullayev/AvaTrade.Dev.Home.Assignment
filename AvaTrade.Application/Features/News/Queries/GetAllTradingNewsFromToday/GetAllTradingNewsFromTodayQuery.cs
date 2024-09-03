using AutoMapper;
using AvaTrade.Application.Services.News;
using MediatR;

namespace AvaTrade.Application.Features.News.Queries.GetAllTradingNewsFromToday
{
    public record GetAllTradingNewsFromTodayQuery(DateTime ToDate) : IRequest<IEnumerable<GetAllTradingNewsFromTodayResponse>>;

    public class GetAllTradingNewsFromTodayQueryHandler : IRequestHandler<GetAllTradingNewsFromTodayQuery, IEnumerable<GetAllTradingNewsFromTodayResponse>>
    {
        private readonly ITradingNewsService _tradingNewsService;
        private readonly IMapper _mapper;

        public GetAllTradingNewsFromTodayQueryHandler(ITradingNewsService tradingNewsService, IMapper mapper)
        {
            _tradingNewsService = tradingNewsService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllTradingNewsFromTodayResponse>> Handle(GetAllTradingNewsFromTodayQuery request, CancellationToken cancellationToken)
        {
            var categories = await _tradingNewsService.GetAllNewsFromToday(request.ToDate);

            var response = _mapper.Map<IEnumerable<GetAllTradingNewsFromTodayResponse>>(categories);

            return response;
        }
    }

}
