using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Concrete;

namespace SignalR.UI.Areas.Admin.ViewComponents.AdminLayout
{
    public class _AdminLayoutSidebarPartial:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _AdminLayoutSidebarPartial(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.AuthenticatedUserName = $"{user.Firstname} {user.Lastname}";
            return View();
        }
    }
}
