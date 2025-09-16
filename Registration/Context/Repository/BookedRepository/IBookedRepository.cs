namespace Registration.Context.Repository.BookedRepository
{
    public interface IBookedRepository<Booked>
    {
        IEnumerable<Booked> List(int roomId);
        void Create(Booked booked);
        void Correct(Booked booked);
        void Delete(int id);
        Booked GetById(int id);
    }
}
