using ContactAPI.Model;

namespace ContactAPI.Repository
{
    public interface IContactDBRepository
    {
        IEnumerable<Contact> GetAllContactsAsync();
        Contact GetContactById(int id);
        Contact AddContact(Contact newContact);
        Contact UpdateContact(int contactId, Contact updatedContact);
        Contact DeleteContact(int contactId);
        // IEnumerable<string> GetApplicationUserIds();
    }
}
