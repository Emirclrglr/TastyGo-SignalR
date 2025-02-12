using AutoMapper;
using SignalR.DtoLayer.BookingDtos;
using SignalR.EntityLayer.Concrete;

namespace SignalR.Api.Maps.BookingMappingProfile
{
    public class BookingProfile:Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, CreateBookingDto>().ReverseMap();
            CreateMap<Booking, UpdateBookingDto>().ReverseMap();
        }
    }
}
