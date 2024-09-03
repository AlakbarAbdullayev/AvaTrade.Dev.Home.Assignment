using AutoMapper;
using AvaTrade.Application.Services.News;
using MediatR;

namespace AvaTrade.Application.Features.News.Queries.GetAllTradingNews
{
    public record GetAllTradingNewsQuery : IRequest<IEnumerable<GetAllTradingNewsResponse>>
    {
    }

    public class GetAllTradingNewsQueryHandler : IRequestHandler<GetAllTradingNewsQuery, IEnumerable<GetAllTradingNewsResponse>>
    {
        private readonly ITradingNewsService _tradingNewsService;
        private readonly IMapper _mapper;

        public GetAllTradingNewsQueryHandler(ITradingNewsService tradingNewsService, IMapper mapper)
        {
            _tradingNewsService = tradingNewsService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllTradingNewsResponse>> Handle(GetAllTradingNewsQuery request, CancellationToken cancellationToken)
        {
            var categories = await _tradingNewsService.GetAll();

            var response = _mapper.Map<IEnumerable<GetAllTradingNewsResponse>>(categories);

            return response;
        }
    }
}
