using ContactAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace ContactAPI.Model
{
    public class Contact
    {
        public int ContactId { get; set; }
        [Required(ErrorMessage = "First Name field is required.")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "First Name must contain only letters and spaces.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name field is required.")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Last Name must contain only letters and spaces.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Contact Number field is required.")]
        [RegularExpression(@"^[0-9]{11}$", ErrorMessage = "Contact number must be 11-digit number.")]
        public string ContactNo { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Relation must contain only letters and spaces.")]
        public string? Relation { get; set; }
        public Contact()
        {
            
        }
    }
}
