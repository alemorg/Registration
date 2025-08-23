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
                    List<BookedRoom> ListBookedRoom = new List<BookedRoom>();

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
            ViewBag.roomId = roomId;
            if (ModelState.IsValid)
            {
                if (booked.dataBooked > DateTime.Today)
                {
                    using (BookedDB db = new BookedDB())
                    {
                        BookedRoom bookedDB = db.BookedRoom.FirstOrDefault(x => x.Roomid == roomId && x.dataBooked == booked.dataBooked);
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

        public IActionResult Delete(int id)
        {
            BookedRoom booked = new BookedRoom();
            using (BookedDB dB = new BookedDB())
            {
                try
                {
                    booked = dB.BookedRoom.FirstOrDefault(x => x.Id == id);
                    if (booked != null)
                    {
                        dB.BookedRoom.Remove(booked);
                        dB.SaveChanges();

                        return View(nameof(CompleteDelete), booked);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return View(NotFound());
        }

        public IActionResult CompleteDelete(BookedRoom booked)
        {
            return View(booked);
        }

        [HttpGet]
        public IActionResult Correct(int id)
        {
            if (id > 0)
            {
                ViewBag.id = id;
                BookedRoom booked = new BookedRoom();
                using BookedDB dB = new BookedDB();
                {
                    try
                    {
                        booked = dB.BookedRoom.FirstOrDefault(x => x.Id == id);

                        if (booked != null)
                            return View(booked);
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
        public IActionResult Correct(int id, BookedRoom booked)
        {
            if (id <= 0)
                return View(NotFound());
            if (ModelState.IsValid)
            {
                if (booked.dataBooked > DateTime.Today)
                {
                    using BookedDB dB = new BookedDB();
                    {
                        try
                        {
                            BookedRoom ErrorBooked = dB.BookedRoom.FirstOrDefault(x => x.dataBooked == booked.dataBooked);
                            if (ErrorBooked != null)
                            {
                                BookedRoom bookeddb = dB.BookedRoom.FirstOrDefault(x => x.Id == id);

                                bookeddb.dataBooked = booked.dataBooked;
                                dB.BookedRoom.Update(bookeddb);
                                dB.SaveChanges();
                                return View(nameof(CompleteCorrect), bookeddb);
                            }
                            else
                            {
                                ViewBag.Message = "Выбранная дата уже занята другим пользователем!";
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error {ex.Message}");
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

        public IActionResult CompleteCorrect(BookedRoom booked)
        {
            return View(booked);
        }
    }
}
