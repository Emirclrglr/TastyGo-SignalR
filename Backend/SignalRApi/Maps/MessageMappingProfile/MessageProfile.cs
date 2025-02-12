using AutoMapper;
using SignalR.DtoLayer.MessageDtos;
using SignalR.EntityLayer.Concrete;

namespace SignalR.Api.Maps.MessageMappingProfile
{
    public class MessageProfile:Profile
    {
        public MessageProfile()
        {
            CreateMap<Message, ResultMessageDto>().ReverseMap();
            CreateMap<Message, CreateMessageDto>().ReverseMap();
            CreateMap<Message, UpdateMessageDto>().ReverseMap();
        }
    }
}
