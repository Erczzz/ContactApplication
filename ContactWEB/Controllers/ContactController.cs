using ContactWEB.Model;
using ContactWEB.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using System.Security.Claims;

namespace ContactWEB.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _repo;
        public ContactController(IContactRepository repo)
        {
            _repo = repo;
        }
        public async Task<IActionResult> GetAllContacts()
        {
            string token = HttpContext.Session.GetString("JWToken");

            if (string.IsNullOrEmpty(token))
            {
                // Handle the case when the token is not available
                return RedirectToAction("Login", "Account");
            }

            var contacts = await _repo.GetAllContacts(token);

            return View(contacts);
        }

        public async Task<IActionResult> CreateAsync()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Contact newContact)
        {
            var token = HttpContext.Session.GetString("JWToken");

            await _repo.AddContact(newContact, token);
            return RedirectToAction("GetAllContacts");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var token = HttpContext.Session.GetString("JWToken");
            var contact = await _repo.GetContactById(id, token);

            if (contact is null)
                return NotFound();

            return View(contact);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Contact updatedContact)
        {
            try
            {
                var token = HttpContext.Session.GetString("JWToken");
                var contactId = updatedContact.ContactId;
                var updatedContactResult = await _repo.UpdateContact(contactId, updatedContact, token);

                if (updatedContactResult != null)
                {
                    // Handle successful update, if needed
                    return RedirectToAction("GetAllContacts");
                }
                else
                {
                    // Handle failed update, if needed
                    ModelState.AddModelError(string.Empty, "Failed to update contact.");
                    return View(updatedContact);
                }
            }
            catch (Exception ex)
            {
                // Handle the exception and return the View with the appropriate error message
                ModelState.AddModelError(string.Empty, "Failed to update contact: " + ex.Message);
                return View(updatedContact);
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            var token = HttpContext.Session.GetString("JWToken");
            await _repo.DeleteContact(id, token);
            return RedirectToAction("GetAllContacts");
        }

        public async Task<IActionResult> Details(int id)
        {
            var token = HttpContext.Session.GetString("JWToken");
            var contact = await _repo.GetContactById(id, token);

            if (contact is null)
                return NotFound();

            return View(contact);
        }


    }
}
