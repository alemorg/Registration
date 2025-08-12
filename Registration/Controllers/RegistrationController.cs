using Microsoft.AspNetCore.Mvc;
using Registration.Model;

namespace Registration.Controllers
{
    public class RegistrationController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Completed(RegistrationUser user)
        {
            return View(user);
        }

        [HttpPost]
        public IActionResult Index(RegistrationUser user)
        {
            if (ModelState.IsValid)
            {
                if (user != null && user.IsAgree != false)
                {
                    //Добавить в базу данных
                    return View("Completed", user);
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
}
