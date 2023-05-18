using ContactWEB.Models;
using System.ComponentModel.DataAnnotations;

namespace ContactWEB.Model
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string LastName { get; set; }
        [RegularExpression("(09)[0-9]{9}", ErrorMessage = "This is not a valid phone number")]
        [Required(ErrorMessage = "This field is required")]
        public string ContactNo { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? Relation { get; set; }
    }
}
