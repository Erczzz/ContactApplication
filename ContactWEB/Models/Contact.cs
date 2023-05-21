using ContactWEB.Models;
using System.ComponentModel.DataAnnotations;

namespace ContactWEB.Model
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "First Name must contain only letters and spaces.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Last Name must contain only letters and spaces.")]
        public string LastName { get; set; }
        [RegularExpression("(09)[0-9]{9}", ErrorMessage = "This is not a valid phone number")]
        [Required(ErrorMessage = "This field is required")]
        public string ContactNo { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Relation must contain only letters and spaces.")]
        public string? Relation { get; set; }
    }
}
