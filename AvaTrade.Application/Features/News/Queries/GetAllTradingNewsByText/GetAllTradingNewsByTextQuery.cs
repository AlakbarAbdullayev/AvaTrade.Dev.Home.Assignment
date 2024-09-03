using AutoMapper;
using AvaTrade.Application.Services.News;
using MediatR;

namespace AvaTrade.Application.Features.News.Queries.GetAllTradingNewsByText
{
    public record GetAllTradingNewsByTextQuery(string Text) : IRequest<IEnumerable<GetAllTradingNewsByTextResponse>>;


    public class GetAllTradingNewsByTextQueryHandler : IRequestHandler<GetAllTradingNewsByTextQuery, IEnumerable<GetAllTradingNewsByTextResponse>>
    {
        private readonly ITradingNewsService _tradingNewsService;
        private readonly IMapper _mapper;

        public GetAllTradingNewsByTextQueryHandler(ITradingNewsService tradingNewsService, IMapper mapper)
        {
            _tradingNewsService = tradingNewsService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllTradingNewsByTextResponse>> Handle(GetAllTradingNewsByTextQuery request, CancellationToken cancellationToken)
        {
            var newsItems = await _tradingNewsService.GetAllNewsByText(request.Text);

            var response = _mapper.Map<IEnumerable<GetAllTradingNewsByTextResponse>>(newsItems);

            return response;
        }
    }

}
