using AutoMapper;
using SignalR.DtoLayer.AboutDtos;
using SignalR.EntityLayer.Concrete;

namespace SignalR.Api.Maps.AboutMappingProfile
{
    public class AboutProfile:Profile
    {
        public AboutProfile()
        {
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();
        }
    }
}
