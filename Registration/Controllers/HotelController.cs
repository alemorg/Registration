using Microsoft.AspNetCore.Mvc;
using Registration.Context;
using Registration.Model.Hotels;
using System.Linq;

namespace Registration.Controllers
{
    public class HotelController : Controller
    {
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
                if (room.Square > 0 && room.MaximumGuests > 0)
                {
                    using (BookedDB db = new BookedDB())
                    {
                        db.RoomInfo.Add(room);
                        db.SaveChanges();
                        return View("CompleteCreateRoom", room);
                    }
                }
            }
            return View(room);
        }

        public IActionResult CompleteCreateRoom(Room room)
        {
            return View(room);
        }

        public IActionResult ListRooms()
        {
            using (BookedDB db = new BookedDB())
            {
                List<Room> ListRoom = new List<Room>();

                foreach (Room room in db.RoomInfo)
                {
                    ListRoom.Add(room);
                }

                if (ListRoom.Count != 0)
                    return View(ListRoom);
                else return View();
            }
        }

        //[HttpGet("{id}")]
        [HttpGet]
        public IActionResult DeleteRoom(int id)
        {
            Room room = new Room();
            using (BookedDB dB = new BookedDB())
            {

                try
                {
                    room = dB.RoomInfo.FirstOrDefault(x => x.Id == id);
                    dB.RoomInfo.Remove(room);
                    dB.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return View(NotFound());
                }
            }

            return View("CompleteDeleteRoom", room);
        }

        public IActionResult CompleteDeleteRoom(Room room)
        {
            return View(room);
        }

        [HttpGet]
        public IActionResult CorrectRoom (int id)
        {
            if (id <= 0)
                return NotFound();
            Room room = new Room();
            using BookedDB dB = new BookedDB();
            {
                room = dB.RoomInfo.FirstOrDefault( x => x.Id == id);
                return View(room);
            }
        }

        [HttpPost]
        public IActionResult CorrectRoom(int id, Room room)
        {
            if (id <= 0)
                NotFound();
            
            if (ModelState.IsValid)
            {
                if (room.Square > 0 && room.MaximumGuests > 0)
                {
                    using BookedDB dB = new BookedDB();
                    {
                        try
                        {
                            Room roomdb = dB.RoomInfo.FirstOrDefault(x => x.Id == id);
                            roomdb.Square = room.Square;
                            roomdb.MaximumGuests = room.MaximumGuests;
                            dB.RoomInfo.Update(roomdb);
                            dB.SaveChanges();

                            return View("CompleteCorrectRoom", room);
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
    }
}
