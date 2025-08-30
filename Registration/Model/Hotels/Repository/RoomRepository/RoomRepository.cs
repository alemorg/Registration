
using Microsoft.EntityFrameworkCore;
using Registration.Context;

namespace Registration.Model.Hotels.Repository.RoomRepository
{
    public class RoomRepository : IRepository<Room>
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
            var room = context.Room.Find(id);

            if (room != null)
            {
                context.Remove(room);
                context.SaveChanges();
            }
        }
        public IEnumerable<Room> List()
        {
            return context.Room.ToList();
        }
        public void Correct(Room room)
        {
            if (room != null)
            {
                //context.Room.Attach(room);
                //context.Entry(room).State = EntityState.Modified;

                var roomdb = context.Room.Find(room.Id);
                if (roomdb != null) 
                {
                    roomdb.Number = room.Number;
                    roomdb.Price = room.Price;
                    roomdb.Square = room.Square;
                    roomdb.Capasity= room.Capasity;
                    roomdb.isActivity = room.isActivity;
                    roomdb.Discription = room.Discription;

                    context.Room.Attach(roomdb);
                    context.SaveChanges();
                }
                
            }
        }
        public Room GetById(int id)
        {
            if (id > 0) return context.Room.Include(x => x.Hotel).FirstOrDefault(x => x.Id == id);
            else throw new Exception("При поиске комнаты по ID, ID<=0");
        }
    }
}
