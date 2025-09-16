using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using Registration.Model.Users;

namespace Registration.Context
{
    public static class IdentitySeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

            //создание ролей
            string[] roleNames = { "Admin", "Manager", "User" };
            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            //Создание Admin'a по умолчанию
            var adminUser = await userManager.FindByEmailAsync("adminA@yandex.ru");
            if (adminUser == null)
            {
                var user = new AppUser
                {
                    UserName = "adminA",
                    Email = "adminA@yandex.ru",
                    FirstName = "adminA",
                    SecondName = "adminA",
                    LastName = "adminA",
                    BirthDay = DateTime.Now,
                    PhoneNumber = "89873972200",
                    IsAgree = true
                };

                var createPowerUser = await userManager.CreateAsync(user, "adminA!123");
                if (createPowerUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }

            //Создание Manager'a по умолчанию
            var managUser = await userManager.FindByEmailAsync("managU@yandex.ru");
            if (managUser == null)
            {
                var user = new AppUser
                {
                    UserName = "managU",
                    Email = "managU@yandex.ru",
                    FirstName = "managU",
                    SecondName = "managU",
                    LastName = "managU",
                    BirthDay = DateTime.Now,
                    PhoneNumber = "89873972201",
                    IsAgree = true
                };

                var createPowerUser = await userManager.CreateAsync(user, "managU!123");
                if (createPowerUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Manager");
                }
            }

            //Создание User'a по умолчанию
            var userUser = await userManager.FindByEmailAsync("userU@yandex.ru");
            if (userUser == null)
            {
                var user = new AppUser
                {
                    UserName = "userU",
                    Email = "userU@yandex.ru",
                    FirstName = "userU",
                    SecondName = "userU",
                    LastName = "userU",
                    BirthDay = DateTime.Now,
                    PhoneNumber = "89873972202",
                    IsAgree = true
                };

                var createPowerUser = await userManager.CreateAsync(user, "userU!123");
                if (createPowerUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "User");
                }
            }
        }
    }
}
