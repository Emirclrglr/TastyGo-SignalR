using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiningTableDtos;
using SignalR.EntityLayer.Concrete;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiningTableAPIController : ControllerBase
    {
        private readonly IDiningTableService _diningTableService;
        private readonly IMapper _mapper;
        public DiningTableAPIController(IDiningTableService diningTableService, IMapper mapper)
        {
            _diningTableService = diningTableService;
            _mapper = mapper;
        }

        [HttpGet("DiningTableCount")]
        public async Task<IActionResult> DiningTableCount()
        {
            return Ok(await _diningTableService.TDiningTableCountAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetDiningTableList()
        {
            var values = _mapper.Map<IEnumerable<ResultDiningTableDto>>(await _diningTableService.TGetListAsync());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiningTableById(int id)
        {
            var values = _mapper.Map<ResultDiningTableDto>(await _diningTableService.TGetByIdAsync(id));
            return Ok(values);
        }

        [HttpPut("ChangeDiningTableStatusToTrue/{id}")]
        public IActionResult ChangeDiningTableStatusToTrue(int id)
        {
            _diningTableService.TChangeDiningTableStatusToTrue(id);
            return Ok("İşlem Başarılı");
        }

        [HttpPut("ChangeDiningTableStatusToFalse/{id}")]
        public IActionResult ChangeDiningTableStatusToFalse(int id)
        {
            _diningTableService.TChangeDiningTableStatusToFalse(id);
            return Ok("İşlem Başarılı");
        }

        [HttpPost]
        public IActionResult CreateDiningTable(CreateDiningTableDto dto)
        {
            var map = _mapper.Map<DiningTable>(dto);
            _diningTableService.TAdd(map);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateDiningTable(UpdateDiningTableDto dto)
        {
            var map = _mapper.Map<DiningTable>(dto);
            _diningTableService.TUpdate(map);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiningTable(int id)
        {
            var value = _mapper.Map<DiningTable>(await _diningTableService.TGetByIdAsync(id));
            _diningTableService.TDelete(value);
            return Ok();
        }
    }
}
