using AutoMapper;
using AvaTrade.Application.Services.News;
using MediatR;

namespace AvaTrade.Application.Features.News.Queries.GetAllTradingNewsByInstrument
{
    public record GetAllTradingNewsByInstrumentQuery(string InstrumentName, int Limit = 10) : IRequest<IEnumerable<GetAllTradingNewsByInstrumentResponse>>;


    public class GetAllTradingNewsByInstrumentQueryHandler : IRequestHandler<GetAllTradingNewsByInstrumentQuery, IEnumerable<GetAllTradingNewsByInstrumentResponse>>
    {
        private readonly ITradingNewsService _tradingNewsService;
        private readonly IMapper _mapper;

        public GetAllTradingNewsByInstrumentQueryHandler(ITradingNewsService tradingNewsService, IMapper mapper)
        {
            _tradingNewsService = tradingNewsService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllTradingNewsByInstrumentResponse>> Handle(GetAllTradingNewsByInstrumentQuery request, CancellationToken cancellationToken)
        {
            var categories = await _tradingNewsService.GetAllNewsByInstrument(request.InstrumentName, request.Limit);

            var response = _mapper.Map<IEnumerable<GetAllTradingNewsByInstrumentResponse>>(categories);

            return response;
        }
    }
}
