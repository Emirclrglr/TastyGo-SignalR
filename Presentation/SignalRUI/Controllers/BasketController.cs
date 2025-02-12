using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.UI.ApiConfig;
using SignalR.UI.Dtos.BasketDtos;

namespace SignalR.UI.Controllers
{
    [AllowAnonymous]
    public class BasketController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiConfig _apiConfig;

        public BasketController(IHttpClientFactory httpClientFactory, IApiConfig apiConfig)
        {
            _httpClientFactory = httpClientFactory;
            _apiConfig = apiConfig;
        }

        public async Task<IActionResult> Index(int id)
        {
            TempData["basketId"] = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_apiConfig.BaseUrl}BasketAPI/GetBasketByTableNumberWithRelations/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<ResultBasketDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> DeleteBasketItem(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"{_apiConfig.BaseUrl}BasketAPI/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect($"/Basket/Index/{TempData["basketId"]}/");
            }
            return NoContent();

        }
    }
}
