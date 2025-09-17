using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Registration.Model.Users;

namespace Registration.Context.Repository.UserRepository
{
    public class UserRepository : IUserRepository<AppUser>
    {
        private readonly UserManager<AppUser> userManager;

        public UserRepository(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IdentityResult> CreateUserAsync(string UserName, 
                                                          string Email,
                                                          string Password, 
                                                          string Role,
                                                          string FirstName,
                                                          string LastName,
                                                          DateTime BirthDay,
                                                          bool IsAgree,
                                                          string? SecondName)
        {
            var user = new AppUser {Email = Email,
                                    FirstName = FirstName,
                                    LastName = LastName,
                                    BirthDay = BirthDay,
                                    IsAgree = IsAgree};

            if (!SecondName.IsNullOrEmpty())
            {
                user.SecondName = SecondName;
            }

            var result = await userManager.CreateAsync(user, Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, Role);
            }

            return result;
        }

        public async Task<IdentityResult> CorrectUserAsync(AppUser user)
        {
            var UserDB = await userManager.FindByIdAsync(user.Id);
            if (UserDB == null) return IdentityResult.Failed();

            UserDB.FirstName = user.FirstName;
            UserDB.SecondName = user.SecondName;
            UserDB.LastName = user.LastName;

            return await userManager.UpdateAsync(UserDB);
        }

        public async Task<IdentityResult> DeleteUserAsync(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null) return IdentityResult.Failed();

            return await userManager.DeleteAsync(user);
        }

        public async Task<AppUser> GetUserByEmailAsync(string email)
        {
            return await userManager.FindByEmailAsync(email);
        }

        public async Task<IEnumerable<AppUser>> ListAllUsers()
        {
            return await userManager.Users.Include(u => u.UserRoles).ToListAsync();
        }
    }
}
