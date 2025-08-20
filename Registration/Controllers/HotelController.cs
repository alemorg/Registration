using Microsoft.AspNetCore.Mvc;
using Registration.Context;
using Registration.Model.Hotels;

namespace Registration.Controllers
{
    public class HotelController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateRoom()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateRoom(Room room)
        {
            if (ModelState.IsValid)
            {
                if (room != null)
                {
                    using (BookedDB db = new BookedDB())
                    {
                        db.RoomInfo.Add(room);
                        return View("CompleteCreate", room);
                    }
                }
            }
            return View(room);
        }
    }
}
