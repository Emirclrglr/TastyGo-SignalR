using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDtos;
using SignalR.EntityLayer.Concrete;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureAPIController : ControllerBase
    {
        private readonly IFeatureService _FeatureService;
        private readonly IMapper _mapper;

        public FeatureAPIController(IFeatureService FeatureService, IMapper mapper)
        {
            _FeatureService = FeatureService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> FeatureList()
        {
            var values = await _FeatureService.TGetListAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureById(int id)
        {
            var values = await _FeatureService.TGetByIdAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto dto)
        {
            if (ModelState.IsValid)
            {
                var map = _mapper.Map<Feature>(dto);
                _FeatureService.TAdd(map);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto dto)
        {
            if (ModelState.IsValid)
            {
                var map = _mapper.Map<Feature>(dto);
                _FeatureService.TUpdate(map);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeature(int id)
        {
            var value = await _FeatureService.TGetByIdAsync(id);
            _FeatureService.TDelete(value);
            return Ok();
        }
    }
}
