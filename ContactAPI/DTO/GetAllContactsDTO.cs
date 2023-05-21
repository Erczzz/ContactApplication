using System.ComponentModel.DataAnnotations;

namespace ContactAPI.DTO
{
    public class GetAllContactsDTO
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
    }
}
