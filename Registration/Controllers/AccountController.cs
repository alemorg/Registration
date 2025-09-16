using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Registration.Context;
using Registration.Crypt;
using Registration.Model.Users;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Registration.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserService userService;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        public AccountController(UserService userService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userService = userService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginedUser logUser)
        {
            if (!ModelState.IsValid)
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

        public IActionResult SuccessFul(LoginedUser logUser)
        {
            return RedirectToAction(nameof(HomeController.HomePage), "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        //block Registration

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
    }
}
