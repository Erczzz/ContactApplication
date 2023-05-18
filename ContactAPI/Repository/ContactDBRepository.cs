using ContactAPI.Data;
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

        public IEnumerable<Contact> GetAllContactsAsync()
        {
            /*var userId = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);*/
            // var userIdClaim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            /*if (userIdClaim != null)
            {
                string userId = userIdClaim.Value;
                // Use the userId as needed
            }*/
            /*string userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;*/
            var contacts = _context.Contacts
                .FromSqlRaw("EXECUTE GetAllContacts")
                .AsNoTracking()
                .ToList();

            /*var userIds = contacts.Select(c => c.ApplicationUserId).Distinct().ToList();

            var users = _context.Users
                .Where(u => userIds.Contains(u.Id))
                .ToList();

            foreach (var contact in contacts)
            {
                contact.ApplicationUser = users.FirstOrDefault(u => u.Id == contact.ApplicationUserId);
            }*/

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
/*        public IEnumerable<string> GetApplicationUserIds()
        {
            var applicationUserIds = _context.Contacts
                .Select(c => c.ApplicationUserId)
                .Distinct()
                .ToList();

            return applicationUserIds;
        }*/
    }
}
