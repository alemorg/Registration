using Microsoft.AspNetCore.Mvc;
using Registration.Context;
using Registration.Model.Hotels;
using System.Linq;

namespace Registration.Controllers
{
    public class HotelController : Controller
    {
        public IActionResult ListHotel()
        {
            using (BookedDB db = new BookedDB())
            {
                List<Hotel> ListHotel = new List<Hotel>();

                foreach (Hotel hotel in db.HotelInfo)
                {
                    ListHotel.Add(hotel);
                }

                if (ListHotel.Count != 0)
                    return View(ListHotel);
                else return View();
            }
        }

        [HttpGet]
        public IActionResult CreateHotel()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateHotel(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                if (hotel.Name != null)
                {
                    using (BookedDB db = new BookedDB())
                    {
                        db.HotelInfo.Add(hotel);
                        db.SaveChanges();
                        return View("CompleteCreateHotel", hotel);
                    }
                }
            }
            return View(hotel);
        }
        public IActionResult CompleteCreateHotel(Hotel hotel)
        {
            return View(hotel);
        }

        public IActionResult DeleteHotel(int id)
        {
            Hotel hotel = new Hotel();
            using (BookedDB dB = new BookedDB())
            {
                try
                {
                    hotel = dB.HotelInfo.FirstOrDefault(x => x.Id == id);
                    dB.HotelInfo.Remove(hotel);
                    dB.SaveChanges();

                    return View("CompleteDeleteHotel", hotel);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return View(NotFound());

        }

        public IActionResult CompleteDeleteHotel(Hotel hotel)
        {
            return View(hotel);
        }

        [HttpGet]
        public IActionResult CorrectHotel(int id)
        {
            if (id <= 0)
                return View(NotFound());
            Hotel hotel = new Hotel();
            using BookedDB dB = new BookedDB();
            {
                hotel = dB.HotelInfo.FirstOrDefault(x => x.Id == id);
                return View(hotel);
            }
        }

        [HttpPost]
        public IActionResult CorrectHotel(int id, Hotel hotel)
        {
            if (id <= 0)
                return View (NotFound());

            if (ModelState.IsValid)
            {
                if (hotel.Name != null)
                {
                    using BookedDB dB = new BookedDB();
                    {
                        try
                        {
                            Hotel hoteldb = dB.HotelInfo.FirstOrDefault(x => x.Id == id);
                            hoteldb.Name = hotel.Name;
                            hoteldb.Location = hotel.Location;
                            dB.HotelInfo.Update(hoteldb);
                            dB.SaveChanges();

                            return View("CompleteCorrectHotel", hotel);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error {ex.Message}");
                        }
                    }
                }
            }
            return View(hotel);
        }
    }
}
