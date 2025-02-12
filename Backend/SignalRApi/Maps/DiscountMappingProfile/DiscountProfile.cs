using AutoMapper;
using SignalR.DtoLayer.DiscountDtos;
using SignalR.EntityLayer.Concrete;

namespace SignalR.Api.Maps.DiscountMappingProfile
{
    public class DiscountProfile:Profile
    {
        public DiscountProfile()
        {
            CreateMap<Discount, CreateDiscountDto>().ReverseMap();
            CreateMap<Discount, UpdateDiscountDto>().ReverseMap();
        }
    }
}
