using Microsoft.AspNetCore.Identity;
using SautiYako.Models;

namespace SautiYako.Interfaces
{

    public interface IUserRepository
    {
        Task<IdentityResult> CreateUserAsync(User user, string password);
        Task<User> GetUserByIdAsync(string userId);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(User user);

        Task<string> GenerateEmailConfirmationTokenAsync(User user);
        Task<IdentityResult> ConfirmEmailAsync(User user, string token);
        Task<User> FindUserByEmailAsync(string email);
        Task<bool> CheckPasswordAsync(User user, string password);
        Task<bool> CheckCurrentPasswordAsync(User user, string currentPassword);
        Task<IdentityResult> ChangePasswordAsync(User user, string currentPassword, string newPassword);
        Task SignInAsync(User user, bool isPersistent);
        string GenerateAuthToken(User user);

        ICollection<User> GetUsers();
        User GetUserbyId(string userId);
        User GetUserbyEmail(string email);
        User GetUserByUsername(string username);
        bool UserExists(string userId);
        bool Save();
    }
}