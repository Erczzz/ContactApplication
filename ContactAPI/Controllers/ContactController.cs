using AutoMapper;
using ContactAPI.Data;
using ContactAPI.DTO;
using ContactAPI.Model;
using ContactAPI.Models;
using ContactAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ContactAPI.Controllers
{
    [ApiController]

    public class ContactController : ControllerBase
    {
        private readonly IContactDBRepository _repo;
        private readonly IMapper _mapper;
        private readonly ContactDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ContactController(IContactDBRepository repo, IMapper mapper,
            ContactDBContext context, UserManager<ApplicationUser> userManager)
        {
            _repo = repo;
            _mapper = mapper;
            _context = context;
            _userManager = userManager;
        }

        [Authorize]
        [HttpGet("Contacts")]
        public IActionResult GetAll()
        {
            var contacts = _repo.GetAllContactsAsync();
            return Ok(contacts);
        }


        [Authorize]
        [HttpPost("AddContact")]
        public IActionResult AddContact(ContactDTO contactDTO)
        {
            if (ModelState.IsValid)
            {
                var newContact = new Contact
                {
                    FirstName = contactDTO.FirstName,
                    LastName = contactDTO.LastName,
                    ContactNo = contactDTO.ContactNo,
                    Email = contactDTO.Email,
                    Relation = contactDTO.Relation
                };

                var addedContact = _repo.AddContact(newContact);
                return Ok(addedContact);
            }
            return BadRequest(ModelState);
        }

        [Authorize]
        [HttpGet("GetContact/{id}")]
        public IActionResult GetContact(int id)
        {
            var contact = _repo.GetContactById(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [Authorize]
        [HttpDelete("DeleteContact/{id}")]
        public IActionResult Delete(int id)
        {
            var contactToDelete = _repo.GetContactById(id);
            if (contactToDelete == null)
            {
                return NotFound("Contact not found.");
            }

            var deletedContact = _repo.DeleteContact(id);
            return Ok(_mapper.Map<ContactDTO>(deletedContact));
        }

        [Authorize]
        [HttpPut("UpdateContact/{Id}")]
        public IActionResult UpdateContact(int Id, Contact updatedContact)
        {
            var existingContact = _repo.UpdateContact(Id, updatedContact);
            if (existingContact != null)
            {
                // Handle successful update, if needed
                return Ok(existingContact); // or any other appropriate response
            }
            else
            {
                // Handle failed update, if needed
                var errorMessage = $"Contact with ID {Id} not found.";
                return NotFound(errorMessage); // or any other appropriate response
            }
        }


        /*        [Authorize]
                [HttpGet("ApplicationUserIds")]
                public IActionResult GetApplicationUserIds()
                {
                    var applicationUserIds = _repo.GetApplicationUserIds();
                    return Ok(applicationUserIds);
                }*/

    }
}
