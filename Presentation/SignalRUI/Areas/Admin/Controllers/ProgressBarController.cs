using Microsoft.AspNetCore.Mvc;

namespace SignalR.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProgressBarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
