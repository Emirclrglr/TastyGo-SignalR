using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SignalR.UI.Controllers
{
    [AllowAnonymous]

    public class BookATableController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
