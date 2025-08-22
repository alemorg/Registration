using Microsoft.AspNetCore.Mvc;
using Registration.Context;
using Registration.Model.Hotels;
using System;
using System.Data;

namespace Registration.Controllers
{
    public class BookedController : Controller
    {
        [HttpGet("hotel/{hotelId}/room/{roomId}/booked/{action}/{id?}")]
        public IActionResult List(int hotelId, int roomId)
        {
            ViewBag.hotelId = hotelId;
            ViewBag.roomId = roomId;
            using (BookedDB db = new BookedDB())
            {
                try
                {
                    List<BookedRoom> ListBookedRoom = null;

                    foreach (BookedRoom booked in db.BookedRoom)
                    {
                        if (booked.Roomid == roomId)
                            ListBookedRoom.Add(booked);
                    }
                    return View(ListBookedRoom);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error {ex.Message}");
                }
                return View(NotFound());
            }

        }

        [HttpGet]
        public IActionResult Create(int roomId)
        {
            ViewBag.roomId = roomId;
            return View();
        }

        [HttpPost]
        public IActionResult Create(int roomId, BookedRoom booked)
        {
            if (roomId == 0)
                return View(NotFound());
            if (ModelState.IsValid)
            {
                if (booked.dataBooked > DateTime.Today)
                {
                    using (BookedDB db = new BookedDB())
                    {
                        BookedRoom bookedDB = db.BookedRoom.FirstOrDefault(x => x.Roomid == roomId && x.dataBooked == booked.dataBooked && x.isBooked == true);
                        if (bookedDB == null)
                        {
                            db.BookedRoom.Add(booked);
                            db.SaveChanges();

                            return View(nameof(CompleteCreate), booked);
                        }
                        else
                        {
                            ViewBag.Message = "Выбранная дата уже занята другим пользователем!";
                        }
                    }
                }
                else
                {
                    ViewBag.Message = $"Выберете дату начиная с {DateTime.Today}";
                }
            }
            return View(booked);
        }

        public IActionResult CompleteCreate(BookedRoom booked)
        {
            return View();
        }
    }
}
