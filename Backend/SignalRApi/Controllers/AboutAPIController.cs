using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDtos;
using SignalR.EntityLayer.Concrete;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutAPIController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutAPIController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var values = await _aboutService.TGetListAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAboutById(int id)
        {
            var values = await _aboutService.TGetByIdAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto dto)
        {
            if (ModelState.IsValid)
            {
                var map = _mapper.Map<About>(dto);
                _aboutService.TAdd(map);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto dto)
        {
            if (ModelState.IsValid)
            {
                var map = _mapper.Map<About>(dto);
                _aboutService.TUpdate(map);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            var value = await _aboutService.TGetByIdAsync(id);
            _aboutService.TDelete(value);
            return Ok();
        }
    }
}
