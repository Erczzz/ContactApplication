using ContactWEB.Model;
using Microsoft.AspNetCore.Identity;

namespace ContactWEB.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string  FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
    }
}
