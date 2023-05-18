using ContactAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace ContactAPI.DTO
{
    public class ContactDTO
    {
        [Required(ErrorMessage = "First Name field is required")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "First Name must contain only letters and spaces.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name field is required")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Last Name must contain only letters and spaces.")]
        public string LastName { get; set; }
        [RegularExpression(@"^[0-9]{11}$", ErrorMessage = "Contact number must be 11-digit number.")]
        [Required(ErrorMessage = "Contact Number field is required")]
        public string ContactNo { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Relation must contain only letters and spaces.")]
        public string? Relation { get; set; }

        public ContactDTO()
        {
        }

        public ContactDTO(string firstName, string lastName, string contactNo, string? email, string? relation)
        {
            FirstName = firstName;
            LastName = lastName;
            ContactNo = contactNo;
            Email = email;
            Relation = relation;
        }
    }
}
