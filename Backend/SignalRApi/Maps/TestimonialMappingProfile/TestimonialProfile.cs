using AutoMapper;
using SignalR.DtoLayer.TestimonialDtos;
using SignalR.EntityLayer.Concrete;

namespace SignalR.Api.Maps.TestimonialMappingProfile
{
    public class TestimonialProfile:Profile
    {
        public TestimonialProfile()
        {
            CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
        }
    }
}
