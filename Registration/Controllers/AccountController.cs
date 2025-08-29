using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Login(LoginedUser logUser)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        using (BookedDB db = new BookedDB())
        //        {
        //            CryptPassword cryptPassword = new CryptPassword();
        //            RegistrationUser user = db.User.FirstOrDefault(x => x.Email == logUser.Email && cryptPassword.Decrypt(x.Password) == logUser.Password);

        //            if (user != null)
        //            {
        //                //Создаем информацию о пользователе
        //                var claims = new List<Claim>
        //                {
        //                    new Claim(ClaimTypes.Name, $"{user.FirstName} {user.FirstName}"),
        //                    new Claim(ClaimTypes.Role, "Admin")                                         //Переделать при переделке класса userov
        //                };

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

        //[HttpPost]
        //public IActionResult Registration(RegistrationUser user)
        //{
        //    using (BookedDB db = new BookedDB())
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            if (user != null && user.IsAgree != false)
        //            {
        //                CryptPassword crypt = new CryptPassword();
        //                user.Password = crypt.Encode(user.Password);
        //                user.ConfirmPassword = crypt.Encode(user.ConfirmPassword);
        //                db.User.Create(user);
        //                db.SaveChanges();
        //                return View("CompletedRegistration", user);
        //            }
        //            else
        //            {
        //                return NotFound();
        //            }
        //        }
        //        else
        //        {
        //            return View(user);
        //        }
        //    }
        //}

        public IActionResult CompletedRegistration(RegistrationUser user)
        {
            return View(user);
        }
    }
}
