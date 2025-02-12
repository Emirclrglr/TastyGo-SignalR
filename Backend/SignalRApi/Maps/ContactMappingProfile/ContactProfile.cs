using AutoMapper;
using SignalR.DtoLayer.CategoryDtos;
using SignalR.DtoLayer.ContactDtos;
using SignalR.EntityLayer.Concrete;

namespace SignalR.Api.Maps.ContactMappingProfile
{
    public class ContactProfile:Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();
        }
    }
}
