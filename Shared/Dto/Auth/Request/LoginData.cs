using System.ComponentModel.DataAnnotations;

namespace Shared.Dto.Auth.Request
{
    public class LoginData
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; } = false;
    }
}