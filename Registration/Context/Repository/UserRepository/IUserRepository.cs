using Registration.Model.Users;

namespace Registration.Context.Repository.UserRepository
{
    public interface IUserRepository<User>
    {
        IEnumerable<User> List();
        void Create(User user);
        void Correct(User user);
        void Delete(int id);
        User GetById (int id);
        User GetByEmail(string str);
        User GetByLogin(string str);
    }
}
