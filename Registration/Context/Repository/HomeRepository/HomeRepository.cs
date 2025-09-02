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

        public List<FindResultModel> FindByForm(HomePageModel model)
        {
            if (model == null) return new List<FindResultModel>();

            var result = new List<FindResultModel>();

            // Фильтрация отелей по локации (если задана)
            var hotels = context.Hotels.Include(h => h.Rooms)
                .Where(h => string.IsNullOrEmpty(model.Location) || h.Location.Contains(model.Location))
                .ToList();

            foreach (var hotel in hotels)
            {
                var availableRooms = new List<RoomInfo>();

                // Фильтрация номеров по датам заезда/выезда и вместимости
                foreach (var room in hotel.Rooms)
                {
                    // Проверка доступности номера в указанные даты
                    if (!IsRoomAvailable(room, model.dateStartBooked, model.dateEndBooked))
                        continue;

                    // Проверка количества гостей и наличия животных
                    if (model.Grownup.HasValue || model.Children.HasValue)
                    {
                        int totalGuests = (model.Grownup ?? 0) + (model.Children ?? 0);
                        if (room.Capasity < totalGuests)
                            continue;
                    }

                    //if (model.IsAnimal && !room.Hotel.IsPetFriendly)
                        //continue;

                    // Добавляем информацию о номере в результат
                    availableRooms.Add(new RoomInfo
                    {
                        Id = room.Id,
                        Number = room.Number,
                        Price = room.Price,
                        Square = room.Square,
                        Discription = room.Discription
                    });
                }

                if (availableRooms.Count > 0)
                {
                    result.Add(new FindResultModel
                    {
                        HotelId = hotel.Id,
                        HotelName = hotel.Name,
                        rooms = availableRooms
                    });
                }
            }

            return result;
        }

        // Проверка доступности номера в указанные даты
        private bool IsRoomAvailable(Room room, DateTime checkIn, DateTime checkOut)
        {
            // Логика проверки: номер не должен быть забронирован в эти даты
            var bookedRooms = context.Bookeds
                .Where(b => b.Roomid == room.Id &&
                            b.dateStartBooked <= checkOut &&
                            b.dateEndBooked >= checkIn)
                .ToList();

            return !bookedRooms.Any();
        }


    }
}

