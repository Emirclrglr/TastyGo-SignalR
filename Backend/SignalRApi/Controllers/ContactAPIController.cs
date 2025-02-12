using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDtos;
using SignalR.EntityLayer.Concrete;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactAPIController : ControllerBase
    {
        private readonly IContactService _ContactService;
        private readonly IMapper _mapper;

        public ContactAPIController(IContactService ContactService, IMapper mapper)
        {
            _ContactService = ContactService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetContactList()
        {
            var values = await _ContactService.TGetListAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            var value = await _ContactService.TGetByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto dto)
        {
            if (ModelState.IsValid)
            {
                var map = _mapper.Map<Contact>(dto);
                _ContactService.TAdd(map);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto dto)
        {
            if (ModelState.IsValid)
            {
                var map = _mapper.Map<Contact>(dto);
                _ContactService.TUpdate(map);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var value = await _ContactService.TGetByIdAsync(id);
            _ContactService.TDelete(value);
            return Ok();
        }
    }
}
