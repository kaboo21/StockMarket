using AutoMapper;
using BusinessLogicLayer.Models;
using DataAccessLayer.Entities;
using StockMarket.DTOs;

namespace StockMarket.Profiles
{
    public class LotItemProfile : Profile
    {
        public LotItemProfile()
        {
            //TSource, TDestination
            CreateMap<LotItem, LotItemEntity>()
                .ForMember(r => r.RemainShareNumber, o => o.MapFrom(i => i.ShareNumber));

            CreateMap<LotItemEntity, LotItem>();

            CreateMap<LotItem, LotItemDto>();

            CreateMap<LotItemRequest, LotItem>();
        }
    }
}
