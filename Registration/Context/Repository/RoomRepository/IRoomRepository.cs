namespace Registration.Context.Repository.RoomRepository
{
    public interface IRoomRepository<Room>
    {
        IEnumerable<Room> List(int hotelId);
        void Create(Room room);
        void Correct(Room room);
        void Delete(int id);
        Room GetById(int id);
    }
}
