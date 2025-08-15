using Microsoft.AspNetCore.Mvc;
using Registration.Context;
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
            using (DBUser db = new DBUser())
            {

            
                if (ModelState.IsValid)
                {
                    if (user != null && user.IsAgree != false)
                    {
                        db.UserInfo.Add(user);
                        db.SaveChanges();
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
}
