using Microsoft.AspNetCore.Mvc;

namespace SignalR.UI.ViewComponents.UILayout
{
    public class _UIHeadViewPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
