using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SignalR.UI.ApiConfig;
using SignalR.UI.Dtos.CategoryDtos;
using SignalR.UI.Dtos.ProductDtos;

namespace SignalR.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiConfig _apiConfig;

        public ProductController(IHttpClientFactory httpClientFactory, IApiConfig apiConfig)
        {
            _httpClientFactory = httpClientFactory;
            _apiConfig = apiConfig;
        }

        private async Task CategoryDropDownList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_apiConfig.BaseUrl}CategoryAPI");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<IEnumerable<ResultCategoryDto>>(jsonData);
            List<SelectListItem> items = (from item in values
                                          select new SelectListItem
                                          {
                                              Text = item.CategoryName,
                                              Value = item.Id.ToString()
                                          }).ToList();

            ViewBag.CategoryItems = items;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_apiConfig.BaseUrl}ProductAPI/GetProductsWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            await CategoryDropDownList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto dto)
        {
            await CategoryDropDownList();
            var client = _httpClientFactory.CreateClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync($"{_apiConfig.BaseUrl}ProductAPI", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            await CategoryDropDownList();
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_apiConfig.BaseUrl}ProductAPI/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto dto)
        {
            await CategoryDropDownList();
            var client = _httpClientFactory.CreateClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"{_apiConfig.BaseUrl}ProductAPI", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responeMessage = await client.DeleteAsync($"{_apiConfig.BaseUrl}ProductAPI/{id}");
            if (responeMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> SetProductStatusActive(int id)
        {
            var client = _httpClientFactory.CreateClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json");
            await client.PutAsync($"{_apiConfig.BaseUrl}ProductAPI/SetStatusActive/{id}", content);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> SetProductStatusPassive(int id)
        {
            var client = _httpClientFactory.CreateClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json");
            await client.PutAsync($"{_apiConfig.BaseUrl}ProductAPI/SetStatusPassive/{id}", content);
            return RedirectToAction("Index");
        }
    }
}
