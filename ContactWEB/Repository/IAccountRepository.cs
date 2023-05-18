using Microsoft.AspNetCore.Identity;
using ContactWEB.Models;
using ContactWEB.ViewModels;

namespace ContactWEB.Repository
{
    public interface IAccountRepository
    {
        Task<bool> SignUpUserAsync(RegisterUserViewModel user);
        Task<string> SignInUserAsync(LoginUserViewModel loginUserViewModel);
        Task<string> GetApplicationUserId(string token);
    }
}
