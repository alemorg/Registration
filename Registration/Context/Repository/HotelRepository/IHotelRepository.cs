namespace Registration.Context.Repository.HotelRepository
{
    public interface IHotelRepository<Hotel>
    {
        IEnumerable<Hotel> List();
        void Create(Hotel hotel);
        void Correct(Hotel hotel);
        void Delete(int id);
        Hotel GetById (int id);
    }
}
