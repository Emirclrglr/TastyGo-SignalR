using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.UI.ApiConfig;
using SignalR.UI.Dtos.ProductDtos;

namespace SignalR.UI.ViewComponents.HomeViewComponents
{
    public class _HomeOurMenuViewPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiConfig _apiConfig;

        public _HomeOurMenuViewPartial(IHttpClientFactory httpClientFactory, IApiConfig apiConfig)
        {
            _httpClientFactory = httpClientFactory;
            _apiConfig = apiConfig;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.v = id;


            //            id = (int)TempData["customerSelectedTableId"];
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
    }
}
