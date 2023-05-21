using ContactAPI.DTO;
using ContactAPI.Model;

namespace ContactAPI.Repository
{
    public interface IContactDBRepository
    {
        Task<List<GetAllContactsDTO>> GetAllContactsAsync();
        Contact GetContactById(int id);
        Contact AddContact(Contact newContact);
        Contact UpdateContact(int contactId, Contact updatedContact);
        Contact DeleteContact(int contactId);
        // IEnumerable<string> GetApplicationUserIds();
    }
}
