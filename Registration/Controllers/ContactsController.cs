using Microsoft.AspNetCore.Mvc;
using Registration.Context;
using Registration.Model;

namespace Registration.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            using (DBUser db = new DBUser())
            {

                List<RegistrationUser> ListUsers = db.UserInfo.ToList();

                return View(ListUsers);
            }
        }
    }
}
