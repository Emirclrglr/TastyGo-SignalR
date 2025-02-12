using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.NotificationDtos;
using SignalR.EntityLayer.Concrete;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationAPIController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        public NotificationAPIController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetNotifications()
        {
            var values = _mapper.Map<List<ResultNotificationDto>>(await _notificationService.TGetListAsync());
            return Ok(values);
        }

        [HttpGet("UnreadNotificationCount")]
        public IActionResult UnreadNotificationCount()
        {
            var value = _mapper.Map<int>(_notificationService.TNotificationCountByStatusFalse());
            return Ok(value);
        }

        [HttpGet("UnreadNotificationList")]
        public async Task<IActionResult> UnreadNotificationList()
        {
            var values = _mapper.Map<List<ResultNotificationDto>>(await _notificationService.TGetAllNotificationsByStatusFalse());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotificationById(int id)
        {
            var values = _mapper.Map<Notification>(await _notificationService.TGetByIdAsync(id));
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto dto)
        {
            dto.Date = DateTime.Parse(DateTime.Now.ToString());
            var map = _mapper.Map<Notification>(dto);
            _notificationService.TAdd(map);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            var map = _mapper.Map<Notification>(await _notificationService.TGetByIdAsync(id));
            _notificationService.TDelete(map);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto dto)
        {
            var map = _mapper.Map<Notification>(dto);
            _notificationService.TUpdate(map);
            return Ok();
        }

        [HttpPut("SetStatusRead/{id}")]
        public IActionResult SetStatusRead(int id)
        {
            _notificationService.TSetNotificationStatusRead(id);
            return Ok();
        }
        [HttpPut("SetStatusUnread/{id}")]
        public IActionResult SetStatusUnread(int id)
        {
            _notificationService.TSetNotificationStatusUnread(id);
            return Ok();
        }
    }
}
