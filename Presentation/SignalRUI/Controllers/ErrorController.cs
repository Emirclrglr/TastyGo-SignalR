using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SignalR.UI.Controllers
{
    [AllowAnonymous]
    public class ErrorController : Controller
    {
        public IActionResult NotFound404()
        {
            return View();
        }
    }
}
