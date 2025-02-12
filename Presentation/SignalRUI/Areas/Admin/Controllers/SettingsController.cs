using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Concrete;
using SignalR.UI.Dtos.IdentityDtos;

namespace SignalR.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            EditUserDto dto = new EditUserDto()
            {
                Username = user.UserName,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Email = user.Email
            };

            return View(dto);
        }
        [HttpPost]
        public async Task<IActionResult> Index(EditUserDto dto)
        {
            if (dto.Password == dto.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.UserName = dto.Username;
                user.Firstname = dto.Firstname;
                user.Lastname = dto.Lastname;
                user.Email = dto.Email;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, dto.Password);
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Product");
                }
            }

            return View();
        }
    }
}
