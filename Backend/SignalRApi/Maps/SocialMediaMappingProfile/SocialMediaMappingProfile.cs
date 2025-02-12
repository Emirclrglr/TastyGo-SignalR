using AutoMapper;
using SignalR.DtoLayer.SocialMediaDtos;
using SignalR.EntityLayer.Concrete;

namespace SignalR.Api.Maps.SocialMediaMappingProfile
{
    public class SocialMediaMappingProfile : Profile
    {
        public SocialMediaMappingProfile()
        {
            CreateMap<SocialMedia, CreateSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaDto>().ReverseMap();
        }
    }
}
