
using Microsoft.EntityFrameworkCore;
using Registration.Context.Repository.HotelRepository;
using Registration.Model.Hotels;

namespace Registration.Context.Repository.RoomRepository
{
    public class RoomRepository : IRoomRepository<Room>
    {
        private readonly AppDbContext context;
        public RoomRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Create(Room room)
        {
            context.Add(room);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            var room = context.Rooms.Find(id);

            if (room != null)
            {
                context.Remove(room);
                context.SaveChanges();
            }
        }
        public IEnumerable<Room> List(int hotelId)
        {
            var RoomDB = context.Rooms.ToList();
            var result = new List<Room>();
            foreach (var room in RoomDB)
            {
                if (room.HotelId == hotelId) result.Add(room);
            }

            return result;
        }
        public void Correct(Room room)
        {
            if (room != null)
            {
                var roomdb = context.Rooms.Find(room.Id);
                if (roomdb != null) 
                {
                    roomdb.Number = room.Number;
                    roomdb.Price = room.Price;
                    roomdb.Square = room.Square;
                    roomdb.Capasity= room.Capasity;
                    roomdb.isActivity = room.isActivity;
                    roomdb.Discription = room.Discription;

                    context.Rooms.Attach(roomdb);
                    context.SaveChanges();
                }
            }
        }
        public Room GetById(int id)
        {
            if (id > 0) return context.Rooms.Include(x => x.Hotel).FirstOrDefault(x => x.Id == id);
            else throw new Exception("При поиске комнаты по ID, ID<=0");
        }
    }
}
