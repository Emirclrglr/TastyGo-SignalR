using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderAPIController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderAPIController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> OrderList()
        {
            var value = await _orderService.TGetListAsync();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var value =await _orderService.TGetByIdAsync(id);
            return Ok(value);
        }

        [HttpGet("TotalOrderCount")]
        public async Task<IActionResult> TotalOrderCount()
        {
            var value = await _orderService.TotalOrderCount();
            return Ok(value);
        }

        [HttpGet("ActiveOrderCount")]
        public async Task<IActionResult> ActiveOrderCount()
        {
            var value = await _orderService.TActiveOrderCount();
            return Ok(value);
        }

        [HttpGet("PassiveOrderCount")]
        public async Task<IActionResult> PassiveOrderCount()
        {
            var value = await _orderService.TPassiveOrderCount();
            return Ok(value);
        }

        [HttpGet("TotalPriceOfLatestOrder")]
        public async Task<IActionResult> TotalPriceOfLatestOrder()
        {
            var value = await _orderService.TTotalPriceOfLatestOrder();
            return Ok(value);
        }

        [HttpGet("TodaysEarnings")]
        public async Task<IActionResult> TodaysEarnings()
        {
            return Ok(await _orderService.TTodaysEarnings());
        }
    }
}
