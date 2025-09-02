using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Registration.Context;
using Registration.Context.Repository.UserRepository;
using Registration.Crypt;
using Registration.Model.Users;
using System.Security.Claims;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Login(LoginedUser logUser)
        {
            if (ModelState.IsValid)
            {
                var user = userService.GetByEmail(logUser.Email);
                if (user != null)
                {
                    CryptPassword crypt = new CryptPassword();
                    if (crypt.Decrypt(user.Password) == logUser.Password)
                    {
                        //Создаем информацию о пользователе
                        var claims = new List<Claim>
                    {
                    new Claim(ClaimTypes.Name, $"{user.FirstName} {user.FirstName}"),
                    new Claim(ClaimTypes.Role, "Admin")                                         //Переделать при переделке класса userov
                    };

        //                //Создаем пропуск
        //                var claimsIdentity = new ClaimsIdentity(claims,
        //                    CookieAuthenticationDefaults.AuthenticationScheme);

        //                //Выдаем пропуск
        //                await HttpContext.SignInAsync(
        //                    CookieAuthenticationDefaults.AuthenticationScheme,
        //                    new ClaimsPrincipal(claimsIdentity));

        //                return View(nameof(SuccessFul), user);
        //            }
        //        }
        //    }
        //    return View(logUser);
        //}

        public IActionResult SuccessFul(LoginedUser logUser)
        {
            return View(logUser);
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
        public IActionResult Registration(User user)
        {
            if (ModelState.IsValid)
            {
                if (user != null && user.IsAgree != false)
                {
                    CryptPassword crypt = new CryptPassword();
                    user.Password = crypt.Encode(user.Password);
                    user.ConfirmPassword = crypt.Encode(user.ConfirmPassword);
                    userService.Create(user);

                    return View(nameof(CompletedRegistration), user);
                }
            }
            return View(user);
        }

        public IActionResult CompletedRegistration(User user)
        {
            return View(user);
        }
    }
}
