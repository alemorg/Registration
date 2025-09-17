using Microsoft.AspNetCore.Identity;
using Registration.Model.Account;
using Registration.Model.Hotels;
using Registration.Model.Users;

namespace Registration.Context.Repository.UserRepository
{
    public class UserService
    {
        private readonly IUserRepository<AppUser> repository;

        public UserService(IUserRepository<AppUser> repository)
        {
            this.repository = repository;
        }

        public async Task<IdentityResult> CreateUserAsync(string UserName, string Email, string Password, string Role,string FirstName, string LastName, DateTime BirthDay,bool IsAgree, string? SecondName)
        {
            return await repository.CreateUserAsync(UserName, Email, Password, Role, FirstName, LastName,BirthDay, IsAgree, SecondName);
        }

        public async Task<IdentityResult> CorrectUserAsync(UserViewModel userViewModel)
        {
            return await repository.CorrectUserAsync(userViewModel);
        }

        public async Task<IdentityResult> CorrectBirthDayAsync(UserViewModel userViewModel)
        {
            return await repository.CorrectBirthDayAsync(userViewModel);
        }

        public async Task<IdentityResult> DeleteUserAsync(string id)
        {
            return await repository.DeleteUserAsync(id);
        }

        public async Task<AppUser> GetUserByEmailAsync(string email)
        {
            return await repository.GetUserByEmailAsync(email);
        }

        public async Task<IEnumerable<AppUser>> ListAllUsers()
        {
            return await repository.ListAllUsers();
        }
    }
}
