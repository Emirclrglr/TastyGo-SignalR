using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SignalR.UI.ApiConfig;
using SignalR.UI.Dtos.CategoryDtos;
using SignalR.UI.Dtos.NotificationDtos;

namespace SignalR.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NotificationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiConfig _apiConfig;

        public NotificationController(IHttpClientFactory httpClientFactory, IApiConfig apiConfig)
        {
            _httpClientFactory = httpClientFactory;
            _apiConfig = apiConfig;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_apiConfig.BaseUrl}NotificationAPI");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<ResultNotificationDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateNotification()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateNotification(CreateNotificationDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync($"{_apiConfig.BaseUrl}NotificationAPI", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateNotification(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_apiConfig.BaseUrl}NotificationAPI/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateNotificationDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateNotification(UpdateNotificationDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"{_apiConfig.BaseUrl}NotificationAPI", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteNotification(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responeMessage = await client.DeleteAsync($"{_apiConfig.BaseUrl}NotificationAPI/{id}");
            if (responeMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> SetStatusRead(int id)
        {
            var client = _httpClientFactory.CreateClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"{_apiConfig.BaseUrl}NotificationAPI/SetStatusRead/{id}", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> SetStatusUnread(int id)
        {
            var client = _httpClientFactory.CreateClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"{_apiConfig.BaseUrl}NotificationAPI/SetStatusUnread/{id}", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
