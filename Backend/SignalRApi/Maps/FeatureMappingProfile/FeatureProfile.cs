using AutoMapper;
using SignalR.DtoLayer.FeatureDtos;
using SignalR.EntityLayer.Concrete;

namespace SignalR.Api.Maps.FeatureMappingProfile
{
    public class FeatureProfile:Profile
    {
        public FeatureProfile()
        {
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
        }
    }
}
