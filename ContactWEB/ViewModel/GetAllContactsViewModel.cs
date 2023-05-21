using System.ComponentModel.DataAnnotations;

namespace ContactWEB.ViewModel
{
    public class GetAllContactsViewModel
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
    }
}
