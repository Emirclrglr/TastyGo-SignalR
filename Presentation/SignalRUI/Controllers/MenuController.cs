using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.UI.ApiConfig;
using SignalR.UI.Dtos.BasketDtos;

namespace SignalR.UI.Controllers
{
    [AllowAnonymous]

    public class MenuController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiConfig _apiConfig;

        public MenuController(IHttpClientFactory httpClientFactory, IApiConfig apiConfig)
        {
            _httpClientFactory = httpClientFactory;
            _apiConfig = apiConfig;
        }
        public IActionResult Index(int id)
        {
            ViewBag.v = id;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddToBasket(int id, int menuTableId)
        {
            CreateBasketDto dto = new CreateBasketDto()
            {
                ProductId = id,
                DiningTableId = menuTableId
            };
            var client = _httpClientFactory.CreateClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync($"{_apiConfig.BaseUrl}BasketAPI", content);

            StringContent content2 = new(JsonConvert.SerializeObject(menuTableId), Encoding.UTF8, "application/json");
            await client.PutAsync($"{_apiConfig.BaseUrl}DiningTableAPI/ChangeDiningTableStatusToTrue/{menuTableId}", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return Json(dto);
        }
    }
}
