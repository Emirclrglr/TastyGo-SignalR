using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.BasketDtos;
using SignalR.EntityLayer.Concrete;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketAPIController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly Context _context;
        private readonly IMapper _mapper;

        public BasketAPIController(IBasketService basketService, IMapper mapper, Context context)
        {
            _basketService = basketService;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasketList()
        {
            var map = _mapper.Map<List<ResultBasketDto>>(await _basketService.TGetListAsync());
            return Ok(map);
        }

        [HttpGet("GetBasketListWithRelations")]
        public async Task<IActionResult> GetBasketListWithRelations()
        {
            var map = _mapper.Map<List<ResultBasketWithRelationsDto>>(await _basketService.TGetBasketListWithRelations());
            return Ok(map);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBasketById(int id)
        {
            var map = _mapper.Map<ResultBasketDto>(await _basketService.TGetByIdAsync(id));
            return Ok(map);
        }

        [HttpGet("GetBasketByTableNumber/{tableNumber}")]
        public async Task<IActionResult> GetBasketByTableNumber(int tableNumber)
        {
            var map = _mapper.Map<List<ResultBasketDto>>(await _basketService.TGetBasketByTableNumber(tableNumber));
            return Ok(map);
        }

        [HttpGet("GetBasketByTableNumberWithRelations/{tableNumber}")]
        public async Task<IActionResult> GetBasketByTableNumberWithRelations(int tableNumber)
        {
            var map = _mapper.Map<List<ResultBasketWithRelationsDto>>(await _basketService.TGetBasketListWithRelationsByTableNumber(tableNumber));
            return Ok(map);
        }

        [HttpGet("GetBasketProductCountByTableNumber/{tableNumber}")]
        public async Task<IActionResult> GetBasketProductCountByTableNumber(int tableNumber)
        {
            var value = await _basketService.TGetBasketProductCountByTableNumber(tableNumber);
            return Ok(value);
        }


        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto dto)
        {
            var map = _mapper.Map<Basket>(dto);
            var productPrice = _context.Products.Where(x => x.Id == map.ProductId).Select(y => y.ProductPrice).FirstOrDefault();
            var productCount = 1;
            _basketService.TAdd(new Basket
            {
                ProductId = map.ProductId,
                ProductCount = productCount,
                DiningTableId = map.DiningTableId,
                ProductPrice = productPrice,
                TotalPrice = productPrice * productCount 
            });
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasket(int id)
        {
            var map = _mapper.Map<Basket>(await _basketService.TGetByIdAsync(id));
            _basketService.TDelete(map);
            return Ok();
        }

        [HttpDelete("DeleteBasketItem/{productId}/{basketId}")]
        public IActionResult DeleteBasketItem(int productId, int basketId)
        {
            _basketService.TDeleteBasketItem(productId, basketId);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateBasket(UpdateBasketDto dto)
        {
            var map = _mapper.Map<Basket>(dto);
            _basketService.TUpdate(map);
            return Ok();
        }
    }
}
