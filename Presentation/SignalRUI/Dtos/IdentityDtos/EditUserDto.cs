using System.ComponentModel.DataAnnotations;

namespace SignalR.UI.Dtos.IdentityDtos
{
    public class EditUserDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [Compare("Password",ErrorMessage = "Şifrelerin eşleştiğinden emin olunuz")]
        public string ConfirmPassword { get; set; }
    }
}
