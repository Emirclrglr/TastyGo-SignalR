using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.TestimonialDtos;
using SignalR.EntityLayer.Concrete;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialAPIController : ControllerBase
    {
        private readonly ITestimonialService _TestimonialService;
        private readonly IMapper _mapper;

        public TestimonialAPIController(ITestimonialService TestimonialService, IMapper mapper)
        {
            _TestimonialService = TestimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> TestimonialList()
        {
            var values = await _TestimonialService.TGetListAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestimonialById(int id)
        {
            var values = await _TestimonialService.TGetByIdAsync(id);
            return Ok(values);
        }

        [HttpGet("TestimonialCount")]
        public async Task<IActionResult> TestimonialCount()
        {
            var value = _mapper.Map<int>(await _TestimonialService.TTestimonialCountAsync());
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto dto)
        {
            if (ModelState.IsValid)
            {
                var map = _mapper.Map<Testimonial>(dto);
                _TestimonialService.TAdd(map);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto dto)
        {
            if (ModelState.IsValid)
            {
                var map = _mapper.Map<Testimonial>(dto);
                _TestimonialService.TUpdate(map);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("SetStatusActive/{id}")]
        public IActionResult SetStatusActive(int id)
        {
            _TestimonialService.TSetTestimonialActive(id);
            return Ok();
        }

        [HttpPut("SetStatusPassive/{id}")]
        public IActionResult SetStatusPassive(int id)
        {
            _TestimonialService.TSetTestimonialPassive(id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var value = await _TestimonialService.TGetByIdAsync(id);
            _TestimonialService.TDelete(value);
            return Ok();
        }
    }
}
