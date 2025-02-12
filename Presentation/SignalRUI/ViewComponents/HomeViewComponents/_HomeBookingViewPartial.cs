using Microsoft.AspNetCore.Mvc;

namespace SignalR.UI.ViewComponents.HomeViewComponents
{
    public class _HomeBookingViewPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
