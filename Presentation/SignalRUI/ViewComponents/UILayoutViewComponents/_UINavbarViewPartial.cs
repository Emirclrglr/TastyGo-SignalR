using Microsoft.AspNetCore.Mvc;

namespace SignalR.UI.ViewComponents.UILayout
{
    public class _UINavbarViewPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
