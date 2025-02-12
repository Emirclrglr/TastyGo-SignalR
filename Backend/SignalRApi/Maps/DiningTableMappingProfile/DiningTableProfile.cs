using AutoMapper;
using SignalR.DtoLayer.DiningTableDtos;
using SignalR.EntityLayer.Concrete;

namespace SignalR.Api.Maps.DiningTableMappingProfile
{
    public class DiningTableProfile:Profile
    {
        public DiningTableProfile()
        {
            CreateMap<DiningTable, ResultDiningTableDto>().ReverseMap();
            CreateMap<DiningTable, CreateDiningTableDto>().ReverseMap();
            CreateMap<DiningTable, UpdateDiningTableDto>().ReverseMap();
        }
    }
}
