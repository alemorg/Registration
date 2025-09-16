using Registration.Context.Repository.HotelRepository;
using Registration.Model.Hotels;

namespace Registration.Context.Repository.RoomRepository
{
    public class RoomService
    {
        private readonly IRoomRepository<Room> repository;

        public RoomService(IRoomRepository<Room> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Room> List(int hotelId)
        {
            return repository.List(hotelId);
        }

        public void Create(Room room)
        {
            repository.Create(room);
        }

        public void Correct(Room room)
        {
            repository.Correct(room);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public Room Profile(int id)
        {
            return repository.GetById(id);
        }
    }
}
