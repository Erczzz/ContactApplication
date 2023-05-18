using ContactAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace ContactAPI.DTO
{
    public class ContactDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [RegularExpression(@"^[0-9]{11}$", ErrorMessage = "Contact number must be 11-digit number.")]
        public string ContactNo { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
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
