using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ProductDtos;
using SignalR.EntityLayer.Concrete;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        private readonly IProductService _ProductService;
        private readonly IMapper _mapper;

        public ProductAPIController(IProductService ProductService, IMapper mapper)
        {
            _ProductService = ProductService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _ProductService.TGetListAsync();
            return Ok(values);
        }

        [HttpGet("GetProductsWithCategory")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            var values = await _ProductService.TGetProductsWithCategoryAsync();
            return Ok(values);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var values = await _ProductService.TGetByIdAsync(id);
            return Ok(values);
        }

        [HttpGet("ProductCount")]
        public async Task<IActionResult> ProductCount()
        {
            var value = await _ProductService.TProductCountAsync();
            return Ok(value);
        }

        [HttpGet("ProductCountByCategoryName/{categoryName}")]
        public async Task<IActionResult> ProductCountByHamburger(string categoryName)
        {
            var value = await _ProductService.TProductCountByCategoryName(categoryName);
            return Ok(value);
        }


        [HttpGet("MostExpensiveProduct")]
        public async Task<IActionResult> MostExpensiveProduct()
        {
            var value = await _ProductService.TMostExpensiveProduct();
            return Ok(value);
        }

        [HttpGet("CheapestProduct")]
        public async Task<IActionResult> CheapestProduct()
        {
            var value = await _ProductService.TCheapestProduct();

            return Ok(value);
        }

        [HttpGet("AverageProductPrice")]
        public async Task<IActionResult> AverageProductPrice()
        {
            var value = await _ProductService.TAverageProductPrice();
            return Ok(value);
        }

        [HttpGet("AverageProductPriceByCategoryName/{categoryName}")]
        public async Task<IActionResult> AverageProductPriceByCategoryName(string categoryName)
        {
            var value = await _ProductService.TAverageProductPriceByCategoryName(categoryName);
            return Ok(value);
        }

        [HttpGet("TotalProductPrice")]
        public async Task<IActionResult> TotalProductPrice()
        {
            var value = _mapper.Map<decimal>(await _ProductService.TTotalProductPrice());
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto dto)
        {
            if (ModelState.IsValid)
            {
                var map = _mapper.Map<Product>(dto);
                _ProductService.TAdd(map);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto dto)
        {
            if (ModelState.IsValid)
            {
                var map = _mapper.Map<Product>(dto);
                _ProductService.TUpdate(map);
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
            _ProductService.TSetProductStatusActive(id);
            return Ok();
        }

        [HttpPut("SetStatusPassive/{id}")]
        public IActionResult SetStatusPassive(int id)
        {
            _ProductService.TSetProductStatusPassive(id);
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var value = await _ProductService.TGetByIdAsync(id);
            _ProductService.TDelete(value);
            return Ok();
        }
    }
}
