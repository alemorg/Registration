using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Registration.Context.Repository.UserRepository;
using Registration.Model.Account;
using Registration.Model.Users;
using System.Data;
using System.Runtime.CompilerServices;


namespace Registration.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserService userService;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public AccountController(UserService userService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userService = userService;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager= roleManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel logUser)
        {
            if (ModelState.IsValid)
            {
                var user = await userService.GetUserByEmailAsync(logUser.Email);
                if (user != null)
                {
                    var result = await userManager.CheckPasswordAsync(user, logUser.Password);
                    if (result) 
                    {
                        await signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction(nameof(SuccessFul));
                    }

                    return View(nameof(SuccessFul));
                }
            }
            return View(logUser);
        }

        public IActionResult SuccessFul()
        {
            return RedirectToAction(nameof(HomeController.HomePage), "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.IsAgree != false)
                {
                    var user = userService.CreateUserAsync(model.Login,model.Email, model.Password, "User", model.FirstName, model.LastName, model.BirthDay, model.IsAgree, model.SecondName);

                    return View(nameof(CompletedRegistration));
                }
            }
            return View(model);
        }

        public IActionResult CompletedRegistration()
        {
            return RedirectToAction(nameof(Login));
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            
            return RedirectToAction(nameof(HomeController.HomePage),"Home");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ListAllUsers()
        {
            var ListUsers = await userService.ListAllUsers();
            var usersViewModel = new List<UserViewModel>();

            foreach (var  user in ListUsers)
            {
                var roles = await userManager.GetRolesAsync(user);
                usersViewModel.Add(new UserViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    SecondName = user.SecondName,
                    LastName = user.LastName,
                    Email = user.Email,
                    BirthDay = user.BirthDay,
                    PhoneNumber = user.PhoneNumber,
                    Role = roles.FirstOrDefault()
                });
            }

            return View(usersViewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CorrectProfile (string id)
        {
            var user = await userManager.FindByIdAsync(id);
            var role = await userManager.GetRolesAsync(user);

            var roles = await roleManager.Roles.ToListAsync();
            ViewBag.Roles = roles.Select(r => r.Name).ToList();

            if (user != null)
            {
                UserViewModel viewModel = new UserViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    SecondName = user.SecondName,
                    LastName = user.LastName,
                    Email = user.Email,
                    BirthDay = user.BirthDay,
                    PhoneNumber = user.PhoneNumber,
                    Role = role.FirstOrDefault()
                };

                return View(viewModel);
            }

            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CorrectProfile(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByIdAsync(viewModel.Id);
                if (user != null)
                {
                    bool IsCorrect = false;

                    if (viewModel.UserName != user.UserName && viewModel.UserName != null)
                    {
                        await userManager.SetUserNameAsync(user, viewModel.UserName);
                        IsCorrect = true;
                    }
                    if (viewModel.Email != user.Email && viewModel.Email != null)
                    {
                        await userManager.SetEmailAsync(user, viewModel.Email);
                        IsCorrect = true;
                    }
                    if (viewModel.PhoneNumber != user.PhoneNumber && viewModel.PhoneNumber != null)
                    {
                        await userManager.SetPhoneNumberAsync(user, viewModel.PhoneNumber);
                        IsCorrect = true;
                    }

                    if (viewModel.FirstName != user.FirstName && viewModel.FirstName != null ||
                        viewModel.LastName != user.LastName && viewModel.LastName != null ||
                        viewModel.SecondName != user.SecondName && viewModel.SecondName != null)
                    {
                        await userService.CorrectUserAsync(viewModel);
                        IsCorrect = true;
                    }

                    if (viewModel.BirthDay != user.BirthDay)
                    {
                        await userService.CorrectBirthDayAsync(viewModel);
                        IsCorrect = true;
                    }

                    var oldRoles = await userManager.GetRolesAsync(user);
                    if (!oldRoles.Any(role => role == viewModel.Role))
                    {
                        foreach (var role in oldRoles)
                        {
                            await userManager.RemoveFromRoleAsync(user, role);
                        }
                        await userManager.AddToRoleAsync(user, viewModel.Role);
                    }

                    if (IsCorrect)
                    {
                        return RedirectToAction(nameof(CorrectProfile));
                        //return View(nameof(ComleteCorrect));
                    }
                }
                return NotFound();
            }
            return View(viewModel);
        }

        public IActionResult ComleteCorrect()
        {
            return View();
        }
    }
}
