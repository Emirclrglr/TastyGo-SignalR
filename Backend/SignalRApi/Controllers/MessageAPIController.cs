using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MessageDtos;
using SignalR.EntityLayer.Concrete;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageAPIController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public MessageAPIController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetMessageList()
        {
            var values = _mapper.Map<IEnumerable<ResultMessageDto>>(await _messageService.TGetListAsync());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessageById(int id)
        {
            var value = _mapper.Map<ResultMessageDto>(await _messageService.TGetByIdAsync(id));
            return Ok(value);
        }

        [HttpGet("MessageCount")]
        public async Task<IActionResult> MessageCount()
        {
            var value = _mapper.Map<int>(await _messageService.TMessageCount());
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto dto)
        {
            dto.MessageDate = DateTime.Parse(DateTime.Now.ToString());
            dto.Status = false;
            var map = _mapper.Map<Message>(dto);
            _messageService.TAdd(map);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto dto)
        {
            var map = _mapper.Map<Message>(dto);
            _messageService.TUpdate(map);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            var value = _mapper.Map<Message>(await _messageService.TGetByIdAsync(id));
            _messageService.TDelete(value);
            return Ok();
        }
    }
}
