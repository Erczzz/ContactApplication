using ContactWEB.Model;

namespace ContactWEB.Repository
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetAllContacts(string token);
        Task<Contact> GetContactById(int id, string token);
        Task<Contact> AddContact(Contact newContact, string token);
        Task<Contact> UpdateContact(int contactId, Contact newContact, string token);
        Task DeleteContact(int contactId, string token);
    }
}
