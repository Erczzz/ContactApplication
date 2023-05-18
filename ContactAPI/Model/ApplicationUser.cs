using ContactAPI.Model;
using Microsoft.AspNetCore.Identity;

namespace ContactAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }

        // Navigation property for the contacts
        // public virtual ICollection<Contact> Contacts { get; set; }
    }
}
