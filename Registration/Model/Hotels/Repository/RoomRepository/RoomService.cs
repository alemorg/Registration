namespace Registration.Model.Hotels.Repository.RoomRepository
{
    public class RoomService
    {
        private readonly IRepository<Room> repository;

        public RoomService(IRepository<Room> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Room> List()
        {
            return repository.List();
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
