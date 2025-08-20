using Microsoft.AspNetCore.Mvc;
using Registration.Context;
using Registration.Crypt;
using Registration.Model;

namespace Registration.Controllers
{
    public class AccountController : Controller
    {
        RegistrationUser user = null;

        //block Login

        [HttpGet]
        public IActionResult Logined()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Logined(LoginedUser logUser)
        {
            if (!ModelState.IsValid)
            {
                using (DBUser db = new DBUser())
                {
                    CryptPassword cryptPassword = new CryptPassword();
                    RegistrationUser user = db.UserInfo.FirstOrDefault(x => x.Email == logUser.Email && cryptPassword.Decrypt(x.Password) == logUser.Password);

                    if (user != null)
                    {
                        return View("CompletedLogined", user);
                    }
                }
            }
            return View(logUser);
        }

        public IActionResult CompletedLogined(LoginedUser logUser)
        {
            return View(logUser);
        }

        //block Registration

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(RegistrationUser user)
        {
            using (DBUser db = new DBUser())
            {
                if (ModelState.IsValid)
                {
                    if (user != null && user.IsAgree != false)
                    {
                        CryptPassword crypt = new CryptPassword();
                        user.Password = crypt.Encode(user.Password);
                        user.ConfirmPassword = crypt.Encode(user.ConfirmPassword);
                        db.UserInfo.Add(user);
                        db.SaveChanges();
                        return View("CompletedRegistration", user);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return View(user);
                }
            }
        }

        public IActionResult CompletedRegistration(RegistrationUser user)
        {
            return View(user);
        }
    }
}
