using Microsoft.AspNetCore.Mvc;

namespace SignalR.UI.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
