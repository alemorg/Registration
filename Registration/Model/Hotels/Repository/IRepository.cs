namespace Registration.Model.Hotels.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> List();
        void Create(T entity);
        void Correct(T entity);
        void Delete(int id);
        T GetById (int id);
    }
}
