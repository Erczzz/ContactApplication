using ContactAPI.Models;

namespace ContactAPI.Model
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public string? Email { get; set; }
        public string? Relation { get; set; }
        // public string ApplicationUserId { get; set; }
        // public ApplicationUser ApplicationUser { get; set; }
        public Contact()
        {
            
        }
    }
}
