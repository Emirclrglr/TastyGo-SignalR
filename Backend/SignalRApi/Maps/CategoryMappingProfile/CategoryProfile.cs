using AutoMapper;
using SignalR.DtoLayer.CategoryDtos;
using SignalR.EntityLayer.Concrete;

namespace SignalR.Api.Maps.CategoryMappingProfile
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
           CreateMap<Category, CreateCategoryDto>().ReverseMap();
           CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        }
    }
}
