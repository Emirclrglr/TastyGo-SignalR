using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.UI.ApiConfig;
using SignalR.UI.Dtos.ContactDtos;
using SignalR.UI.Dtos.SocialMediaDtos;

namespace SignalR.UI.ViewComponents.UILayoutViewComponents
{
    public class _UIFooterSocialMediaViewPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiConfig _apiConfig;

        public _UIFooterSocialMediaViewPartial(IHttpClientFactory httpClientFactory, IApiConfig apiConfig)
        {
            _httpClientFactory = httpClientFactory;
            _apiConfig = apiConfig;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_apiConfig.BaseUrl}SocialMediaAPI");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<ResultSocialMediaDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
