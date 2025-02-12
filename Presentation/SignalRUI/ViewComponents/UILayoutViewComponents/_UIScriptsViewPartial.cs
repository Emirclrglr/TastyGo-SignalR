using Microsoft.AspNetCore.Mvc;

namespace SignalR.UI.ViewComponents.UILayout
{
    public class _UIScriptsViewPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
