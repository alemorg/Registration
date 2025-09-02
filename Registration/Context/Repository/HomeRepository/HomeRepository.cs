using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Registration.Model.Home;
using Registration.Model.Hotels;
using System.Data;
using System.Threading.Tasks;

namespace Registration.Context.Repository.HomeRepository
{
    public class HomeRepository : IHomeRepository
    {
        private readonly AppDbContext context;
        public HomeRepository(AppDbContext context)
        {
            this.context = context;
        }

        public List<FindResultModel> FindByForm(HomePageModel homePageModel)
        {
            var HotelsWithRooms = (
                from hotel in context.Hotels
                where hotel.Location == homePageModel.Location
                select new
                {
                    Hotel = hotel,
                    Rooms = hotel.Rooms
                        .Where(room => room.Capasity >= homePageModel.Children + homePageModel.Grownup)
                        .Where(room => room.ListBookeds.Any(
                            b => !(homePageModel.dateStartBooked < b.dateEndBooked)
                            && !(homePageModel.dateEndBooked > b.dateStartBooked)))
                    .ToList()
                })
                .Where(x => x.Rooms.Any())
                .ToList();

            var result = HotelsWithRooms.Select(x => new FindResultModel
            {
                HotelId = x.Hotel.Id,
                HotelName = x.Hotel.Name,
                rooms = x.Rooms.Select(room => new RoomInfo
                {
                    Id = room.Id,
                    Number = room.Number,
                    Price = room.Price,
                    Square = room.Square,
                    Discription = room.Discription
                }).ToList()
            }).ToList();

            return result;

            //var hotelsdb = context.Hotels.ToList();
            //var hotels = new List<Hotel>();
            //if (homePageModel.Location != null)
            //{
            //    foreach (var hotel in hotelsdb)
            //    {
            //        if (hotel.Location == homePageModel.Location)
            //            hotels.Add(hotel);
            //    }
            //}
            //else
            //{
            //    hotels = hotelsdb.ToList();
            //}

            //var BookedDB = context.Bookeds.ToList();
            //var bookeds = new List<Booked>();

            //if (homePageModel.dateStartBooked > DateTime.Now && homePageModel.dateEndBooked > DateTime.Now)
            //{
            //    if (homePageModel.dateStartBooked <= homePageModel.dateEndBooked)
            //    {
            //        foreach (var item in BookedDB)
            //        {
            //            if (homePageModel.dateStartBooked>= item.dateStartBooked
            //                && homePageModel.dateEndBooked <= item.dateEndBooked)
            //            {
            //                bookeds.Add(item);
            //            }
            //        }
            //    }
            //}

            //var RoomDB = context.Rooms.ToList();

            //foreach (var hotel in hotels)
            //{
            //    foreach (var room in RoomDB)
            //    {
            //        if (bookeds.FirstOrDefault(b => b.Roomid == room.Id) == null)
            //    }
            //}

        }
    }
}
