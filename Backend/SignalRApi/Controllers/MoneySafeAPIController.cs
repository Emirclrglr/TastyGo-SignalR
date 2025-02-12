using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneySafeAPIController : ControllerBase
    {
        private readonly IMoneySafeService _moneySafeService;

        public MoneySafeAPIController(IMoneySafeService moneySafeService)
        {
            _moneySafeService = moneySafeService;
        }

        [HttpGet]
        public IActionResult GetTotalAmount()
        {
            return Ok(_moneySafeService.TTotalAmount());
        }
    }
}
