namespace Registration.Model.Hotels.Repository.HotelRepository
{
    public class HotelService 
    {
        private readonly IRepository<Hotel> repository;

        public HotelService(IRepository<Hotel> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Hotel> List()
        {
            return repository.List();
        }

        public void Create(Hotel hotel)
        {
            repository.Create(hotel);
        }

        public void Correct(Hotel hotel)
        {
            repository.Correct(hotel);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public Hotel Profile(int id)
        {
            return repository.GetById(id);
        }
    }
}
