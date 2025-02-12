using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDtos;
using SignalR.EntityLayer.Concrete;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountAPIController : ControllerBase
    {
        private readonly IDiscountService _DiscountService;
        private readonly IMapper _mapper;

        public DiscountAPIController(IDiscountService DiscountService, IMapper mapper)
        {
            _DiscountService = DiscountService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> DiscountList()
        {
            var values = await _DiscountService.TGetListAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountById(int id)
        {
            var values = await _DiscountService.TGetByIdAsync(id);
            return Ok(values);
        }

        [HttpGet("AvgDiscountRate")]
        public async Task<IActionResult> AvgDiscountRate()
        {
            var value = _mapper.Map<int>(await _DiscountService.TAvgDiscountRate());
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto dto)
        {
            if (ModelState.IsValid)
            {
                var map = _mapper.Map<Discount>(dto);
                _DiscountService.TAdd(map);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto dto)
        {
            if (ModelState.IsValid)
            {
                var map = _mapper.Map<Discount>(dto);
                _DiscountService.TUpdate(map);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscount(int id)
        {
            var value = await _DiscountService.TGetByIdAsync(id);
            _DiscountService.TDelete(value);
            return Ok();
        }
    }
}
