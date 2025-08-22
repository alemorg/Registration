using Microsoft.AspNetCore.Mvc;
using Registration.Context;
using Registration.Model.Hotels;

namespace Registration.Controllers
{
    public class RoomController : Controller
    {

        //список всех комнат в базе данных (возможно вообще не нужна эта функция)
        //[HttpGet("room/list")]
        //public IActionResult List()
        //{
        //    using (BookedDB db = new BookedDB())
        //    {
        //        List<Room> ListRoom = new List<Room>();

        //        foreach (Room room in db.RoomInfo)
        //        {
        //            ListRoom.Add(room);
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
            using (BookedDB db = new BookedDB())
            {
                try
                {
                    List<Room> ListRoom = new List<Room>();

                    foreach (Room room in db.Room)
                    {
                        if (room.HotelId == hotelId)
                            ListRoom.Add(room);
                    }

                    if (ListRoom.Count != 0)
                        return View(ListRoom);
                    else return View();
                }
                catch (Exception ex )
                {
                    Console.WriteLine($"Error {ex.Message}");
                }
                return View(NotFound());
                
            }
        }

        [HttpGet("hotel/{hotelId}/room/create")]
        public IActionResult Create(int hotelId)
        {
            ViewBag.HotelId = hotelId;
            return View();
        }

        [HttpPost]
        public IActionResult Create(int hotelid,Room room)
        {
            if (hotelid == 0) 
                return View(NotFound());
            if (ModelState.IsValid)
            {
                if (room.Square > 0 && room.MaximumGuests > 0)
                {
                    using (BookedDB db = new BookedDB())
                    {
                        db.Room.Add(room);
                        db.SaveChanges();
                        
                        return View(nameof(CompleteCreate), room);
                    }
                }
            }
            return View(room);
        }

        public IActionResult CompleteCreate(Room room)
        {
            return View(room);
        }

        public IActionResult Delete(int id)
        {
            Room room = new Room();
            using (BookedDB dB = new BookedDB())
            {

                try
                {
                    room = dB.Room.FirstOrDefault(x => x.Id == id);
                    dB.Room.Remove(room);
                    dB.SaveChanges();

                    return View(nameof(CompleteDelete), room);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return View(NotFound());
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
                Room room = new Room();
                using BookedDB dB = new BookedDB();
                {
                    try
                    {
                        room = dB.Room.FirstOrDefault(x => x.Id == id);

                        if (room != null)
                            return View(room);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error message: {ex.Message}");
                    }
                }
            }
            return View(NotFound());
        }

        [HttpPost]
        public IActionResult Correct(int id, Room room)
        {
            if (id <= 0)
                return View(NotFound());
            if (ModelState.IsValid)
            {
                if (room.Square > 0 && room.MaximumGuests > 0)
                {
                    using BookedDB dB = new BookedDB();
                    {
                        try
                        {
                            Room roomdb = dB.Room.FirstOrDefault(x => x.Id == id);
                            roomdb.Square = room.Square;
                            roomdb.MaximumGuests = room.MaximumGuests;
                            dB.Room.Update(roomdb);
                            dB.SaveChanges();

                            return View(nameof(CompleteCorrect), room);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error {ex.Message}");
                        }
                    }
                }
            }
            return View(room);
        }
        public IActionResult CompleteCorrect(Room room)
        {
            return View(room);
        }
    }
}
