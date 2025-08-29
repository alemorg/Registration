using Microsoft.AspNetCore.Mvc;
using Registration.Context;
using Registration.Model.Home;
using Registration.Model.Hotels;
using Registration.Model.Hotels.Repository.HotelRepository;
using System.Linq;

namespace Registration.Controllers
{
    public class HotelController : Controller
    {
        private readonly HotelService hotelService;
        public HotelController(HotelService hotelService)
        {
            this.hotelService = hotelService;
        }
        public IActionResult List()
        {
            if (hotelService != null) return View(hotelService.List());
            else return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                hotelService.Create(hotel);

                return View(nameof(CompleteCreate), hotel);
            }

            return View(hotel);
        }
        public IActionResult CompleteCreate(Hotel hotel)
        {
            return View(hotel);
        }

        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                var hotel = hotelService.Profile(id);

                if (hotel != null)
                {
                    hotelService.Delete(id);
                    return RedirectToAction(nameof(CompleteDelete), hotel);
                }
            }
            return NotFound();
        }

        public IActionResult CompleteDelete(Hotel hotel)
        {
            return View(hotel);
        }

        [HttpGet]
        public IActionResult Correct(int id)
        {
            if (id > 0)
            {
                var hotel = hotelService.Profile(id);

                if (hotel != null)
                {
                    return View(nameof(Correct), hotel);
                }
            }
            return NotFound();
        }

        // Нужно ли здесь ID?
        [HttpPost]
        public IActionResult Correct(int id, Hotel hotel)
        {
            if (id > 0)
            {
                if (ModelState.IsValid)
                {
                    hotelService.Correct(hotel);
                    return View(nameof(CompleteCorrect), hotel);
                }
                return View(hotel);
            }
            return NotFound();
        }
        public IActionResult CompleteCorrect(Hotel hotel)
        {
            return View(hotel);
        }
    }
}
