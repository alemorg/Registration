using Microsoft.AspNetCore.Identity;
using Registration.Model.Users;

namespace Registration.Context.Repository.UserRepository
{
    public interface IUserRepository<AppUser>
    {
        Task<IdentityResult> CreateUserAsync (string UserName, string Email,string Password,string Role,string FirstName,string LastName,DateTime BirthDay,bool IsAgree,string? SecondName);
        Task<IdentityResult> CorrectUserAsync(AppUser user);
        Task<IdentityResult> DeleteUserAsync(string id);
        Task<AppUser> GetUserByEmailAsync(string email);
    }
}
