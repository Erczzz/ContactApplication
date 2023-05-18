using ContactAPI.DTO;
using ContactAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace ContactAPI.Repository
{
    public interface IAccountDBRepository
    {
        Task<IdentityResult> SignUpUserAsync(ApplicationUser user, string password);
        Task<SignInResult> SignInUserAsync(LoginDTO loginDTO);
        Task<ApplicationUser> FindUserByEmailAsync(string email);
        // IEnumerable<string> GetApplicationUserIds();
    }
}
