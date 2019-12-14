using System.ComponentModel.DataAnnotations;

namespace Shared.Dto.Auth.Request
{
    public class RegisterData
    {
        [Required]
        [Display(Name = "שם משתמש")]
        public string Username { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "סיסמה")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "אשר סיסמה")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}