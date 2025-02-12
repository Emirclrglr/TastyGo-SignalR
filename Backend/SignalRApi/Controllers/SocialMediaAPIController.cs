using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDtos;
using SignalR.EntityLayer.Concrete;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaAPIController : ControllerBase
    {
        private readonly ISocialMediaService _SocialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaAPIController(ISocialMediaService SocialMediaService, IMapper mapper)
        {
            _SocialMediaService = SocialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> SocialMediaList()
        {
            var values = await _SocialMediaService.TGetListAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSocialMediaById(int id)
        {
            var values = await _SocialMediaService.TGetByIdAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto dto)
        {
            if (ModelState.IsValid)
            {
                var map = _mapper.Map<SocialMedia>(dto);
                _SocialMediaService.TAdd(map);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto dto)
        {
            if (ModelState.IsValid)
            {
                var map = _mapper.Map<SocialMedia>(dto);
                _SocialMediaService.TUpdate(map);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            var value = await _SocialMediaService.TGetByIdAsync(id);
            _SocialMediaService.TDelete(value);
            return Ok();
        }
    }
}
