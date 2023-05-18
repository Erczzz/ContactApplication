using ContactAPI.Data;
using ContactAPI.DTO;
using ContactAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ContactAPI.Repository
{
    public class AccountDBRepository : IAccountDBRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ContactDBContext _context;

        public AccountDBRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            ContactDBContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<IdentityResult> SignUpUserAsync(ApplicationUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<SignInResult> SignInUserAsync(LoginDTO loginDTO)
        {
            return await _signInManager.PasswordSignInAsync(loginDTO.UserName, loginDTO.Password, false, lockoutOnFailure: false);
        }

        public async Task<ApplicationUser> FindUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
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
