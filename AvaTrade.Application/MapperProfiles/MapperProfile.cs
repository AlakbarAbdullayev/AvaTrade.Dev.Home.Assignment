using AutoMapper;
using AvaTrade.Application.Features.News.Queries.GetAllTradingNews;
using AvaTrade.Application.Features.News.Queries.GetAllTradingNewsByText;
using AvaTrade.Application.Features.News.Queries.GetAllTradingNewsFromToday;
using AvaTrade.Application.Features.News.Queries.GetLatestTradingNewsByTop5DifferentInstruments;
using AvaTrade.Domain.Entities.News;

namespace AvaTrade.Application.MapperProfiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<TradingNews, GetNewsByTop5DifferentInstrumentsResponse>().ReverseMap();
            CreateMap<TradingNews, GetAllTradingNewsResponse>().ReverseMap();
            CreateMap<TradingNews, GetAllTradingNewsByTextResponse>().ReverseMap();
            CreateMap<TradingNews, GetAllTradingNewsFromTodayResponse>().ReverseMap();
            CreateMap<TradingNews, GetTradingNewsByTop5DifferentInstrumentsQuery>().ReverseMap();
        }
    }
}
