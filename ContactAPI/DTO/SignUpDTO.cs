using System.ComponentModel.DataAnnotations;

namespace ContactAPI.DTO
{
    public class SignUpDTO
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{5,}$", ErrorMessage = "Password must have a minimum of five characters, at least one letter, one uppercase letter, one number and one special character")]
        [Required(ErrorMessage = "Password field is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [RegularExpression(@"^[0-9]{11}$", ErrorMessage = "Contact number must be 11-digit number.")]
        public string ContactNo { get; set; }
    }
}
