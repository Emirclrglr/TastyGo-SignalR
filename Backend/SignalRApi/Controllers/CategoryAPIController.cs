using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDtos;
using SignalR.EntityLayer.Concrete;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryAPIController : ControllerBase
    {
        private readonly ICategoryService _CategoryService;
        private readonly IMapper _mapper;

        public CategoryAPIController(ICategoryService CategoryService, IMapper mapper)
        {
            _CategoryService = CategoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryList()
        {
            var values = await _CategoryService.TGetListAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var value = await _CategoryService.TGetByIdAsync(id);
            return Ok(value);
        }

        [HttpGet("CategoryCount")]
        public async Task<IActionResult> CategoryCount()
        {
            var value = await _CategoryService.TCategoryCountAsync();
            return Ok(value);
        }

        [HttpGet("LastCreatedCategory")]
        public async Task<IActionResult> LastCreatedCategory()
        {
            var value = await _CategoryService.TGetLastCreatedCategory();
            return Ok(value);
        }

        [HttpGet("ActiveCategoryCount")]
        public async Task<IActionResult> ActiveCategoryCount()
        {
            var value = await _CategoryService.TActiveCategoryCountAsync();
            return Ok(value);
        }

        [HttpGet("PassiveCategoryCount")]
        public async Task<IActionResult> PassiveCategoryCount()
        {
            var value = await _CategoryService.TPassiveCategoryCountAsync();
            return Ok(value);
        }


        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto dto)
        {
            if (ModelState.IsValid)
            {
                var map = _mapper.Map<Category>(dto);
                _CategoryService.TAdd(map);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto dto)
        {
            if (ModelState.IsValid)
            {
                var map = _mapper.Map<Category>(dto);
                _CategoryService.TUpdate(map);
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
            _CategoryService.TSetStatusActive(id);
            return Ok();
        }

        [HttpPut("SetStatusPassive/{id}")]
        public IActionResult SetStatusPassive(int id)
        {
            _CategoryService.TSetStatusPassive(id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var value = await _CategoryService.TGetByIdAsync(id);
            _CategoryService.TDelete(value);
            return Ok();
        }
    }
}
