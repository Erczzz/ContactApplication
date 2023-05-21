using ContactAPI.Data;
using ContactAPI.DTO;
using ContactAPI.Model;
using ContactAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;

namespace ContactAPI.Repository
{
    public class ContactDBRepository : IContactDBRepository
    {
        private readonly ContactDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContactDBRepository(ContactDBContext context, UserManager<ApplicationUser> userManager,
            IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<GetAllContactsDTO>> GetAllContactsAsync()
        {
            var contacts = new List<GetAllContactsDTO>();

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "GetAllContacts";
                command.CommandType = CommandType.StoredProcedure;

                await _context.Database.OpenConnectionAsync();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        contacts.Add(new GetAllContactsDTO
                        {
                            ContactId = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            ContactNo = reader.GetString(3)
                        });
                    }
                }
            }

            return contacts;
        }

        public Contact GetContactById(int id)
        {
            var contactIdParam = new SqlParameter("@ContactId", id);

            var contacts = _context.Contacts
                .FromSqlRaw("EXECUTE GetContactById @ContactId", contactIdParam)
                .AsEnumerable()
                .FirstOrDefault();

            return contacts;
        }

        public Contact AddContact(Contact newContact)
        {
            var firstNameParam = new SqlParameter("@FirstName", newContact.FirstName);
            var lastNameParam = new SqlParameter("@LastName", newContact.LastName);
            var contactNoParam = new SqlParameter("@ContactNo", newContact.ContactNo);
            var emailParam = new SqlParameter("@Email", SqlDbType.NVarChar)
            {
                Value = (object)newContact.Email ?? DBNull.Value
            };
            var relationParam = new SqlParameter("@Relation", SqlDbType.NVarChar)
            {
                Value = (object)newContact.Relation ?? DBNull.Value
            };

            _context.Database.ExecuteSqlRaw("EXECUTE AddContact @FirstName, @LastName, @ContactNo, @Email, @Relation",
                firstNameParam, lastNameParam, contactNoParam, emailParam, relationParam);

            return newContact;
        }

        public Contact UpdateContact(int contactId, Contact updatedContact)
        {
            var existingContact = _context.Contacts.Find(contactId);
            if (existingContact != null)
            {
                existingContact.FirstName = updatedContact.FirstName;
                existingContact.LastName = updatedContact.LastName;
                existingContact.ContactNo = updatedContact.ContactNo;
                existingContact.Email = updatedContact.Email;
                existingContact.Relation = updatedContact.Relation;

                var contactIdParam = new SqlParameter("@ContactId", contactId);
                var firstNameParam = new SqlParameter("@FirstName", updatedContact.FirstName);
                var lastNameParam = new SqlParameter("@LastName", updatedContact.LastName);
                var contactNoParam = new SqlParameter("@ContactNo", updatedContact.ContactNo);
                var emailParam = new SqlParameter("@Email", (object)updatedContact.Email ?? DBNull.Value);
                var relationParam = new SqlParameter("@Relation", (object)updatedContact.Relation ?? DBNull.Value);

                _context.Database.ExecuteSqlRaw("EXECUTE UpdateContact @ContactId, @FirstName, @LastName, @ContactNo, @Email, @Relation",
                    contactIdParam, firstNameParam, lastNameParam, contactNoParam, emailParam, relationParam);

                _context.SaveChanges();
            }
            else
            {
                return null; // Contact not found, return null
            }
            return existingContact;
        }

        public Contact DeleteContact(int contactId)
        {
            var contact = _context.Contacts.Find(contactId);
            if (contact != null)
            {
                var contactIdParam = new SqlParameter("@ContactId", contactId);
                _context.Database.ExecuteSqlRaw("EXECUTE DeleteContact @ContactId", contactIdParam);
                _context.SaveChanges();
            }
            return contact;
        }
    }
}
