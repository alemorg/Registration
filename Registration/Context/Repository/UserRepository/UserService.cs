using Registration.Model.Hotels;
using Registration.Model.Users;

namespace Registration.Context.Repository.UserRepository
{
    public class UserService
    {
        private readonly IUserRepository<User> repository;

        public UserService(IUserRepository<User> repository)
        {
            this.repository = repository;
        }
        public IEnumerable<User> List()
        {
            return repository.List();
        }

        public void Create(User user)
        {
            repository.Create(user);
        }

        public void Correct(User user)
        {
            repository.Correct(user);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public User Profile(int id)
        {
            return repository.GetById(id);
        }

        public User GetByEmail(string Email)
        {
            return repository.GetByEmail(Email);
        }

        public User GetByLogin(string Login)
        {
            return repository.GetByEmail(Login);
        }

    }
}
