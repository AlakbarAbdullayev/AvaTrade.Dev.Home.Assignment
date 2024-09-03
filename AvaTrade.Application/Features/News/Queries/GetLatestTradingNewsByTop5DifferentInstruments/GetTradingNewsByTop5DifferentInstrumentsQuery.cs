using AutoMapper;
using AvaTrade.Application.Services.News;
using MediatR;

namespace AvaTrade.Application.Features.News.Queries.GetLatestTradingNewsByTop5DifferentInstruments
{
    public record GetTradingNewsByTop5DifferentInstrumentsQuery : IRequest<IEnumerable<GetNewsByTop5DifferentInstrumentsResponse>>;

    public class GetTradingNewsByTop5DifferentInstrumentsQueryHandler : IRequestHandler<GetTradingNewsByTop5DifferentInstrumentsQuery, IEnumerable<GetNewsByTop5DifferentInstrumentsResponse>>
    {
        private readonly ITradingNewsService _tradingNewsService;
        private readonly IMapper _mapper;

        public GetTradingNewsByTop5DifferentInstrumentsQueryHandler(ITradingNewsService tradingNewsService, IMapper mapper)
        {
            _tradingNewsService = tradingNewsService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetNewsByTop5DifferentInstrumentsResponse>> Handle(GetTradingNewsByTop5DifferentInstrumentsQuery request, CancellationToken cancellationToken)
        {
            var latestNews = await _tradingNewsService.GetLatestNewsGroupedByInstruments(5);
            var response = _mapper.Map<IEnumerable<GetNewsByTop5DifferentInstrumentsResponse>>(latestNews);
            return response;
        }
    }

}
