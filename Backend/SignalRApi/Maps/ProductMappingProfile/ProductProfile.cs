using AutoMapper;
using SignalR.DtoLayer.ProductDtos;
using SignalR.EntityLayer.Concrete;

namespace SignalR.Api.Maps.ProductMappingProfile
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductDto>().ReverseMap();
        }
    }
}
