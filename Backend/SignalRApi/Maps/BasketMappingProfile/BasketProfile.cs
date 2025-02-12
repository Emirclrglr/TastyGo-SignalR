using AutoMapper;
using SignalR.DtoLayer.BasketDtos;
using SignalR.EntityLayer.Concrete;

namespace SignalR.Api.Maps.BasketMappingProfile
{
    public class BasketProfile:Profile
    {
        public BasketProfile()
        {
            CreateMap<Basket, CreateBasketDto>().ReverseMap();
            CreateMap<Basket, UpdateBasketDto>().ReverseMap();
            CreateMap<Basket, ResultBasketDto>().ReverseMap();
            CreateMap<Basket, ResultBasketWithRelationsDto>().ReverseMap();
        }
    }
}
