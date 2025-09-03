using Microsoft.AspNetCore.Mvc;
using Registration.Context.Repository.BookedRepository;
using Registration.Model.Hotels;
using System.Globalization;


namespace Registration.Controllers
{
    public class BookedController : Controller
    {
        private readonly BookedService bookedService;
        public BookedController(BookedService bookedService)
        {
            this.bookedService = bookedService;
        }

        [HttpGet("hotel/{hotelId}/room/{roomId}/booked/{action}/{id?}")]
        public IActionResult List(int hotelId, int roomId)
        {
            //добавить тонну проверок данных
            ViewBag.hotelId = hotelId;
            ViewBag.roomId = roomId;

            if (bookedService != null) return View(bookedService.List(roomId));
            else return View();
        }

        [HttpGet]
        public IActionResult Create(int roomId)
        {
            ViewBag.roomId = roomId;
            return View();
        }

        [HttpPost]
        //public IActionResult Create(int roomId, Booked booked,DateTime? dateStartBooked, DateTime? dateEndBooked)
        public IActionResult Create(int roomId, Booked booked)
        {
            ViewBag.roomId = roomId;
            if (roomId > 0)
            {
                if (ModelState.IsValid)
                {
                    bookedService.Create(booked);

                    return RedirectToAction(nameof(CompleteCreate), booked);
                }
                return View(booked);
            }
            return NotFound();
        }

        public IActionResult CompleteCreate(Booked booked)
        {
            return View(booked);
        }

        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                var booked = bookedService.Profile(id);
                if (booked != null)
                {
                    bookedService.Delete(id);
                    return RedirectToAction(nameof(CompleteDelete), booked);
                }
            }
            return NotFound();
        }

        public IActionResult CompleteDelete(Booked booked)
        {
            return View(booked);
        }

        [HttpGet]
        public IActionResult Correct(int id)
        {
            if (id > 0)
            {
                ViewBag.id = id;
                var bookedDb = bookedService.Profile(id);
                if (bookedDb!= null)
                {
                    return View(bookedDb);
                }
            }
            return View(NotFound());
        }

        [HttpPost]
        public IActionResult Correct(int id, Booked booked)
        {
            if (id > 0)
            {
                if (ModelState.IsValid)
                {
                    bookedService.Correct(booked);

                    return RedirectToAction(nameof(CompleteCorrect), booked);
                }
                return View(booked);
            }
            return NotFound();
        }

        public IActionResult CompleteCorrect(Booked booked)
        {
            return View(booked);
        }
    }
}
