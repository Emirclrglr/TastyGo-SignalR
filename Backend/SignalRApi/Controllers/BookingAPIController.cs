using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDtos;
using SignalR.EntityLayer.Concrete;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingAPIController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingAPIController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetBookingList()
        {
            var values = await _bookingService.TGetListAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var value = await _bookingService.TGetByIdAsync(id);
            return Ok(value);
        }

        [HttpGet("TotalBookingCount")]
        public async Task<IActionResult> TotalBookingCount()
        {
            var value = _mapper.Map<int>(await _bookingService.TBookingCount());
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto dto)
        {
            if (ModelState.IsValid)
            {
                dto.ReservationStatus = "Rezervasyon Alındı";
                var map = _mapper.Map<Booking>(dto);
                _bookingService.TAdd(map);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto dto)
        {
            if (ModelState.IsValid)
            {
                var map = _mapper.Map<Booking>(dto);
                _bookingService.TUpdate(map);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var value = await _bookingService.TGetByIdAsync(id);
            _bookingService.TDelete(value);
            return Ok();
        }

        [HttpPut("SetReservationStatusAccepted/{id}")]
        public IActionResult SetReservationStatusAccepted(int id)
        {
            _bookingService.TSetReservationStatusAccepted(id);
            return Ok("Rezervasyon Durumu Değiştirildi");
        }
        [HttpPut("SetReservationStatusDenied/{id}")]
        public IActionResult SetReservationStatusDenied(int id)
        {
            _bookingService.TSetReservationStatusDenied(id);
            return Ok("Rezervasyon Durumu Değiştirildi");
        }
    }
}
