using System.ComponentModel.DataAnnotations;

namespace ContactAPI.DTO
{
    public class LoginDTO
    {
        [EmailAddress]
        [Required(ErrorMessage = "Username field is required")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password field is required")]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
