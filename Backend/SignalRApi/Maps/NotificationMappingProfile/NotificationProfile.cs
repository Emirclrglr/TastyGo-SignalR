using AutoMapper;
using SignalR.DtoLayer.NotificationDtos;
using SignalR.EntityLayer.Concrete;

namespace SignalR.Api.Maps.NotificationMappingProfile
{
    public class NotificationProfile:Profile
    {
        public NotificationProfile()
        {
            CreateMap<Notification, ResultNotificationDto>().ReverseMap();
            CreateMap<Notification, CreateNotificationDto>().ReverseMap();
            CreateMap<Notification, UpdateNotificationDto>().ReverseMap();
        }
    }
}
