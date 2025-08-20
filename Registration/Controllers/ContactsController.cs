using Microsoft.AspNetCore.Mvc;
using Registration.Context;
using Registration.Model.Users;

namespace Registration.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            using (BookedDB db = new BookedDB())
            {

                List<RegistrationUser> ListUsers = db.UserInfo.ToList();

                return View(ListUsers);
            }
        }
    }
}
