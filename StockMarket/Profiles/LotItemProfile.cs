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
            CreateMap<LotItemModel, LotItemEntity>()
                .ForMember(r => r.RemainShareNumber, o => o.MapFrom(i => i.ShareNumber));
            CreateMap<LotItemEntity, LotItemModel>();
            CreateMap<LotItemModel, LotItemDto>();
            CreateMap<LotItemRequest, LotItemModel>();

            //Stock calculations
            CreateMap<SaleTransactionRequest, SaleTransactionModel>();
            CreateMap<SaleShareResultModel, SaleTransactionResultDto>();
        }
    }
}
