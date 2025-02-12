using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.UI.ApiConfig;
using SignalR.UI.Dtos.BookingDtos;

namespace SignalR.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiConfig _apiConfig;

        public BookingController(IHttpClientFactory httpClientFactory, IApiConfig apiConfig)
        {
            _httpClientFactory = httpClientFactory;
            _apiConfig = apiConfig;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_apiConfig.BaseUrl}BookingAPI");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<ResultBookingDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_apiConfig.BaseUrl}BookingAPI/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"{_apiConfig.BaseUrl}BookingAPI", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responeMessage = await client.DeleteAsync($"{_apiConfig.BaseUrl}BookingAPI/{id}");
            if (responeMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> SetReservationStatusAccepted(int id)
        {
            var client = _httpClientFactory.CreateClient();
            StringContent content = new(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"{_apiConfig.BaseUrl}BookingAPI/SetReservationStatusAccepted/{id}", content);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> SetReservationStatusDenied(int id)
        {
            var client = _httpClientFactory.CreateClient();
            StringContent content = new(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"{_apiConfig.BaseUrl}BookingAPI/SetReservationStatusDenied/{id}", content);
            return RedirectToAction("Index");
        }
    }
}
