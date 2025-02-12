using Microsoft.AspNetCore.Mvc;

namespace SignalR.UI.Areas.Admin.ViewComponents.AdminLayout
{
    public class _AdminLayoutHeadPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
