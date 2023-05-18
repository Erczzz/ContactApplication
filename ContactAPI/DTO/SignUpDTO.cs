using System.ComponentModel.DataAnnotations;

namespace ContactAPI.DTO
{
    public class SignUpDTO
    {
        [Required(ErrorMessage = "First Name field is required")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "First Name must contain only letters and spaces.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name field is required")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Last Name must contain only letters and spaces.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email Address field is required")]
        [EmailAddress]
        public string Email { get; set; }
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{5,}$", ErrorMessage = "Password must have a minimum of five characters, at least one letter, one uppercase letter, one number and one special character")]
        [Required(ErrorMessage = "Password field is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [RegularExpression(@"^[0-9]{11}$", ErrorMessage = "Contact number must be 11-digit number.")]
        [Required(ErrorMessage = "Contact Number field is required")]
        public string ContactNo { get; set; }
    }
}
