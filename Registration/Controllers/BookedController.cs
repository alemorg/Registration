using Microsoft.AspNetCore.Mvc;
using Registration.Context;
using Registration.Model.Hotels;
using System;
using System.Data;

namespace Registration.Controllers
{
    public class BookedController : Controller
    {
        //[HttpGet("hotel/{hotelId}/room/{roomId}/booked/{action}/{id?}")]
        //public IActionResult List(int hotelId, int roomId)
        //{
        //    //добавить тонну проверок данных
        //    ViewBag.hotelId = hotelId;
        //    ViewBag.roomId = roomId;
        //    //using (BookedDB db = new BookedDB())
        //    //{
        //    //    try
        //    //    {
        //    //        List<Booked> ListBookedRoom = new List<Booked>();

        //    //        foreach (Booked booked in db.Booked)
        //    //        {
        //    //            if (booked.Roomid == roomId)
        //    //                ListBookedRoom.Create(booked);
        //    //        }
        //    //        return View(ListBookedRoom);
        //    //    }
        //    //    catch (Exception ex)
        //    //    {
        //    //        Console.WriteLine($"Error {ex.Message}");
        //    //    }
        //    //    return View(NotFound());
        //    //}

        //}

        [HttpGet]
        public IActionResult Create(int roomId)
        {
            ViewBag.roomId = roomId;
            return View();
        }

        //[HttpPost]
        //public IActionResult Create(int roomId, Booked booked)
        //{
        //    //добавить тонну проверок данных
        //    if (roomId == 0)
        //        return View(NotFound());
        //    ViewBag.roomId = roomId;
        //    if (ModelState.IsValid)
        //    {
        //        if (booked.DataBooked > DateTime.Today)
        //        {
        //            using (BookedDB db = new BookedDB())
        //            {
        //                Booked bookedDB = db.Booked.FirstOrDefault(x => x.Roomid == roomId && x.DataBooked == booked.DataBooked);
        //                if (bookedDB == null)
        //                {
        //                    db.Booked.Create(booked);
        //                    db.SaveChanges();

        //                    return View(nameof(CompleteCreate), booked);
        //                }
        //                else
        //                {
        //                    ViewBag.Message = "Выбранная дата уже занята другим пользователем!";
        //                }
        //            }
        //        }
        //        else
        //        {
        //            ViewBag.Message = $"Выберете дату начиная с {DateTime.Today}";
        //        }
        //    }
        //    return View(booked);
        //}

        public IActionResult CompleteCreate(Booked booked)
        {
            return View();
        }

        //public IActionResult Delete(int id)
        //{
        //    Booked booked = new Booked();
        //    using (BookedDB dB = new BookedDB())
        //    {
        //        try
        //        {
        //            booked = dB.Booked.FirstOrDefault(x => x.Id == id);
        //            if (booked != null)
        //            {
        //                dB.Booked.Remove(booked);
        //                dB.SaveChanges();

        //                return View(nameof(CompleteDelete), booked);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //        }
        //    }
        //    return View(NotFound());
        //}

        public IActionResult CompleteDelete(Booked booked)
        {
            return View(booked);
        }

        //[HttpGet]
        //public IActionResult Correct(int id)
        //{
        //    if (id > 0)
        //    {
        //        ViewBag.id = id;
        //        Booked booked = new Booked();
        //        using BookedDB dB = new BookedDB();
        //        {
        //            try
        //            {
        //                booked = dB.Booked.FirstOrDefault(x => x.Id == id);

        //                if (booked != null)
        //                    return View(booked);
        //            }
        //            catch (Exception ex)
        //            {
        //                Console.WriteLine($"Error message: {ex.Message}");
        //            }
        //        }
        //    }
        //    return View(NotFound());
        //}

        //[HttpPost]
        //public IActionResult Correct(int id, Booked booked)
        //{
        //    //добавить тонну проверок данных
        //    if (id <= 0)
        //        return View(NotFound());
        //    if (ModelState.IsValid)
        //    {
        //        if (booked.DataBooked > DateTime.Today)
        //        {
        //            using BookedDB dB = new BookedDB();
        //            {
        //                try
        //                {
        //                    Booked ErrorBooked = dB.Booked.FirstOrDefault(x => x.DataBooked == booked.DataBooked);
        //                    if (ErrorBooked != null)
        //                    {
        //                        Booked bookeddb = dB.Booked.FirstOrDefault(x => x.Id == id);

        //                        bookeddb.DataBooked = booked.DataBooked;
        //                        dB.Booked.Correct(bookeddb);
        //                        dB.SaveChanges();
        //                        return View(nameof(CompleteCorrect), bookeddb);
        //                    }
        //                    else
        //                    {
        //                        ViewBag.Message = "Выбранная дата уже занята другим пользователем!";
        //                    }
        //                }
        //                catch (Exception ex)
        //                {
        //                    Console.WriteLine($"Error {ex.Message}");
        //                }
        //            }
        //        }
        //        else
        //        {
        //            ViewBag.Message = $"Выберете дату начиная с {DateTime.Today}";
        //        }
        //    }
        //    return View(booked);
        //}

        public IActionResult CompleteCorrect(Booked booked)
        {
            return View(booked);
        }
    }
}
