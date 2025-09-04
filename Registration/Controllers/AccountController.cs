using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Registration.Context.Repository.UserRepository;
using Registration.Model.Users;


namespace Registration.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserService userService;
        public AccountController(UserService userService)
        {
            this.userService = userService;
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
                    return View(nameof(SuccessFul));
                }
            }
            return View(logUser);
        }

        public IActionResult SuccessFul()
        {
            return RedirectToAction(nameof(HomeController.HomePage), nameof(HomeController));
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
            return RedirectToAction(nameof(HomeController.HomePage),nameof(HomeController));
        }

        public async Task<IActionResult> Logout ()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction(nameof(HomeController.HomePage),nameof(HomeController));
        }
    }
}
