using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Registration.Context;
using Registration.Context.Repository.HotelRepository;
using Registration.Model.Home;
using Registration.Model.Hotels;
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

        public IActionResult Profile(int id)
        {
            return View(hotelService.Profile(id));
        }

        public IActionResult List()
        {
            if (hotelService != null) return View(hotelService.List());
            else return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                hotelService.Create(hotel);

                return RedirectToAction(nameof(CompleteCreate), hotel);
            }

            return View(hotel);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult CompleteCreate(Hotel hotel)
        {
            return View(hotel);
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        public IActionResult CompleteDelete(Hotel hotel)
        {
            return View(hotel);
        }

        [HttpGet]
        [Authorize(Roles = "Managers")]
        public IActionResult Correct(int id)
        {
            if (id > 0)
            {
                var hotel = hotelService.Profile(id);

                if (hotel != null)
                {
                    return View(hotel);
                }
            }
            return NotFound();
        }

        // Нужно ли здесь ID?
        [HttpPost]
        [Authorize(Roles = "Managers")]
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

        [Authorize(Roles = "Managers")]
        public IActionResult CompleteCorrect(Hotel hotel)
        {
            return View(hotel);
        }
    }
}
