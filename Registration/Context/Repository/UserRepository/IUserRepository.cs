using Microsoft.AspNetCore.Identity;
using Registration.Model.Account;
using Registration.Model.Users;

namespace Registration.Context.Repository.UserRepository
{
    public interface IUserRepository<AppUser>
    {
        Task<IdentityResult> CreateUserAsync (string UserName, string Email,string Password,string Role,string FirstName,string LastName,DateTime BirthDay,bool IsAgree,string? SecondName);
        Task<IdentityResult> CorrectUserAsync(UserViewModel userViewModel);
        Task<IdentityResult> CorrectBirthDayAsync(UserViewModel userViewModel);
        Task<IdentityResult> DeleteUserAsync(string id);
        Task<AppUser> GetUserByEmailAsync(string email);
        Task<IEnumerable<AppUser>> ListAllUsers();
    }
}
