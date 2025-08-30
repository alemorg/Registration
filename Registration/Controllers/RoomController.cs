using Microsoft.AspNetCore.Mvc;
using Registration.Context;
using Registration.Model.Hotels;
using Registration.Model.Hotels.Repository.RoomRepository;

namespace Registration.Controllers
{
    public class RoomController : Controller
    {
        private readonly RoomService roomService;
        public RoomController(RoomService roomService)
        {
            this.roomService = roomService;
        }
        //список всех комнат в базе данных (возможно вообще не нужна эта функция)
        //[HttpGet("room/alllist")]
        //public IActionResult AllList()
        //{
        //    using (BookedDB db = new BookedDB())
        //    {
        //        List<Room> ListRoom = new List<Room>();

        //        foreach (Room room in db.Room)
        //        {
        //            ListRoom.Create(room);
        //        }

        //        if (ListRoom.Count != 0)
        //            return View(ListRoom);
        //        else return View();
        //    }
        //}

        [HttpGet("hotel/{hotelId}/room/list")]
        public IActionResult List(int hotelId)
        {
            ViewBag.hotelId = hotelId;
            
            if (roomService != null) return View(roomService.List());
            else return View();
        }

        [HttpGet("hotel/{hotelId}/room/create")]
        public IActionResult Create(int hotelId)
        {
            ViewBag.HotelId = hotelId;
            return View();
        }

        [HttpPost("hotel/{hotelId}/room/create")]
        public IActionResult Create(int hotelid, Room room)
        {
            if (hotelid > 0)
            {
                if (ModelState.IsValid)
                {
                    roomService.Create(room);

                    return RedirectToAction(nameof(CompleteCreate), room);
                }
                return View(room);
            }
            return NotFound();
        }

        public IActionResult CompleteCreate(Room room)
        {
            return View(room);
        }

        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                var room = roomService.Profile(id);
                if (room != null)
                {
                    roomService.Delete(id);
                    return RedirectToAction(nameof(CompleteDelete), room);
                }
            }
            return NotFound();
        }

        public IActionResult CompleteDelete(Room room)
        {
            return View(room);
        }

        [HttpGet]
        public IActionResult Correct(int id)
        {
            if (id > 0)
            {
                ViewBag.id = id;
                
                var room = roomService.Profile(id);

                if (room != null)
                {
                    return View(room);
                }
            }
            return View(NotFound());
        }

        // Нужно ли здесь ID?
        [HttpPost]
        public IActionResult Correct(int id, Room room)
        {
            if (id > 0)
            {
                if (ModelState.IsValid)
                {
                    roomService.Correct(room);
                    return View(nameof(CompleteCorrect),room);
                }
                return View(room);
            }
            return NotFound();
            
        }
        public IActionResult CompleteCorrect(Room room)
        {
            return View(room);
        }
    }
}
